// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReader.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer.Data
{
    using System;

    /// <summary>
    /// Class which returns a array filled with data according to <seealso cref="DataEnumerator"/>
    /// </summary>
    public class DataReader
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
        /// Initializes a new instance of the <see cref="DataReader" /> class.
        /// </summary>
        /// <param name="compressor">The compressor.</param>
        /// <param name="he7Cooler">The he7 cooler.</param>
        /// <param name="lakeShore">The lake shore.</param>
        public DataReader(
            Compressor.Compressor compressor,
            He7Cooler.He7Cooler he7Cooler,
            LakeShore.LakeShore lakeShore)
        {
            this.compressor = compressor;
            this.sensors = new SensorArray(this.compressor, he7Cooler, lakeShore).getSensorArray();
        }

        /// <summary>
        /// Fills data array with mock values, then it calls the methods which actually fill the array with data.
        /// </summary>
        /// <returns>array filled with available data</returns>
        public double[] GetDataArray()
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