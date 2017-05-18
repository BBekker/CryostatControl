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
        /// The ruox calibration file location.
        /// </summary>
        private const string RuoxFile = "..\\..\\RUOX.CAL";

        /// <summary>
        /// The he 3 column.
        /// </summary>
        private const int He3Col = 2;

        /// <summary>
        /// The he 4 column.
        /// </summary>
        private const int He4Col = 3;

        /// <summary>
        /// The diode calibration file location.
        /// </summary>
        private const string DiodeFile = "..\\..\\DIODE.CAL";

        /// <summary>
        /// The interval between voltage samples
        /// </summary>
        private const int ReadInterval = 100;

        /// <summary>
        /// The connected device.
        /// </summary>
        private Agilent34972A device = new Agilent34972A();

        /// <summary>
        /// The amound in sensor readers per channel.
        /// </summary>
        private Dictionary<Channels, int> readersPerChannel = new Dictionary<Channels, int>();

        /// <summary>
        /// The current voltage of each channel.
        /// </summary>
        private Dictionary<Channels, double> values = new Dictionary<Channels, double>();

        /// <summary>
        /// The thread reading voltages.
        /// </summary>
        private Thread readThread;

        /// <summary>
        /// Is the sampling of voltages started.
        /// </summary>
        private bool isStarted = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="He7Cooler"/> class.
        /// </summary>
        public He7Cooler()
        {
             Sensor.Calibration he3Calibration = new Sensor.Calibration(RuoxFile, He3Col, 0);
             Sensor.Calibration he4Calibration = new Sensor.Calibration(RuoxFile, He4Col, 0);
             Sensor.Calibration diodeCalibration = new Sensor.Calibration(DiodeFile, 1, 0);

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

        #region Sensors

        /// <summary>
        /// Gets the he 3 pump temperature sensor.
        /// </summary>
        public Sensor He3PumpT { get; private set; }

        /// <summary>
        /// Gets the he 4 pump temperature sensor.
        /// </summary>
        public Sensor He4PumpT { get; private set; }

        /// <summary>
        /// Gets the he 4 switch temperature sensor.
        /// </summary>
        public Sensor He4SwitchT { get; private set; }

        /// <summary>
        /// Gets the he 3 switch temperature sensor.
        /// </summary>
        public Sensor He3SwitchT { get; private set; }

        /// <summary>
        /// Gets the plate 4k temperature sensor.
        /// </summary>
        public Sensor Plate4KT { get; private set; }

        /// <summary>
        /// Gets the plate 2k temperature sensor.
        /// </summary>
        public Sensor Plate2KT { get; private set; }

        /// <summary>
        /// Gets the he 4 head temperature sensor.
        /// </summary>
        public Sensor He4HeadT { get; private set; }

        /// <summary>
        /// Gets the he 3 head temperature sensor.
        /// </summary>
        public Sensor He3HeadT { get; private set; }

        #endregion Sensors

        #region Heaters

        /// <summary>
        /// Gets the he 3 pump.
        /// </summary>
        public Heater He3Pump { get; private set; }

        /// <summary>
        /// Gets the he 4 pump.
        /// </summary>
        public Heater He4Pump { get; private set; }

        /// <summary>
        /// Gets the he 3 switch.
        /// </summary>
        public Heater He3Switch { get; private set; }

        /// <summary>
        /// Gets the he 4 switch.
        /// </summary>
        public Heater He4Switch { get; private set; }

        #endregion Heaters

        /// <summary>
        /// Connect to the Agilent device.
        /// </summary>
        /// <param name="ip">
        /// The IP to connect to.
        /// </param>
        public void Connect(string ip)
        {
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
        public void Connect(Agilent34972A device)
        {
            this.device = device;
            this.isStarted = true;
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
        /// Read the voltages of all registered channels
        /// </summary>
        public void ReadVoltages()
        {
            Channels[] channels = this.readersPerChannel
                .Where((pair) => pair.Value > 0)
                .Select(pair => pair.Key)
                .ToArray();
            double[] voltages = this.device.GetVoltages(channels);
            for (int i = 0; i < channels.Length; i++)
            {
                this.values[channels[i]] = voltages[i];
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
        /// The add channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void AddChannel(Channels channel)
        {
            if (!this.readersPerChannel.ContainsKey(channel))
            {
                this.readersPerChannel[channel] = 0;
            }
            this.readersPerChannel[channel]++;
        }

        /// <summary>
        /// The remove channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void RemoveChannel(Channels channel)
        {
            if (this.readersPerChannel[channel] > 0)
            {
                this.readersPerChannel[channel]--;
            }
        }

        /// <summary>
        /// The main loop of the thread that reads voltages from the He7 cooler.
        /// </summary>
        private void MainLoop()
        {
            while (this.isStarted)
            {
                this.ReadVoltages();
                Thread.Sleep(ReadInterval);
            }
        }
    }
}