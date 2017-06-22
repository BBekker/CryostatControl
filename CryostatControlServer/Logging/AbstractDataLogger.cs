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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
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
        /// The csv file format.
        /// </summary>
        protected const string CsvFileFormat = ".csv";

        /// <summary>
        /// The amount of digits for logging.
        /// </summary>
        protected const int Amountdigits = 3;

        /// <summary>
        /// The device dictionary.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1013:ClosingCurlyBracketsMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1012:OpeningCurlyBracketsMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private static readonly Dictionary<int, string> DeviceDictionary = new Dictionary<int, string>()
                                                                  {
                                                                      {(int) DataEnumerator.LakePlate50K, "50K Plate"},
                                                                      {(int) DataEnumerator.LakePlate3K, "3K Plate"},
                                                                      {(int) DataEnumerator.ComWaterIn, "Compressor water in"},
                                                                      {(int) DataEnumerator.ComWaterOut, "Compressor water out"},
                                                                      {(int) DataEnumerator.ComHelium, "Compressor helium"},
                                                                      {(int) DataEnumerator.ComOil, "Compressor oil"},
                                                                      {(int) DataEnumerator.ComLow, "Compressor low pressure"},
                                                                      {(int) DataEnumerator.ComLowAvg, "Compressor low avg pressure"},
                                                                      {(int) DataEnumerator.ComHigh, "Compressor high pressure"},
                                                                      {(int) DataEnumerator.ComHighAvg, "Compressor high avg pressure"},
                                                                      {(int) DataEnumerator.ComDeltaAvg, "Compressor delta avg pressure"},
                                                                      {(int) DataEnumerator.He3Pump, "He3 Pump"},
                                                                      {(int) DataEnumerator.HePlate2K, "He 2K Plate"},
                                                                      {(int) DataEnumerator.HePlate4K, "He 4K Plate"},
                                                                      {(int) DataEnumerator.He3Head, "He3 Head"},
                                                                      {(int) DataEnumerator.He4Pump, "He4 Pump"},
                                                                      {(int) DataEnumerator.He4SwitchTemp, "He4 Switch Temperature"},
                                                                      {(int) DataEnumerator.He3SwitchTemp, "He3 Switch Temperature"},
                                                                      {(int) DataEnumerator.He4Head, "He4 Head"},
                                                                      {(int) DataEnumerator.He3VoltActual, "He3 Volt"},
                                                                      {(int) DataEnumerator.He4SwitchVoltActual, "He4 Switch Volt"},
                                                                      {(int) DataEnumerator.He3SwitchVoltActual, "He3 Switch Volt"},
                                                                      {(int) DataEnumerator.He4VoltActual, "He4 Volt"},
                                                                      {(int) DataEnumerator.HeConnectionState, "He Connection State"},
                                                                      {(int) DataEnumerator.ComConnectionState, "Compressor Connection State"},
                                                                      {(int) DataEnumerator.LakeConnectionState, "LakeShore Connection State"},
                                                                      {(int) DataEnumerator.ComError, "Compressor Error"},
                                                                      {(int) DataEnumerator.ComWarning, "Compressor Warning"},
                                                                      {(int) DataEnumerator.ComHoursOfOperation, "Compressor hours of operation"},
                                                                      {(int) DataEnumerator.ComOperationState, "Compressor Opertating State"},
                                                                  };

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
            if (DeviceDictionary.ContainsKey(dataNumber))
            {
                return DeviceDictionary[dataNumber];
            }

            return string.Empty;
        }
    }
}