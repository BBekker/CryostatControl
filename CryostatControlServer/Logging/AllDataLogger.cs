// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllDataLogger.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the AllDataLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.Data;

    using CryostatControlServer.Data;

    /// <summary>
    /// The log all data.
    /// </summary>
    public class AllDataLogger : AbstractLogData
    {
        private DataReader dataReader;

        public AllDataLogger(DataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        /// <summary>
        /// Write all data to log.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public void WriteAllData(string path)
        {
            double[] data = this.dataReader.GetDataArray();
            bool[] toBeLoggedOrNotToBeLogged = this.CreateArrayWithOnlyTrue();
            this.WriteInitialLine(path, toBeLoggedOrNotToBeLogged);
            this.WriteDataToFile(path, data);
        }

        /// <summary>
        /// The create array with only true.
        /// </summary>
        /// <returns>
        /// The <see cref="bool[]"/>.
        /// </returns>
        public bool[] CreateArrayWithOnlyTrue()
        {
            bool[] devices = new bool[(int)DataEnumerator.DataLength];
            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = true;
            }
            return devices;
        }
    }
}
