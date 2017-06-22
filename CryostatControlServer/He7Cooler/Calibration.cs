// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Calibration.cs" company="SRON">
//  Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using CryostatControlServer.Logging;

    /// <summary>
    /// Sensor calibration representation
    /// </summary>
    public class Calibration
    {
        /// <summary>
        /// The diode file.
        /// </summary>
        private const string DIODEFile = "Calibrations\\DIODE.CAL";

        /// <summary>
        /// The ruox file.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private const string RUOXFile = "Calibrations\\RUOX.CAL";

        /// <summary>
        /// The amplifiers calibration file.
        /// </summary>
        private const string AmplifiersFile = "Calibrations\\AMPLIFIERS.cal";

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
        /// Gets the diode calibration.
        /// </summary>
        public static Calibration DiodeCalibration { get; } = new Calibration(DIODEFile, 1, 0);

        /// <summary>
        /// Gets the empty calibration.
        /// </summary>
        public static Calibration EmptyCalibration { get; } = new Calibration();

        /// <summary>
        /// Gets the he 3 calibration.
        /// </summary>
        public static Calibration He3Calibration { get; } = new Calibration(RUOXFile, 2, 0);

        /// <summary>
        /// Gets the he 4 calibration.
        /// </summary>
        public static Calibration He4Calibration { get; } = new Calibration(RUOXFile, 3, 0);

        /// <summary>
        /// Gets the he 3 amplifier calibration.
        /// </summary>
        public static Calibration He3AmplifierCalibration { get; } = new Calibration(AmplifiersFile, 1, 0);

        /// <summary>
        /// Gets the he 4 amplifier calibration.
        /// </summary>
        public static Calibration He4AmplifierCalibration { get; } = new Calibration(AmplifiersFile, 2, 0);

        /// <summary>
        /// The amount of data points in the calibration
        /// </summary>
        public int CalibrationSize => this.calibrationData.Count;

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
                    return InterpolateTemperature(readVolt, this.calibrationData[i - 1], this.calibrationData[i]);
                }
            }

            // this should never be reached.
            DebugLogger.Error(this.GetType().Name, "Calibration code failed.");
            throw new InvalidOperationException("Calibration code failed.");
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