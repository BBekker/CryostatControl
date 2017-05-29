// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecificDataLogger.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the SpecificDataLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.IO;

    /// <summary>
    /// Log specific data.
    /// </summary>
    public class SpecificDataLogger : AbstractDataLogger
    {
        /// <summary>
        /// The to be logged or not to be logged.
        /// </summary>
        private readonly bool[] toBeLoggedOrNotToBeLogged;

        /// <summary>
        /// The interval
        /// </summary>
        private readonly int interval;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificDataLogger"/> class.
        /// </summary>
        /// <param name="toBeLoggedOrNotToBeLogged">
        /// The to Be Logged Or Not To Be Logged.
        /// </param>
        /// <param name="interval">
        /// The interval.
        /// </param>
        public SpecificDataLogger(bool[] toBeLoggedOrNotToBeLogged, int interval)
        {  
            this.toBeLoggedOrNotToBeLogged = toBeLoggedOrNotToBeLogged;
            this.interval = interval;
        }

        /// <summary>
        /// Write specific data.
        /// </summary>
        /// <param name="pathToFile">
        /// The path To File.
        /// </param>
        /// <param name="logData">
        /// The log Data.
        /// </param>
        /// <param name="time">
        /// The time.
        /// </param>
        public void WriteSpecificData(string pathToFile, double[] logData, string time)
        {
            string dataLine = time;
            for (int i = 0; i < this.toBeLoggedOrNotToBeLogged.Length; i++)
            {
                if (this.toBeLoggedOrNotToBeLogged[i])
                {
                    dataLine += AbstractDataLogger.Delimiter + logData[i];
                }
                else
                {
                    dataLine += AbstractDataLogger.Delimiter + AbstractDataLogger.NoDataToken;
                }
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
        /// The get to be logged or not to be logged.
        /// </summary>
        /// <returns>
        /// The <see cref="bool[]"/>.
        /// </returns>
        public bool[] GetToBeLoggedOrNotToBeLogged()
        {
            return this.toBeLoggedOrNotToBeLogged;
        }

        /// <summary>
        /// The get interval.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetInterval()
        {
            return this.interval;
        }
    }
}
