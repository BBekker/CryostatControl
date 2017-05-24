// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneralDataLogger.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the GeneralDataLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.Data;
    using System.IO;

    using CryostatControlServer.Data;

    /// <summary>
    /// The log all data.
    /// </summary>
    public class GeneralDataLogger : AbstractLogData
    {

        public GeneralDataLogger()
        {
        }

        /// <summary>
        /// Write all data to log.
        /// </summary>
        /// <param name="pathToFile">
        /// The path To File.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="time">
        /// The time.
        /// </param>
        public void WriteGeneralData(string pathToFile, double[] data, string time)
        {
            string dataLine = time;
            for (int i = 0; i < data.Length; i++)
            {
                    dataLine += Delimiter + data[i];
            }
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(dataLine);
            }
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
