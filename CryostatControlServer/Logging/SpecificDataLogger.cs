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
        public SpecificDataLogger(DataReader dataReader, bool[] toBeLoggedOrNotToBeLogged)
        {  
            this.toBeLoggedOrNotToBeLogged = toBeLoggedOrNotToBeLogged;

        }

        /// <summary>
        /// Write specific data.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="toBeLoggedOrNotToBeLogged">
        /// The to be logged or not to be logged.
        /// </param>
        public void WriteSpecificData(string path, double[] obj)
        {
            this.WriteInitialLine(path, toBeLoggedOrNotToBeLogged);
            this.WriteDataToFile(path, obj);
        }
    }
}
