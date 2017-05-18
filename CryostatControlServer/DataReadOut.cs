// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReadOut.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    using System;
    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// Class which returns the data required for the GUI by the client.
    /// </summary>
    public class DataReadOut
    {
        #region Fields

        /// <summary>
        /// The sensors
        /// </summary>
        private readonly ISensor[] sensors;

        /// <summary>
        /// The compressor
        /// </summary>
        private readonly Compressor.Compressor compressor;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReadOut" /> class.
        /// </summary>
        /// <param name="compressor">The compressor.</param>
        /// <param name="sensors">The sensors.</param>
        /// <param name="heaters">The heaters.</param>
        public DataReadOut(
            Compressor.Compressor compressor,
            ISensor[] sensors)
        {
            this.compressor = compressor;
            this.sensors = sensors;
        }

        /// <summary>
        /// Fills data array with mock values, then it calls the methods which actually fill the array with data.
        /// </summary>
        /// <returns>array filled with available data</returns>
        public double[] FillData()
        {
            double[] data = new double[(int)DataEnumerator.DataLength];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = double.MinValue;
            }
            ////this.FillDataWithSensor(data);
            ////this.FillCompressorData(data);
            this.FillWithMockData(data);
            return data;
        }

        /// <summary>
        /// Fills the data array with sensor data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void FillDataWithSensor(double[] data)
        {
            for (int i = 0; i < (int)DataEnumerator.SensorAmount; i++)
            {
                data[i] = this.sensors[i].Value;
            }
        }

        /// <summary>
        /// Fills the data array with compressor data which cannot be read with the sensor interface.
        /// </summary>
        /// <param name="data">The data.</param>
        private void FillCompressorData(double[] data)
        {
            try
            {
                data[(int)DataEnumerator.ComError] = (double)this.compressor.ReadErrorState();
                data[(int)DataEnumerator.ComWarning] = (double)this.compressor.ReadWarningState();
                data[(int)DataEnumerator.ComHoursOfOperation] = (double)this.compressor.ReadHoursOfOperation();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the compressor");

                ////todo handle exception
            }
        }

        /// <summary>
        /// Fills the data array with mock data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void FillWithMockData(double[] data)
        {
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.NextDouble();
            }
        }

        #endregion Methods
    }
}