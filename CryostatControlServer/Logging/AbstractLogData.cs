// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractLogData.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the AbstractLogData type.
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
    public abstract class AbstractLogData
    {

        /// <summary>
        /// The max trials creating logfile.
        /// </summary>
        private const int MaxTrialsCreatingLogfile = 100;

        /// <summary>
        /// The initial addition number for duplicate files.
        /// </summary>
        private const int InitialAdditionNumberForDuplicateFiles = 1;

        /// <summary>
        /// The delimiter for csv files.
        /// </summary>
        private const string Delimiter = ";";

        /// <summary>
        /// Create specific folder.
        /// </summary>
        /// <param name="currentDateTime">
        /// The current Date Time.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateFolder(DateTime currentDateTime)
        {
            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.Month.ToString();
            string mainFolderPath = @"c:/Logging/Specific";
            string newFolderName = year + "/" + month + "/";
            string pathToNewFolder = System.IO.Path.Combine(mainFolderPath, newFolderName);

            System.IO.Directory.CreateDirectory(pathToNewFolder);
            return pathToNewFolder;
        }

        /// <summary>
        /// Create a file.
        /// </summary>
        /// <param name="folderPath">
        /// The folder path.
        /// </param>
        /// <param name="currentDateTime">
        /// The current Date Time.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateFile(DateTime currentDateTime)
        {
            string folderPath = this.CreateFolder(currentDateTime);
            string day = currentDateTime.Day.ToString();
            string fileName = day + ".csv";
            string actualPathToFile = System.IO.Path.Combine(folderPath, fileName);

            int count = InitialAdditionNumberForDuplicateFiles;
            while (System.IO.File.Exists(actualPathToFile))
            {
                fileName = day + "(" + count.ToString() + ")" + ".csv";
                actualPathToFile = System.IO.Path.Combine(folderPath, fileName);
                count++;
                if (count == MaxTrialsCreatingLogfile)
                {
                    Console.WriteLine("Error writing logfile. To many files created.");
                    return null;
                }
            }

            System.IO.File.Create(actualPathToFile).Close();

            return actualPathToFile;
        }

        /// <summary>
        /// Write data to a file.
        /// </summary>
        /// <param name="pathToFile">
        /// The path to file.
        /// </param>
        /// <param name="logData">
        /// The log data.
        /// </param>
        public void WriteDataToFile(string pathToFile, double[] logData)
        {
            string currentTime = DateTime.Now.ToString("hh:mm:ss");
            string lineToWrite = currentTime;

            foreach (var deviceData in logData)
            {
                lineToWrite += Delimiter + deviceData;
            }
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(lineToWrite);
            }
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
        public void WriteInitialLine(string pathToFile, double[] devices)
        {
            string initialLine = "Time";
            for (int i = 0; i < devices.Length; i++)
            {
                if ((int)devices[i] == 1)
                {
                    initialLine += Delimiter + this.GetDocumentationInfo(i);
                }
                
            }
            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine(initialLine);
            }
        }

        public string GetDocumentationInfo(int dataNumber)
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
