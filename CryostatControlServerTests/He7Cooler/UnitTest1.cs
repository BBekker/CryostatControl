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
    }
}
