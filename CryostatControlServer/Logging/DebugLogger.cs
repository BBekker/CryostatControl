// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugLogger.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.Globalization;
    using System.IO;

    using CryostatControlServer.Properties;

    /// <summary>
    /// The debug logger.
    /// </summary>
    public static class DebugLogger 
    {
        /// <summary>
        /// The txt file format.
        /// </summary>
        private const string TxtFileFormat = ".txt";

        /// <summary>
        /// The debug information
        /// </summary>
        private const string DebugInfo = "SystemLog";

        /// <summary>
        /// The file path
        /// </summary>
        private static string filePath;

        /// <summary>
        /// Gets the general main folder.
        /// </summary>
        private static string GeneralMainFolder { get; } = Settings.Default.LoggingAddress + @"\General";

        /// <summary>
        /// Log the error in file and client notifications.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void Error(string tag, string data)
        {
            Error(tag, data, true);         
        }

        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="sendAsNotification">
        /// Send as notification.
        /// </param>
        public static void Error(string tag, string data, bool sendAsNotification)
        {
            string error = "ERROR";
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (sendAsNotification)
            {
                try
                {
                    NotificationSender.Error(time, data);
                }
                catch (NullReferenceException)
                {
                }
            }

            WriteToFile(time, error, tag, data);
        }

        /// <summary>
        /// Log the warning in file and client notifications.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        public static void Warning(string tag, string data)
        {
            Warning(tag, data, true);
        }

        /// <summary>
        /// Log the warning.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="sendAsNotification">
        /// Send as notification.
        /// </param>
        public static void Warning(string tag, string data, bool sendAsNotification)
        {
            string warning = "Warning";
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (sendAsNotification)
            {
                try
                {
                    NotificationSender.Warning(time, data);
                }
                catch (NullReferenceException)
                {
                }
            }

            WriteToFile(time, warning, tag, data);
        }

        /// <summary>
        /// Log information in file and client notifications
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        public static void Info(string tag, string data)
        {
            Info(tag, data, true);
        }

        /// <summary>
        /// Log the information.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="sendAsNotification">
        /// Send as notification.
        /// </param>
        public static void Info(string tag, string data, bool sendAsNotification)
        {
            string info = "Info";
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (sendAsNotification)
            {
                try
                {
                    NotificationSender.Info(time, data);
                }
                catch (NullReferenceException)
                {
                }
            }

            WriteToFile(time, info, tag, data);
        }

        /// <summary>
        /// Writes to file.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void WriteToFile(string time, string level, string tag, string data)
        {
            string dataLine = time + "," + tag + "," + level + ": " + data;
#if DEBUG
            Console.WriteLine(dataLine);
#endif
            if (filePath == null)
            {
               CreateFile(); 
            }

            try
            {
                using (FileStream fileStream =
                    new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.WriteLine(dataLine);
                    }
                }
            }
            catch (IOException)
            {
                try
                {
                    NotificationSender.Warning(time, "The debug log file is opened by another process. Please close this first.");
                }
                catch (NullReferenceException)
                {
                }

                Console.WriteLine("The debug log file is opened by another process. Please close this first.");
            }
        }

        /// <summary>
        /// Create folder.
        /// </summary>
        /// <param name="mainFolderPath">
        /// The main folder path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> of the folderpath.
        /// </returns>
        private static string CreateFolder(string mainFolderPath)
        {
            DateTime currentDateTime = DateTime.Now;
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
        /// Create debug logger file.
        /// </summary>
        private static void CreateFile()
        {
            DateTime currentDateTime = DateTime.Now;
            string folderPath = CreateFolder(GeneralMainFolder);
            string day = currentDateTime.Day.ToString();
            string fileName = day + "_" + DebugInfo + TxtFileFormat;
            string actualPathToFile = System.IO.Path.Combine(folderPath, fileName);
            Console.WriteLine(actualPathToFile);
            try
            {
                if (!File.Exists(actualPathToFile))
                {
                    File.Create(actualPathToFile).Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Creating debug log file failed");
            }

            filePath = actualPathToFile;
        }
    }
}
