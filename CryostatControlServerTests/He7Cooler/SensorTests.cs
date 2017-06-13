namespace CryostatControlServerTests.He7Cooler
{
    using System;
    using System.Globalization;
    using System.Threading;

    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.Streams;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The sensor tests.
    /// </summary>
    [TestClass]
    public class SensorTests
    {
        [TestMethod]
        public void TestCalibration()
        {
            Calibration testSensor = new Calibration();

            Assert.AreEqual(100.0, testSensor.ConvertValue(100.0));

            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(0, 0));
            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(100.0, 100.0));

            Assert.AreEqual(10.0, testSensor.ConvertValue(10.0));
            Assert.AreEqual(0.0, testSensor.ConvertValue(0.0));
            Assert.AreEqual(100.0, testSensor.ConvertValue(100.0));
            Assert.AreEqual(100.0, testSensor.ConvertValue(200.0));
            Assert.AreEqual(0.0, testSensor.ConvertValue(-1.0));

            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(50.0, 80.0));

            Assert.AreEqual(40.0, testSensor.ConvertValue(25.0));
            Assert.AreEqual(80.0, testSensor.ConvertValue(50.0));
            Assert.AreEqual(90.0, testSensor.ConvertValue(75.0));
        }


        [TestMethod]
        public void TestReadingCalibration()
        {
            var testSensor = Calibration.He4Calibration;
            Assert.AreEqual(149, testSensor.CalibrationSize);
            Assert.AreEqual(35.0, testSensor.ConvertValue(0.2133), 0.01);
            Assert.AreEqual(0.1, testSensor.ConvertValue(3.9229), 0.01);
            Assert.AreEqual(0.099, testSensor.ConvertValue(3.99), 0.001);

            Calibration testSensor2 = new Calibration();
            testSensor2.LoadSensorCalibrationFromFile("..\\..\\DIODE.CAL", 1, 0);
            Assert.AreEqual(142, testSensor2.CalibrationSize);
            Assert.AreEqual(300.0, testSensor2.ConvertValue(0.57), 0.1);
            Assert.AreEqual(17.5, testSensor2.ConvertValue(1.215), 0.1);
            Assert.AreEqual(0.8, testSensor2.ConvertValue(1.8), 0.001);

        }

       
    }
}
