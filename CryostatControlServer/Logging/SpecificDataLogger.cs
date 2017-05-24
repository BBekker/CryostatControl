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
    using System.CodeDom;
    using System.IO;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.Data;

    /// <summary>
    /// Log specific data.
    /// </summary>
    public class SpecificDataLogger : AbstractLogData
    {

        private bool[] toBeLoggedOrNotToBeLogged;


        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificDataLogger"/> class.
        /// </summary>
        public SpecificDataLogger(bool[] toBeLoggedOrNotToBeLogged)
        {  
            this.toBeLoggedOrNotToBeLogged = toBeLoggedOrNotToBeLogged;

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
                    dataLine += Delimiter + logData[i];
                }
                else
                {
                    dataLine += Delimiter + "-";
                }
                
            }
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(dataLine);
            }
        }
    }
}
