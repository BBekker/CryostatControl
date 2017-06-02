// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7Cooler.cs" company="SRON">
//   All rights reserved. 2017.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Defines the He7Cooler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using CryostatControlServer.Properties;

    /// <summary>
    /// He7 Cooler class.
    /// Represents the He7 cooler controls. Read and set voltages and digital bits.
    /// </summary>
    public partial class He7Cooler
    {
        /// <summary>
        /// The interval between voltage samples
        /// </summary>
        private const int ReadInterval = 1000;

        /// <summary>
        /// The connected device.
        /// </summary>
        private Agilent34972A device = new Agilent34972A();

        private string ip = string.Empty;

        /// <summary>
        /// Is the sampling of voltages started.
        /// </summary>
        private bool isStarted = false;

        /// <summary>
        /// The amount of sensor readers per channel.
        /// </summary>
        private Dictionary<Channels, int> readersPerChannel = new Dictionary<Channels, int>();

        /// <summary>
        /// The thread reading voltages.
        /// </summary>
        private Thread readThread;

        /// <summary>
        /// The current voltage of each channel.
        /// </summary>
        private Dictionary<Channels, double> values = new Dictionary<Channels, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="He7Cooler"/> class.
        /// </summary>
        public He7Cooler()
        {
            Sensor.Calibration he3Calibration = Sensor.Calibration.He3Calibration;
            Sensor.Calibration he4Calibration = Sensor.Calibration.He4Calibration;
            Sensor.Calibration diodeCalibration = Sensor.Calibration.DiodeCalibration;

            this.He3PumpT = new Sensor(Channels.SensHe3PumpT, this, diodeCalibration);
            this.He4PumpT = new Sensor(Channels.SensHe4PumpT, this, diodeCalibration);
            this.He4SwitchT = new Sensor(Channels.SensHe4SwitchT, this, diodeCalibration);
            this.He3SwitchT = new Sensor(Channels.SensHe3SwitchT, this, diodeCalibration);
            this.Plate4KT = new Sensor(Channels.Sens4KplateT, this, diodeCalibration);
            this.Plate2KT = new Sensor(Channels.Sens2KplateT, this, diodeCalibration);
            this.He4HeadT = new Sensor(Channels.SensHe4HeadT, this, he4Calibration);
            this.He3HeadT = new Sensor(Channels.SensHe3HeadT, this, he3Calibration);

            this.He3Pump = new Heater(Channels.PumpHe3, Channels.SensHe3Pump, this);
            this.He4Pump = new Heater(Channels.PumpHe4, Channels.SensHe4Pump, this);
            this.He3Switch = new Heater(Channels.SwitchHe3, Channels.SensHe3Switch, this);
            this.He4Switch = new Heater(Channels.SwitchHe4, Channels.SensHe4Switch, this);

            this.He3Pump.SafeRangeHigh = Settings.Default.He3PumpMaxVoltage;
            this.He4Pump.SafeRangeHigh = Settings.Default.He4PumpMaxVoltage;
            this.He4Switch.SafeRangeHigh = Settings.Default.He4SwitchMaxVoltage;
            this.He3Switch.SafeRangeHigh = Settings.Default.He3SwitchMaxVoltage;
        }

        /// <summary>
        /// Gets the he 3 head temperature sensor.
        /// </summary>
        public Sensor He3HeadT { get; private set; }

        /// <summary>
        /// Gets the he 3 pump.
        /// </summary>
        public Heater He3Pump { get; private set; }

        /// <summary>
        /// Gets the he 3 pump temperature sensor.
        /// </summary>
        public Sensor He3PumpT { get; private set; }

        /// <summary>
        /// Gets the he 3 switch.
        /// </summary>
        public Heater He3Switch { get; private set; }

        /// <summary>
        /// Gets the he 3 switch temperature sensor.
        /// </summary>
        public Sensor He3SwitchT { get; private set; }

        /// <summary>
        /// Gets the he 4 head temperature sensor.
        /// </summary>
        public Sensor He4HeadT { get; private set; }

        /// <summary>
        /// Gets the he 4 pump.
        /// </summary>
        public Heater He4Pump { get; private set; }

        /// <summary>
        /// Gets the he 4 pump temperature sensor.
        /// </summary>
        public Sensor He4PumpT { get; private set; }

        /// <summary>
        /// Gets the he 4 switch.
        /// </summary>
        public Heater He4Switch { get; private set; }

        /// <summary>
        /// Gets the he 4 switch temperature sensor.
        /// </summary>
        public Sensor He4SwitchT { get; private set; }

        /// <summary>
        /// Gets the plate 2k temperature sensor.
        /// </summary>
        public Sensor Plate2KT { get; private set; }

        /// <summary>
        /// Gets the plate 4k temperature sensor.
        /// </summary>
        public Sensor Plate4KT { get; private set; }

        /// <summary>
        /// Connect to the Agilent device.
        /// </summary>
        /// <param name="ip">
        /// The IP to connect to.
        /// </param>
        public void Connect(string ip)
        {
            this.ip = ip;
            this.device.Init(ip);
            this.isStarted = true;
            this.readThread = new Thread(this.MainLoop);
            this.readThread.Start();
        }

        /// <summary>
        /// Connect using an already initialized Agilent device.
        /// Used for testing.
        /// </summary>
        /// <param name="device">
        /// The initialized device.
        /// </param>
        /// <param name="startReading">
        /// The start Reading.
        /// </param>
        public void Connect(Agilent34972A device, bool startReading)
        {
            this.device = device;
            this.isStarted = startReading;
            this.readThread = new Thread(this.MainLoop);
            this.readThread.Start();
        }

        /// <summary>
        /// Stop the reading thread and disconnect from the device.
        /// </summary>
        public void Disconnect()
        {
            this.isStarted = false;
            this.device.Disconnect();
        }

        /// <summary>
        /// Determines whether this instance is connected.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            return this.device.IsConnected();
        }

        /// <summary>
        /// Read the voltages of all registered channels
        /// </summary>
        public void ReadVoltages()
        {
            Channels[] channels;
            Monitor.Enter(this.readersPerChannel);
            try
            {
                channels = this.readersPerChannel.Where((pair) => pair.Value > 0).Select(pair => pair.Key).ToArray();
            }
            finally
            {
                Monitor.Exit(this.readersPerChannel);
            }

            try
            {
                double[] voltages = this.device.GetVoltages(channels);
                for (int i = 0; i < channels.Length; i++)
                {
                    this.values[channels[i]] = voltages[i];
                }
            }
            catch (AgilentException ex)
            {
                Console.WriteLine("Reading values failed: " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("He7 cooler connection error.");
            }
        }

        /// <summary>
        /// The set digital switch.
        /// </summary>
        /// <param name="theSwitch">
        /// The switch.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetDigitalSwitch(DigitalSwitch theSwitch, bool value)
        {
            this.device.SetDigitalOutput((int)theSwitch, value);
        }

        /// <summary>
        /// The add channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void AddChannel(Channels channel)
        {
            Monitor.Enter(this.readersPerChannel);
            try
            {
                if (!this.readersPerChannel.ContainsKey(channel))
                {
                    this.values.Add(channel, 0.0);
                    this.readersPerChannel[channel] = 0;
                }

                this.readersPerChannel[channel]++;
            }
            finally
            {
                Monitor.Exit(this.readersPerChannel);
            }
        }

        /// <summary>
        /// The remove channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void RemoveChannel(Channels channel)
        {
            Monitor.Enter(this.readersPerChannel);
            try
            {
                if (this.readersPerChannel.ContainsKey(channel))
                {
                    if (this.readersPerChannel[channel] > 0)
                    {
                        this.readersPerChannel[channel]--;
                    }
                }
            }
            finally
            {
                Monitor.Exit(this.readersPerChannel);
            }
        }

        /// <summary>
        /// Set the voltage of a channel
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="volts">
        /// The voltage
        /// </param>
        protected void SetVoltage(Channels channel, double volts)
        {
            this.device.SetHeaterVoltage(channel, volts);
        }

        /// <summary>
        /// The main loop of the thread that reads voltages from the He7 cooler.
        /// </summary>
        private void MainLoop()
        {
            while (this.isStarted)
            {
                if (!this.device.IsConnected())
                {
                    Console.WriteLine("H7 cooler disconnected, trying to reconnect...");
                    try
                    {
                        this.device.Disconnect();
                    }
                    catch (Exception e)
                    {
                    }

                    try
                    {
                        this.device.Reopen();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Reconnecting failed: " + e.GetType() + e.Message);
                    }
                }
                else
                {
                    this.ReadVoltages();
                }

                Thread.Sleep(ReadInterval);
            }
        }
    }
}