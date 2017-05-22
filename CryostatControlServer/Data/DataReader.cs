// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReadOut.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer.Data
{
    using System;

    /// <summary>
    /// Class which returns a array filled with data according to <seealso cref="DataEnumerator"/>
    /// </summary>
    public class DataReadOut
    {
        #region Fields

        /// <summary>
        /// The sensors
        /// </summary>
        private readonly ISensor[] sensors;

        private readonly Compressor.Compressor compressor;

        private readonly He7Cooler.He7Cooler he7Cooler;

        private readonly LakeShore.LakeShore lakeShore;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReadOut" /> class.
        /// </summary>
        /// <param name="compressor">The compressor.</param>
        /// <param name="sensors">The sensors.</param>
        public DataReadOut(
            Compressor.Compressor compressor,
            He7Cooler.He7Cooler he7Cooler,
            LakeShore.LakeShore lakeShore)
        {
            this.compressor = compressor;
            this.he7Cooler = he7Cooler;
            this.lakeShore = lakeShore;
            this.sensors = new SensorArray(this.compressor, this.he7Cooler, this.lakeShore).getSensorArray();
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

            try
            {
                this.FillDataWithSensor(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("Sensor data could not be filled");
#if DEBUG
                Console.WriteLine("thrown exception: {0}", e);
#endif
            }

            try
            {
                this.FillCompressorData(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("Compressor data could not be filled");
#if DEBUG
                Console.WriteLine("thrown exception: {0}", e);
#endif
            }

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
            data[(int)DataEnumerator.ComError] = (double)this.compressor.ReadErrorState();
            data[(int)DataEnumerator.ComWarning] = (double)this.compressor.ReadWarningState();
            data[(int)DataEnumerator.ComHoursOfOperation] = (double)this.compressor.ReadHoursOfOperation();
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