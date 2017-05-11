// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7Cooler.cs" company="SRON">
//   
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

    public class He7Cooler
    {
        private const int readInterval = 100;

        protected List<Channels> channelsToRead = new List<Channels>();

        private Dictionary<Channels, double> values;

        private readonly Agilent34972A device = new Agilent34972A();

        
        private Thread readThread;
        private bool isStarted = false;


        // static switch_type Switches[] = { {SENS_HE3HEAD_T, CTRL_MON_HE3HEAD_T},
        // {SENS_HE4HEAD_T,CTRL_MON_HE4HEAD_T},
        // {PUMP_HE3, CTRL_SWITCH_HE3PUMP},
        // {PUMP_HE4, CTRL_SWITCH_HE4PUMP} };

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
            this.readThread = new Thread(mainLoop);
            this.readThread.Start();
         }

        public void Disconnect()
        {
            this.isStarted = false;
            this.device.Disconnect();
        }

        public void mainLoop()
        {
            while (isStarted)
            {
                this.ReadVoltages();
                Thread.Sleep(100);
            }
        }
        

        protected void SetVoltage(Channels channel, double volts)
        {
            this.device.SetHeaterVoltage(channel, volts);
        }

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

        public class Heater
        {
            private Channels inchannel;

            private Channels outchannel;

            private He7Cooler device;

            public double voltage
            {
                get => this.device.values[this.inchannel];
                set => this.setOutput(this.voltage);
            }

            Heater(Channels outputChannel, Channels inputChannel, He7Cooler device)
            {
                this.inchannel = inputChannel;
                this.outchannel = outputChannel;
                this.device = device;
                device.channelsToRead.Add(inputChannel);
            }

            void setOutput(double volts)
            {
                this.device.SetVoltage(this.outchannel, volts);
            }
        }

        public class Sensor
        {

            private Channels channel;

            private He7Cooler device;

            private Calibration calibration;

            public double Value
            {
                get => calibration.ConvertValue(this.device.values[this.channel]);
            }

            public Sensor(Channels channel, He7Cooler device, Calibration calibration)
            {
                this.channel = channel;
                this.device = device;
                device.channelsToRead.Add(channel);
            }

            ~Sensor()
            {
                this.device.channelsToRead.Remove(this.channel);
            }


            public class Calibration
            {
                
                /// <summary>
                /// The calibration data.
                /// </summary>
                private List<Tuple<double, double>> calibrationData = new List<Tuple<double, double>>();

                public int CalibrationSize => this.calibrationData.Count;

                public Calibration()
                {
                }

                public Calibration(string filename, int voltColumn, int tempColumn)
                {
                    this.LoadSensorCalibrationFromFile(filename, voltColumn, tempColumn);
                }

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