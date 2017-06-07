﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Globalization;
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
        protected const string CsvFileFormat = ".csv";

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractDataLogger"/> class.
        /// </summary>
        public AbstractDataLogger()
        {
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
        public virtual string CreateFolder(DateTime currentDateTime, string mainFolderPath)
        {
            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.ToString("MMMM", new CultureInfo("en-US"));
            string newFolderName = year + @"\" + month + @"\";
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
        public virtual string CreateFile(string mainFolderPath)
        {
            DateTime currentDateTime = DateTime.Now;
            string folderPath = this.CreateFolder(currentDateTime, mainFolderPath);
            string day = currentDateTime.Day.ToString();
            string fileName = day + CsvFileFormat;
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

        /// <summary>
        /// Write initial line containing headers.
        /// </summary>
        /// <param name="pathToFile">
        /// The path to file.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        /// <param name="isGeneralLogging">
        /// The general Log.
        /// </param>
        public void WriteInitialLine(string pathToFile, bool[] devices, bool isGeneralLogging)
        {
            FileInfo fileInfo = new FileInfo(pathToFile);
            if (fileInfo.Length > 0)
            {
                return;
            }

            string initialLine = "Time";

            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i])
                {
                    initialLine += Delimiter + this.GetDeviceName(i);
                }
            }

            if (isGeneralLogging)
            {
                initialLine += Delimiter + "ControllerState";
            }
            
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(initialLine);
            }
        }

        /// <summary>
        /// The write initial line without control state header.
        /// </summary>
        /// <param name="pathToFile">
        /// The path to file.
        /// </param>
        /// <param name="devices">
        /// The devices.
        /// </param>
        public void WriteInitialLine(string pathToFile, bool[] devices)
        {
            this.WriteInitialLine(pathToFile, devices, false);
        }

        /// <summary>
        /// Get the device name.
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
                    info = "50K Plate";
                    break;
                case (int)DataEnumerator.LakePlate3K:
                    info = "3K Plate";
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
                case (int)DataEnumerator.ComDeltaAvg:
                    info = "Compressor delta avg pressure";
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
                case (int)DataEnumerator.ComOperationState:
                    info = "Compressor Opertating State";
                    break;
                case (int)DataEnumerator.LakeHeater:
                    info = "LakeShore Heater";
                    break;
            }

            return info;
        }
    }
}