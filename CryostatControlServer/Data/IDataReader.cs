// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataReader.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The DataReader interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Data
{
    /// <summary>
    /// The DataReader interface.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Fills data array with mock values, then it calls the methods which actually fill the array with data.
        /// </summary>
        /// <returns>array filled with available data</returns>
        double[] GetDataArray();

        /// <summary>
        /// Fills the data array with sensor data.
        /// </summary>
        /// <param name="data">The data.</param>
        void FillDataWithSensor(double[] data);

        /// <summary>
        /// Fills the data array with compressor data which cannot be read with the sensor interface.
        /// </summary>
        /// <param name="data">The data.</param>
        void FillCompressorData(double[] data);

        /// <summary>
        /// Fills the data array with mock data.
        /// </summary>
        /// <param name="data">The data.</param>
        void FillWithMockData(double[] data);

        /// <summary>
        /// Fills the connection data.
        /// </summary>
        /// <param name="data">The data.</param>
        void FillConnectionData(double[] data);
    }
}