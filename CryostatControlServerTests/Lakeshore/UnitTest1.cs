using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Lakeshore
{
    using System.Threading;

    using CryostatControlServer;
    using CryostatControlServer.LakeShore;
    using CryostatControlServer.Streams;

    using CryostatControlServerTests.He7Cooler;

    using Moq;

    [TestClass]
    public class LakeShoreTests
    {
        [TestMethod]
        public void TestStartAndRead()
        {
            var lakeshore = new LakeShore();
            //Set up mock
            var mockLS = new Mock<IManagedStream>();
            mockLS.Setup(stream => stream.Open());
            mockLS.Setup(stream => stream.WriteString(It.IsAny<string>()));
            mockLS.Setup(stream => stream.ReadString()).Returns(() => "5.0");
            lakeshore.Init(mockLS.Object);

            //wait for the thread to run
            Thread.Sleep(500);

            ISensor lssensor = new Sensor(SensorEnum.Sensor1, lakeshore);

            Assert.AreEqual(5.0, lssensor.Value);

        }
    }
}
