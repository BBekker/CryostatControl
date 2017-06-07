﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReader.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer.Data
{
    using System;

    using CryostatControlServer.Logging;

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

        /// <summary>
        /// The he7 cooler
        /// </summary>
        private readonly He7Cooler.He7Cooler he7Cooler;

        /// <summary>
        /// The lake shore
        /// </summary>
        private readonly LakeShore.LakeShore lakeShore;

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
            this.he7Cooler = he7Cooler;
            this.lakeShore = lakeShore;
            this.sensors = new SensorArray(this.compressor, he7Cooler, lakeShore).GetSensorArray();
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

            this.FillConnectionData(data);
            this.FillDataWithSensor(data);
            this.FillCompressorData(data);

            if (!this.he7Cooler.IsConnected())
            {
                for (int i = 10; i < (int)DataEnumerator.SensorAmount; i++)
                {
                    data[i] = float.NaN;
                }
            }
            this.FillWithMockData(data);

            return data;
        }

        /// <summary>
        /// Reads the single sensor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Value of the sensor, if something went wrong NaN</returns>
        public double ReadSingleSensor(int id)
        {
            if (id < 0 && id >= (int)DataEnumerator.DataLength)
            {
                return double.NaN;
            }

            if (id < (int)DataEnumerator.SensorAmount)
            {
                return this.ReadSensor(id);
            }

            return this.ReadFromSwitch(id);
        }

        /// <summary>
        /// Reads from switch.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Value of the sensor, if something went wrong NaN</returns>
        private double ReadFromSwitch(int id)
        {
            try
            {
                switch (id)
                {
                    case (int)DataEnumerator.HeConnectionState: return Convert.ToDouble(this.he7Cooler.IsConnected());
                    case (int)DataEnumerator.ComConnectionState: return Convert.ToDouble(this.compressor.IsConnected());
                    case (int)DataEnumerator.LakeConnectionState:
                        {
                            if (this.lakeShore != null)
                            {
                                return Convert.ToDouble(this.lakeShore.OPC());
                            }

                            return 0;
                        }

                    case (int)DataEnumerator.ComError: return (double)this.compressor.ReadErrorState();
                    case (int)DataEnumerator.ComWarning: return (double)this.compressor.ReadWarningState();
                    case (int)DataEnumerator.ComHoursOfOperation: return (double)this.compressor.ReadHoursOfOperation();
                    case (int)DataEnumerator.ComOperationState: return (double)this.compressor.ReadOperatingState();
                    default: return double.NaN;
                }
            }
            catch
            {
                return double.NaN;
            }
        }

        /// <summary>
        /// Fills the data array with sensor data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void FillDataWithSensor(double[] data)
        {
            for (int i = 0; i < (int)DataEnumerator.SensorAmount; i++)
            {
                try
                {
                    data[i] = this.sensors[i].Value;
                }
                catch (Exception)
                {
                    data[i] = float.NaN;
////                   Console.WriteLine("Could not read sensor" + i);
                }
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
                data[(int)DataEnumerator.ComOperationState] = (double)this.compressor.ReadOperatingState();
            }
            catch (Exception)
            {
                data[(int)DataEnumerator.ComError] = float.NaN;
                data[(int)DataEnumerator.ComWarning] = float.NaN;
                data[(int)DataEnumerator.ComHoursOfOperation] = float.NaN;
                data[(int)DataEnumerator.ComOperationState] = float.NaN;
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

        /// <summary>
        /// Reads the sensor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Value of the sensor, if something went wrong NaN is returned</returns>
        private double ReadSensor(int id)
        {
            try
            {
                return this.sensors[id].Value;
            }
            catch
            {
                return double.NaN;
            }
        }

        /// <summary>
        /// Fills the connection data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void FillConnectionData(double[] data)
        {
                data[(int)DataEnumerator.ComConnectionState] = Convert.ToDouble(this.compressor.IsConnected());
            data[(int)DataEnumerator.HeConnectionState] = Convert.ToDouble(this.he7Cooler.IsConnected());
            if (this.lakeShore != null)
            {
                data[(int)DataEnumerator.LakeConnectionState] = Convert.ToDouble(this.lakeShore.OPC());
            }
            else
            {
                data[(int)DataEnumerator.LakeConnectionState] = 0;
            }
        }

        #endregion Methods
    }
}