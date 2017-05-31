// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugLogger.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the DebugLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.IO;
    using System.Text;

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
        private const string DebugInfo = "DebugInfo";

        /// <summary>
        /// The general main folder.
        /// </summary>
        private const string GeneralMainFolder = @"c:\CryostatLogging\General";

        /// <summary>
        /// The file path
        /// </summary>
        private static string filePath;

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void Error(string tag, string data)
        {
            string error = "ERROR";
            WriteToFile(error, tag, data);
            
        }

        /// <summary>
        /// Warnings the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        public static void Warning(string tag, string data)
        {
            string warning = "Warning";
            WriteToFile(warning, tag, data);

        }

        /// <summary>
        /// Informations the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        public static void Info(string tag, string data)
        {
            string info = "Info";
            WriteToFile(info, tag, data);

        }

        /// <summary>
        /// Writes to file.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        public static void WriteToFile(string level, string tag, string data)
        {
            if (filePath == null)
            {
               CreateFile(); 
            }
            StringBuilder sb = new StringBuilder();
            string dataLine = DateTime.Now.ToString("HH:mm:ss") + "," + tag + "," + level + ": " + data;

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
                Console.WriteLine("The debug log file is opened by another process. Please close this first.");
            }
        }

        /// <summary>
        /// The create folder.
        /// </summary>
        /// <param name="mainFolderPath">
        /// The main folder path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string CreateFolder(string mainFolderPath)
        {
            DateTime currentDateTime = DateTime.Now;
            string year = currentDateTime.Year.ToString();
            string month = currentDateTime.Month.ToString();
            string newFolderName = year + @"\" + month + @"\";
            string pathToNewFolder = System.IO.Path.Combine(mainFolderPath, newFolderName);

            try
            {
                System.IO.Directory.CreateDirectory(pathToNewFolder);
            }
            catch (Exception)
            {
                Console.WriteLine("Creating log folder failed");
            }

            return pathToNewFolder;
        }

        /// <summary>
        /// The create file.
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
                if (!System.IO.File.Exists(actualPathToFile))
                {
                    System.IO.File.Create(actualPathToFile).Close();
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
