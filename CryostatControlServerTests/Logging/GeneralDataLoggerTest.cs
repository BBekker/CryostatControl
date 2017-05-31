using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Logging
{
    using System.IO;
    using System.Linq;

    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;

    using Moq;

    [TestClass]
    public class GeneralDataLoggerTest
    {
        [TestMethod]
        public void CreateArrayWithOnlyTrueTest()
        {
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();
            bool[] devices = generalDataLogger.CreateArrayWithOnlyTrue();
            for (int i = 0; i < devices.Length; i++)
            {
                Assert.IsTrue(devices[i]);
            }
        }

        [TestMethod]
        public void WriteGeneralDataTest()
        {
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();
            string filePath = "GeneralDataLoggerTest.csv";
            double[] logData = new double[(int)DataEnumerator.DataLength];
            logData[(int)DataEnumerator.ComHelium] = 20;
            logData[(int)DataEnumerator.He3SwitchTemp] = 40;
            logData[(int)DataEnumerator.LakePlate50K] = 1;
            string time = DateTime.Now.ToString("HH:mm:ss");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();

            generalDataLogger.WriteGeneralData(filePath, logData, time);
            string line = File.ReadLines(filePath).First();
            string[] elements = line.Split(';');

            Assert.AreEqual("20", elements[(int)DataEnumerator.ComHelium + 1]);
            Assert.AreEqual("40", elements[(int)DataEnumerator.He3SwitchTemp + 1]);
            Assert.AreEqual("1", elements[(int)DataEnumerator.LakePlate50K + 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void WriteGeneralDataExceptionTest()
        {
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();
            string filePath = "GeneralDataLoggerTest.csv";
            double[] logData = new double[(int)DataEnumerator.DataLength];
            logData[(int)DataEnumerator.ComHelium] = 20;
            logData[(int)DataEnumerator.He3SwitchTemp] = 40;
            logData[(int)DataEnumerator.LakePlate50K] = 1;
            string time = DateTime.Now.ToString("HH:mm:ss");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath);

            generalDataLogger.WriteGeneralData(filePath, logData, time);
            string line = File.ReadLines(filePath).First();
            string[] elements = line.Split(';');

            Assert.AreEqual("20", elements[(int)DataEnumerator.ComHelium + 1]);
            Assert.AreEqual("40", elements[(int)DataEnumerator.He3SwitchTemp + 1]);
            Assert.AreEqual("1", elements[(int)DataEnumerator.LakePlate50K + 1]);
        }
    }
}
