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
    using System.Globalization;
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
                    dataLine += AbstractDataLogger.Delimiter + Math.Round(logData[i], 3);
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
                DebugLogger.Warning(this.GetType().Name, "The specific log file is opened by another process. Please close this first.");
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

        /// <summary>
        /// Create specific folder.
        /// </summary>
        /// <param name="currentDateTime">
        /// The current Date Time.
        /// </param>
        /// <param name="mainFolderPath">
        /// The main Folder Path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string CreateFolder(DateTime currentDateTime, string mainFolderPath)
        {
            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.ToString("MMMM", new CultureInfo("en-US"));
            string day = currentDateTime.Day.ToString();
            string newFolderName = year + @"\" + month + @"\" + day + @"\";
            string pathToNewFolder = Path.Combine(mainFolderPath, newFolderName);

            try
            {
                Directory.CreateDirectory(pathToNewFolder);
            }
            catch (Exception)
            {
                Console.WriteLine("Creating log folder failed");
            }

            return pathToNewFolder;
        }

        /// <summary>
        /// Create a file with the current day as name, if it does not exist yet.
        /// </summary>
        /// <param name="mainFolderPath">
        /// The main Folder Path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string CreateFile(string mainFolderPath)
        {
            DateTime currentDateTime = DateTime.Now;
            string folderPath = this.CreateFolder(currentDateTime, mainFolderPath);
            string time = currentDateTime.ToString("HH_mm_ss");
            string fileName = time + AbstractDataLogger.CsvFileFormat;
            string actualPathToFile = Path.Combine(folderPath, fileName);

            try
            {
                if (!File.Exists(actualPathToFile))
                {
                    File.Create(actualPathToFile).Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Creating log file failed");
            }

            return actualPathToFile;
        }
    }
}
