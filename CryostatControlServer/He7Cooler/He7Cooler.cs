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
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading;

    /// <summary>
    /// He7 Cooler class. 
    /// Represents the He7 cooler controls. Read and set voltages and digital bits.
    /// </summary>
    public class He7Cooler
    { 
        /// <summary>
        /// The interval between voltage samples
        /// </summary>
        private const int ReadInterval = 100;

        /// <summary>
        /// The connected device.
        /// </summary>
        private readonly Agilent34972A device = new Agilent34972A();

        /// <summary>
        /// The channels to read.
        /// </summary>
        private List<Channels> channelsToRead = new List<Channels>();

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
        }

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
            Channels[] channels = this.channelsToRead.ToArray();
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
        /// The the switch.
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
            this.channelsToRead.Add(channel);
        }

        /// <summary>
        /// The remove channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void RemoveChannel(Channels channel)
        {
            this.channelsToRead.Remove(channel);
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

        /// <summary>
        /// Representation a heater element on the H7 cooler.
        /// </summary>
        public class Heater
        {
            /// <summary>
            /// The default safe range high.
            /// </summary>
            private const double DefaultSafeRangeHigh = 10.0;

            /// <summary>
            /// The default safe range low.
            /// </summary>
            private const double DefaultSafeRangeLow = 0.0;

            /// <summary>
            /// The channel where current voltage is read.
            /// </summary>
            private Channels inchannel;

            /// <summary>
            /// The channel where to output the voltage setpoint.
            /// </summary>
            private Channels outchannel;

            /// <summary>
            /// The H7 cooler device.
            /// </summary>
            private He7Cooler device;

            /// <summary>
            /// Initializes a new instance of the <see cref="Heater"/> class.
            /// </summary>
            /// <param name="outputChannel">
            /// The voltage output channel.
            /// </param>
            /// <param name="inputChannel">
            /// The voltage input channel.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device the heater is connected to.
            /// </param>
            public Heater(Channels outputChannel, Channels inputChannel, He7Cooler device)
            {
                this.inchannel = inputChannel;
                this.outchannel = outputChannel;
                this.device = device;
                device.channelsToRead.Add(inputChannel);
                this.SafeRangeHigh = DefaultSafeRangeHigh;
                this.SafeRangeLow = DefaultSafeRangeLow;
            }

            /// <summary>
            /// Gets or sets the voltage safe range high side.
            /// </summary>
            public double SafeRangeHigh { get; set; }

            /// <summary>
            /// Gets or sets the voltage safe range low side.
            /// </summary>
            public double SafeRangeLow { get; set; }

            /// <summary>
            /// Gets or sets the voltage of the heater.
            /// </summary>
            public double Voltage
            {
                get => this.device.values[this.inchannel];
                set => this.SetOutput(this.Voltage);
            }

            /// <summary>
            /// The set output.
            /// </summary>
            /// <param name="volts">
            /// The volts.
            /// </param>
            private void SetOutput(double volts)
            {
                if (volts > this.SafeRangeHigh || volts < this.SafeRangeLow)
                {
                    throw new ArgumentOutOfRangeException(
                        $"Voltage setpoint of {volts} is out of the safe range from {this.SafeRangeLow} to {this.SafeRangeHigh}");
                }

                this.device.SetVoltage(this.outchannel, volts);
            }
        }

        /// <summary>
        /// Representation of a sensor on the H7 cooler.
        /// </summary>
        public class Sensor
        {
            /// <summary>
            /// The Agilent data channel.
            /// </summary>
            private Channels channel;

            /// <summary>
            /// The He7 cooler.
            /// </summary>
            private He7Cooler device;

            /// <summary>
            /// The sensor calibration.
            /// </summary>
            private Calibration calibration;

            /// <summary>
            /// Initializes a new instance of the <see cref="Sensor"/> class.
            /// </summary>
            /// <param name="channel">
            /// The agilent channel of the sensor.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device.
            /// </param>
            /// <param name="calibration">
            /// The calibration.
            /// </param>
            public Sensor(Channels channel, He7Cooler device, Calibration calibration)
            {
                this.channel = channel;
                this.calibration = calibration;
                this.device = device;
                device.channelsToRead.Add(channel);
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="Sensor"/> class.  Removes it from the list of channels to read.
            /// </summary>
            ~Sensor()
            {
                this.device.channelsToRead.Remove(this.channel);
            }

            /// <summary>
            /// Gets the current calibrated value of the sensor.
            /// </summary>
            public double Value => this.calibration.ConvertValue(this.device.values[this.channel]);

            /// <summary>
            /// Sensor calibration representation
            /// </summary>
            public class Calibration
            {
                /// <summary>
                /// The calibration data.
                /// </summary>
                private List<Tuple<double, double>> calibrationData = new List<Tuple<double, double>>();

                /// <summary>
                /// Initializes a new instance of the <see cref="Calibration"/> class. 
                /// Initializes an empty instance without calibration.
                /// </summary>
                public Calibration()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="Calibration"/> class.
                /// </summary>
                /// <param name="filename">
                /// The filename of the calibration file.
                /// </param>
                /// <param name="voltColumn">
                /// The volt column index.
                /// </param>
                /// <param name="tempColumn">
                /// The temp column index.
                /// </param>
                public Calibration(string filename, int voltColumn, int tempColumn)
                {
                    this.LoadSensorCalibrationFromFile(filename, voltColumn, tempColumn);
                }

                /// <summary>
                /// The amount of data points in the calibration
                /// </summary>
                public int CalibrationSize => this.calibrationData.Count;

                /// <summary>
                /// Load sensor calibration from file.
                /// </summary>
                /// <param name="filename">
                /// The filename.
                /// </param>
                /// <param name="voltColumn">
                /// The volt column.
                /// </param>
                /// <param name="tempColumn">
                /// The temp column.
                /// </param>
                public void LoadSensorCalibrationFromFile(string filename, int voltColumn, int tempColumn)
                {
                    StreamReader reader = new StreamReader(filename);
                    try
                    {
                        // skip first line that contains headers
                        reader.ReadLine();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] columns = line.Split('\t');
                            this.calibrationData.Add(
                                new Tuple<double, double>(
                                    double.Parse(columns[voltColumn]),
                                    double.Parse(columns[tempColumn])));
                        }

                        this.calibrationData.Sort((first, second) => (first.Item1 - second.Item1) < 0 ? -1 : 1);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }

                /// <summary>
                /// Add a calibration data point.
                /// Exists mainly to be able to test this class.
                /// </summary>
                /// <param name="datapoint">
                /// The data point.
                /// </param>
                public void AddCalibrationDatapoint(Tuple<double, double> datapoint)
                {
                    this.calibrationData.Add(datapoint);
                    this.calibrationData.Sort((first, second) => (int)(first.Item1 - second.Item1));
                }

                /// <summary>
                /// Convert a voltage to a temperature using the loaded calibration
                /// </summary>
                /// <param name="readVolt">
                /// The sensor voltage.
                /// </param>
                /// <returns>
                /// The temperature in Kelvin <see cref="double"/>.
                /// </returns>
                /// <exception cref="InvalidOperationException">
                /// Thrown if there is no calibration found. Should never happen, does not need to be handled.
                /// </exception>
                public double ConvertValue(double readVolt)
                {
                    // directly return for uncalibrated sensors
                    if (this.calibrationData.Count == 0)
                    {
                        return readVolt;
                    }

                    // Check if voltage is outside of the range of calibration values
                    if (readVolt > this.calibrationData[this.calibrationData.Count - 1].Item1)
                    {
                        return this.calibrationData[this.calibrationData.Count - 1].Item2;
                    }

                    if (readVolt < this.calibrationData[0].Item1)
                    {
                        return this.calibrationData[0].Item2;
                    }

                    // find closest calibration points and linearly interpolate between them.
                    for (int i = 1; i < this.calibrationData.Count; i++)
                    {
                        if (this.calibrationData[i].Item1 >= readVolt)
                        {
                            return InterpolateTemperature(
                                readVolt,
                                this.calibrationData[i - 1],
                                this.calibrationData[i]);
                        }
                    }

                    // this should never be reached.
                    throw new InvalidOperationException("Calibration code failed.");
                }

                /// <summary>
                /// Standard linear interpolation of volt to temperature calibration values.
                /// </summary>
                /// <param name="voltage">
                /// The read voltage.
                /// </param>
                /// <param name="lowValue">
                /// The calibration value just below the read voltage.
                /// </param>
                /// <param name="highValue">
                /// The calibration value just above the read voltage.
                /// </param>
                /// <returns>
                /// Interpolated temperature. <see cref="double"/>.
                /// </returns>
                private static double InterpolateTemperature(
                    double voltage,
                    Tuple<double, double> lowValue,
                    Tuple<double, double> highValue)
                {
                    return ((voltage - lowValue.Item1) / (highValue.Item1 - lowValue.Item1)
                            * (highValue.Item2 - lowValue.Item2)) + lowValue.Item2;
                }
            }
        }
    }
}