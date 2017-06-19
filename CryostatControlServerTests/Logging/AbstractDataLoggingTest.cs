using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Logging
{
    using System.IO;
    using System.Linq;

    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;

    [TestClass]
    public class AbstractDataLoggingTest
    {
        [TestMethod]
        public void WriteInitialLineTest()
        {
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();
            bool[] toBeLogged = generalDataLogger.CreateArrayWithOnlyTrue();
            string filePath = "SpecificDataLoggerTest.csv";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();

            generalDataLogger.WriteInitialLine(filePath,toBeLogged);
            string line = File.ReadLines(filePath).First();
            string[] elements = line.Split(';');

            Assert.AreEqual("Time", elements[0]);
            Assert.AreEqual("Compressor helium", elements[(int)DataEnumerator.ComHelium + 1]);
            Assert.AreEqual("He3 Switch Temperature", elements[(int)DataEnumerator.He3SwitchTemp + 1]);
        }
    }
}
