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
    using System.IO;

    using CryostatControlServer.Data;

    /// <summary>
    /// The log all data.
    /// </summary>
    public class GeneralDataLogger : AbstractDataLogger
    {
        /// <summary>
        /// Write general data to log.
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
                    dataLine += AbstractDataLogger.Delimiter + data[i];
            }

            try
            {
                using (FileStream fileStream =
                    new FileStream(pathToFile, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.WriteLine(dataLine);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("The log file is opened by another process. Please close this first.");
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
