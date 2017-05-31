// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractDataLogger.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the AbstractDataLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.IO;

    using CryostatControlServer.Data;

    /// <summary>
    /// The abstract log data.
    /// </summary>
    public abstract class AbstractDataLogger
    {

        /// <summary>
        /// The delimiter for csv files.
        /// </summary>
        protected const string Delimiter = ";";

        /// <summary>
        /// The no data token.
        /// </summary>
        protected const string NoDataToken = "-";

        /// <summary>
        /// The csv file format.
        /// </summary>
        private const string CsvFileFormat = ".csv";

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
        public string CreateFolder(DateTime currentDateTime, string mainFolderPath)
        {
            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.Month.ToString();
            string newFolderName = year + @"\" + month + @"\";
            string pathToNewFolder = System.IO.Path.Combine(mainFolderPath, newFolderName);

            try
            {
                System.IO.Directory.CreateDirectory(pathToNewFolder);
            }
            catch (Exception e)
            {
                Console.WriteLine("Creating log folder failed");
            }     
            return pathToNewFolder;
        }

        /// <summary>
        /// Create a file with the current day as name, if it does not exist yet.
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
        public string CreateFile(DateTime currentDateTime, string mainFolderPath)
        {
            string folderPath = this.CreateFolder(currentDateTime, mainFolderPath);
            string day = currentDateTime.Day.ToString();
            string fileName = day + CsvFileFormat;
            string actualPathToFile = System.IO.Path.Combine(folderPath, fileName);
            Console.WriteLine(actualPathToFile);
            try
            {
                if (!System.IO.File.Exists(actualPathToFile))
                {
                    System.IO.File.Create(actualPathToFile).Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Creating log file failed");
            }


            return actualPathToFile;
        }

        /// <summary>
        /// Write initial line containing headers.
        /// </summary>
        /// <param name="pathToFile">
        /// The path to file.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        public void WriteInitialLine(string pathToFile, bool[] devices)
        {
            FileInfo fileInfo = new FileInfo(pathToFile);
            if (fileInfo.Length > 0)
            {
                return;
            }
            string initialLine = "Time";
            for (int i = 0; i < devices.Length; i++)
            {
                initialLine += Delimiter + this.GetDeviceName(i);
            }

            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(initialLine);
            }
        }

        /// <summary>
        /// The get device name.
        /// </summary>
        /// <param name="dataNumber">
        /// The data number.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDeviceName(int dataNumber)
        {
            string info = string.Empty;
            switch (dataNumber)
            {
                case (int)DataEnumerator.LakePlate50K:
                    info = "50K Shield";
                    break;
                case (int)DataEnumerator.LakePlate3K:
                    info = "3K Shield";
                    break;
                case (int)DataEnumerator.ComWaterIn:
                    info = "Compressor water in";
                    break;
                case (int)DataEnumerator.ComWaterOut:
                    info = "Compressor water out";
                    break;
                case (int)DataEnumerator.ComHelium:
                    info = "Compressor helium";
                    break;
                case (int)DataEnumerator.ComOil:
                    info = "Compressor oil";
                    break;
                case (int)DataEnumerator.ComLow:
                    info = "Compressor low pressure";
                    break;
                case (int)DataEnumerator.ComLowAvg:
                    info = "Compressor low avg pressure";
                    break;
                case (int)DataEnumerator.ComHigh:
                    info = "Compressor high pressure";
                    break;
                case (int)DataEnumerator.ComHighAvg:
                    info = "Compressor high avg pressure";
                    break;
                case (int)DataEnumerator.He3Pump:
                    info = "He3 Pump";
                    break;
                case (int)DataEnumerator.HePlate2K:
                    info = "He 2K Plate";
                    break;
                case (int)DataEnumerator.HePlate4K:
                    info = "He 4K Plate";
                    break;
                case (int)DataEnumerator.He3Head:
                    info = "He3 Head";
                    break;
                case (int)DataEnumerator.He4Pump:
                    info = "He4 Pump";
                    break;
                case (int)DataEnumerator.He4SwitchTemp:
                    info = "He4 Switch Temperature";
                    break;
                case (int)DataEnumerator.He3SwitchTemp:
                    info = "He3 Switch Temperature";
                    break;
                case (int)DataEnumerator.He4Head:
                    info = "He4 Head";
                    break;
                case (int)DataEnumerator.He3VoltActual:
                    info = "He3 Volt";
                    break;
                case (int)DataEnumerator.He4SwitchVoltActual:
                    info = "He4 Switch Volt";
                    break;
                case (int)DataEnumerator.He3SwitchVoltActual:
                    info = "He3 Switch Volt";
                    break;
                case (int)DataEnumerator.He4VoltActual:
                    info = "He4 Volt";
                    break;
                case (int)DataEnumerator.HeConnectionState:
                    info = "He Connection State";
                    break;
                case (int)DataEnumerator.ComConnectionState:
                    info = "Compressor Connection State";
                    break;
                case (int)DataEnumerator.LakeConnectionState:
                    info = "LakeShore Connection State";
                    break;
                case (int)DataEnumerator.ComError:
                    info = "Compressor Error";
                    break;
                case (int)DataEnumerator.ComWarning:
                    info = "Compressor Warning";
                    break;
                case (int)DataEnumerator.ComHoursOfOperation:
                    info = "Compressor hours of operation";
                    break;
                case (int)DataEnumerator.LakeHeater:
                    info = "LakeShore Heater";
                    break;

            }

            return info;
        }

    }
}
