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

        private double[] toBeLoggedOrNotToBeLogged;


        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificDataLogger"/> class.
        /// </summary>
        public SpecificDataLogger(DataReader dataReader, double[] toBeLoggedOrNotToBeLogged)
        {
            DateTime localDate = DateTime.Now;
            string year = localDate.Year.ToString();
            string month = localDate.Month.ToString();
            string day = localDate.Day.ToString();

            string folderPath = this.CreateFolder(year, month);
            string filePath = this.CreateFile(folderPath, day);
            this.toBeLoggedOrNotToBeLogged = toBeLoggedOrNotToBeLogged;

        }

        /// <summary>
        /// The create folder.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public new string CreateFolder(string year, string month)
        {
            string mainFolderPath = @"c:/Logging/Specific";
            string newFolderName = year + "/" + month + "/";
            string pathToNewFolder = System.IO.Path.Combine(mainFolderPath, newFolderName);

            System.IO.Directory.CreateDirectory(pathToNewFolder);
            return pathToNewFolder;
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
