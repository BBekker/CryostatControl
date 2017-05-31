using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Lakeshore
{
    using System;
    using System.Globalization;
    using System.Threading;

    using CryostatControlServer.Data;
    using CryostatControlServer.LakeShore;
    using CryostatControlServer.Streams;

    using Moq;

    [TestClass]
    public class LakeShoreTests
    {
        #region Methods

        [TestMethod]
        public void TestStartAndRead()
        {
            var lakeshore = new LakeShore();

            //Set up mock
            var mockLS = new Mock<IManagedStream>();
            mockLS.Setup(stream => stream.Open());
            mockLS.Setup(stream => stream.WriteString(It.IsAny<string>()));
            mockLS.Setup(stream => stream.ReadString()).Returns(() => "5.0");
            mockLS.Setup(stream => stream.IsConnected()).Returns(true);
            lakeshore.Init(mockLS.Object);

            //wait for the thread to run
            Thread.Sleep(500);

            ISensor lssensor = new Sensor(SensorEnum.Sensor1, lakeshore);
          
            Assert.AreEqual(5.0, lssensor.Value);

            lakeshore.Close();
            Thread.Sleep(1);
        }

        #endregion Methods
    }
}