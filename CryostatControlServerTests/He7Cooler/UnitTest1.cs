using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryostatControlServer;

namespace CryostatControlServerTests
{
    using CryostatControlServer.He7Cooler;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalibration()
        {
            H7Cooler.Sensor testSensor = new H7Cooler.Sensor();
            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(0, 0));
            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(100.0, 100.0));

            Assert.AreEqual(10.0, testSensor.ConvertTemperature(10.0));
            Assert.AreEqual(0.0, testSensor.ConvertTemperature(0.0));
            Assert.AreEqual(100.0, testSensor.ConvertTemperature(100.0));
            Assert.AreEqual(100.0, testSensor.ConvertTemperature(200.0));
            Assert.AreEqual(0.0, testSensor.ConvertTemperature(-1.0));

            testSensor.AddCalibrationDatapoint(new Tuple<double, double>(50.0, 80.0));

            Assert.AreEqual(40.0, testSensor.ConvertTemperature(25.0));
            Assert.AreEqual(80.0, testSensor.ConvertTemperature(50.0));
            Assert.AreEqual(90.0, testSensor.ConvertTemperature(75.0));
        }

        [TestMethod]
        public void TestReadingCalibration()
        {
            H7Cooler.Sensor testSensor = new H7Cooler.Sensor();
            testSensor.LoadSensorCalibrationFromFile("..\\..\\RUOX.CAL",3,0);
            Assert.AreEqual(149, testSensor.CalibrationSize);
            Assert.AreEqual(35.0, testSensor.ConvertTemperature(0.2133), 0.01);
            Assert.AreEqual(0.1, testSensor.ConvertTemperature(3.9229),0.01);
            Assert.AreEqual(0.099, testSensor.ConvertTemperature(3.99),0.001);

            H7Cooler.Sensor testSensor2 = new H7Cooler.Sensor();
            testSensor2.LoadSensorCalibrationFromFile("..\\..\\DIODE.CAL", 1, 0);
            Assert.AreEqual(142, testSensor2.CalibrationSize);
            Assert.AreEqual(300.0, testSensor2.ConvertTemperature(0.57), 0.1);
            Assert.AreEqual(17.5, testSensor2.ConvertTemperature(1.215), 0.1);
            Assert.AreEqual(0.8, testSensor2.ConvertTemperature(1.8), 0.001);

        }
    }
}
