using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Logging
{
    using System.IO;
    using System.Linq;

    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;

    [TestClass]
    public class SpecificDataLoggingTest
    {
        [TestMethod]
        public void WriteSpecificDataToBeLoggedIsTrueTest()
        {
            int interval = 5;
            bool[] toBeLogged = new bool[(int)DataEnumerator.DataLength];
            toBeLogged[(int)DataEnumerator.ComHelium] = true;
            toBeLogged[(int)DataEnumerator.He3SwitchTemp] = true;
            SpecificDataLogger specificDataLogging = new SpecificDataLogger(toBeLogged, interval);

            string filePath = "SpecificDataLoggerTest.csv";
            double[] logData = new double[(int)DataEnumerator.DataLength];
            logData[(int)DataEnumerator.ComHelium] = 20;
            logData[(int)DataEnumerator.He3SwitchTemp] = 40;
            string time = DateTime.Now.ToString("HH:mm:ss");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(filePath).Close();

            specificDataLogging.WriteSpecificData(filePath, logData, time);
            string line = File.ReadLines(filePath).First();
            string[] elements = line.Split(';');

            Assert.AreEqual("20", elements[(int)DataEnumerator.ComHelium > (int)DataEnumerator.He3SwitchTemp ? 2 :1]);
            Assert.AreEqual("40", elements[(int)DataEnumerator.ComHelium < (int)DataEnumerator.He3SwitchTemp ? 2 : 1]);

        }

        [TestMethod]
        public void WriteSpecificDataToBeLoggedIsFalseTest()
        {
            int interval = 5;
            bool[] toBeLogged = new bool[(int)DataEnumerator.DataLength];
            toBeLogged[(int)DataEnumerator.ComHelium] = false;
            toBeLogged[(int)DataEnumerator.He3SwitchTemp] = false;
            toBeLogged[(int)DataEnumerator.LakePlate50K] = false;
            SpecificDataLogger specificDataLogging = new SpecificDataLogger(toBeLogged, interval);

            string filePath = "SpecificDataLoggerTest.csv";
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

            specificDataLogging.WriteSpecificData(filePath, logData, time);
            string line = File.ReadLines(filePath).First();
            string[] elements = line.Split(';');

            Assert.AreEqual(1, elements.Length);
            Assert.AreEqual(time, elements[0]);

        }
    }
}
