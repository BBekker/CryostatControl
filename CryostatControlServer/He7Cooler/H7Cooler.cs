// --------------------------------------------------------------------------------------------------------------------
// <copyright file="H7Cooler.cs" company="SRON">
//   
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Defines the H7Cooler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class H7Cooler
    {
        private readonly Agilent34972A device = new Agilent34972A();

        private Sensor diodeSensor = new Sensor();

        private Sensor he3Sensor = new Sensor();

        private Sensor he4Sensor = new Sensor();

        /// <summary>
        /// Initializes a new instance of the <see cref="H7Cooler"/> class. 
        /// </summary>
        public H7Cooler()
        {
            this.LoadCalibration();
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
        }

        /// <summary>
        /// Load sensor calibration values.
        /// </summary>
        private void LoadCalibration()
        {
            //TODO: Load this from settings
            this.diodeSensor.LoadSensorCalibrationFromFile("DIODE.cal", 1, 0);
            this.he3Sensor.LoadSensorCalibrationFromFile("RUOX.cal", 3, 0);
            this.he4Sensor.LoadSensorCalibrationFromFile("RUOX.cal", 4, 0);
        }



        public class Sensor
        {
            /// <summary>
            /// The calibration data.
            /// </summary>
            private List<Tuple<double, double>> calibrationData = new List<Tuple<double, double>>();
            


            public Sensor()
            {

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
                            new Tuple<double, double>(double.Parse(columns[voltColumn]), double.Parse(columns[tempColumn])));
                    }
                    this.calibrationData.Sort((first, second) => (int)(first.Item1 - second.Item1));
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
            public double ConvertTemperature(double readVolt)
            {
                //Check if voltage is outside of the range of calibration values
                if (readVolt > this.calibrationData[this.calibrationData.Count-1].Item1)
                {
                    return this.calibrationData[this.calibrationData.Count-1].Item2;
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
                        return InterpolateTemperature(readVolt, this.calibrationData[i - 1], this.calibrationData[i]);
                    }
                }

                //this should never be reached.
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
            private static double 
                InterpolateTemperature(
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
