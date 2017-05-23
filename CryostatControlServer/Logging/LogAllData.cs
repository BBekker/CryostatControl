// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogAllData.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LogAllData type.
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
    public class LogAllData : AbstractLogData
    {
        private DataReader dataReader;

        public LogAllData(DataReader dataReader)
        {
            this.dataReader = dataReader;

            DateTime localDate = DateTime.Now;
            string year = localDate.Year.ToString();
            string month = localDate.Month.ToString();
            string day = localDate.Day.ToString();

            string folderPath = this.CreateFolder(year, month);
            string filePath = this.CreateFile(folderPath, day);
            this.WriteAllData(filePath);
        }

        /// <summary>
        /// Create general folder.
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
            string mainFolderPath = @"c:/Logging/General";
            string newFolderName = year + "/" + month + "/";
            string pathToNewFolder = System.IO.Path.Combine(mainFolderPath, newFolderName);

            System.IO.Directory.CreateDirectory(pathToNewFolder);
            return pathToNewFolder;
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
            double[] devices = new double[(int)DataEnumerator.DataLength];
            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = 1;
            }
            this.WriteInitialLine(path, devices);
            this.WriteDataToFile(path, data);
        }
    }
}
