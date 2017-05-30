using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.He7Cooler
{
    using System.Globalization;
    using System.Threading;

    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.Streams;

    using Moq;

    /// <summary>
    /// The he 7 cooler smoke tests.
    /// </summary>
    [TestClass]
    public class He7CoolerSmokeTests
    {
        #region Methods

        [TestMethod]
        public void SmokeTestInitialisation()
        {
            var mockH7 = new Mock<IManagedStream>();
            mockH7.Setup(stream => stream.Open());
            mockH7.Setup(stream => stream.ReadString()).Returns("1\n");
            mockH7.Setup(stream => stream.IsConnected()).Returns(true);

            var agilent = new Agilent34972A();
            agilent.Init(mockH7.Object);
            var cooler = new CryostatControlServer.He7Cooler.He7Cooler();
            cooler.Connect(agilent, false);
            cooler.Disconnect();
        }

        [TestMethod]
        [ExpectedException(typeof(AgilentException), "Should have thrown invalid state exeption, but didn't.")]
        public void SmokeTestFailedInitialisation()
        {
            var mockH7 = new Mock<IManagedStream>();
            mockH7.Setup(stream => stream.Open());
            mockH7.Setup(stream => stream.ReadString()).Returns("0\n");
            mockH7.Setup(stream => stream.IsConnected()).Returns(true);

            var agilent = new Agilent34972A();
            agilent.Init(mockH7.Object);
            var cooler = new He7Cooler();
            cooler.Connect(agilent, false);
            cooler.Disconnect();
        }

        [TestMethod]
        public void SmokeTestReadValues()
        {
            IFormatProvider myFormatProvider = new CultureInfo("en-GB").NumberFormat;

            //Set up mock
            var mockH7 = new Mock<IManagedStream>();
            var fakeresponser = new He7ResponseGenerator();
            mockH7.Setup(stream => stream.Open());
            mockH7.Setup(stream => stream.WriteString(It.IsAny<string>()))
                .Callback((string s) => fakeresponser.ListenToAny(s));
            mockH7.Setup(stream => stream.ReadString()).Returns(() => fakeresponser.RespondToRead());
            mockH7.Setup(stream => stream.IsConnected()).Returns(true);

            var agilent = new Agilent34972A();
            agilent.Init(mockH7.Object);
            var cooler = new CryostatControlServer.He7Cooler.He7Cooler();
            cooler.Connect(agilent, false);

            cooler.ReadVoltages();
            Assert.AreEqual(0.0, cooler.He3Pump.Voltage);

            fakeresponser.responsevalues[(int)Channels.SensHe3Pump] = 5.0;
            cooler.ReadVoltages();
            Assert.AreEqual(5.0, cooler.He3Pump.Voltage);

            fakeresponser.responsevalues[(int)Channels.SensHe3HeadT] = 0.2147;
            cooler.ReadVoltages();
            Assert.AreEqual(33.0, cooler.He3HeadT.Value, 0.01);

            cooler.Disconnect();
        }

        [TestMethod]
        public void SmokeTestReadValuesThreaded()
        {
            //Set up mock
            var mockH7 = new Mock<IManagedStream>();
            var fakeresponser = new He7ResponseGenerator();
            mockH7.Setup(stream => stream.Open());
            mockH7.Setup(stream => stream.WriteString(It.IsAny<string>()))
                .Callback((string s) => fakeresponser.ListenToAny(s));
            mockH7.Setup(stream => stream.ReadString()).Returns(() => fakeresponser.RespondToRead());
            mockH7.Setup(stream => stream.IsConnected()).Returns(true);

            var agilent = new Agilent34972A();
            agilent.Init(mockH7.Object);
            var cooler = new CryostatControlServer.He7Cooler.He7Cooler();
            cooler.Connect(agilent, true);

            fakeresponser.responsevalues[(int)Channels.SensHe3HeadT] = 0.2147;
            fakeresponser.responsevalues[(int)Channels.SensHe3Pump] = 5.0;
            Thread.Sleep(5000);

            Assert.AreEqual(5.0, cooler.He3Pump.Voltage);

            Assert.AreEqual(33.0, cooler.He3HeadT.Value, 0.01);

            cooler.Disconnect();
            Thread.Sleep(1);
        }

        #endregion Methods
    }
}