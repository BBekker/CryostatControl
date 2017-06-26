namespace CryostatControlServerTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using CryostatControlServer;
    using CryostatControlServer.Compressor;
    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.HostService;
    using CryostatControlServer.HostService.Enumerators;
    using CryostatControlServer.LakeShore;
    using CryostatControlServer.Streams;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CryostatControlTests
    {
        private Dictionary<Channels, double> outvalues = new Dictionary<Channels, double>();

        private Dictionary<Channels, double> values = new Dictionary<Channels, double>();

        [TestMethod]
        public void TestReadingSettings()
        {
            CommandService cs = new CommandService(new Mock<CryostatControl>().Object, null);

            var result = cs.ReadSettings();
            Assert.AreEqual(Enum.GetNames(typeof(SettingEnumerator)).Length, result.Length);
        }

        [TestMethod]
        public void TestWritingSettings()
        {
            CommandService cs = new CommandService(new Mock<CryostatControl>().Object, null);
            cs.WriteSettingValue((int)SettingEnumerator.ControllerHeatupTemperature, 20);
            var readvals = cs.ReadSettings();
            Assert.AreEqual(readvals[(int)SettingEnumerator.ControllerHeatupTemperature], 20);

            cs.WriteSettingValue((int)SettingEnumerator.ControllerHeatupTemperature, 50);
            readvals = cs.ReadSettings();
            Assert.AreEqual(readvals[(int)SettingEnumerator.ControllerHeatupTemperature], 50);
        }

        [TestMethod]
        public void TestControllerControl()
        {
            var cooler = this.getCoolerMock();

            var lakeshore = new LakeShore();
            var mockLS = new Mock<IManagedStream>();
            mockLS.Setup(stream => stream.Open());
            mockLS.Setup(stream => stream.WriteString(It.IsAny<string>()));
            mockLS.Setup(stream => stream.ReadString()).Returns(() => "5.0");
            mockLS.Setup(stream => stream.IsConnected()).Returns(true);
            lakeshore.Init(mockLS.Object);

            var compressor = new Mock<Compressor>();

            Controller controller = new Controller(cooler, lakeshore, compressor.Object);
            CryostatControl cryostatControl = new CryostatControl(compressor.Object, lakeshore, cooler, controller);

            Assert.AreEqual(Controlstate.Setup, cryostatControl.ControllerState);
            Thread.Sleep(5000);
            Assert.AreEqual(Controlstate.Standby, cryostatControl.ControllerState);
            Assert.AreEqual(true,cryostatControl.StartCooldown());
            Assert.AreEqual(Controlstate.CooldownStart, cryostatControl.ControllerState);
            Assert.AreEqual(false,cryostatControl.StartHeatup());
            Assert.AreEqual(Controlstate.CooldownStart, cryostatControl.ControllerState);
            cryostatControl.CancelCommand();
            Assert.AreEqual(Controlstate.CancelAll, cryostatControl.ControllerState);
            Thread.Sleep(8000);
            Assert.AreEqual(Controlstate.Standby, cryostatControl.ControllerState);
            Assert.AreEqual(true, cryostatControl.StartHeatup());
            Assert.AreEqual(Controlstate.WarmupStart, cryostatControl.ControllerState);
            Assert.AreEqual(false, cryostatControl.StartCooldown());
            Assert.AreEqual(Controlstate.WarmupStart, cryostatControl.ControllerState);
            cryostatControl.CancelCommand();
            Assert.AreEqual(Controlstate.CancelAll, cryostatControl.ControllerState);
            Thread.Sleep(8000);
            Assert.AreEqual(Controlstate.Standby, cryostatControl.ControllerState);
            Assert.AreEqual(true, cryostatControl.StartRecycle());
            Assert.AreEqual(Controlstate.RecycleStart, cryostatControl.ControllerState);
            Assert.AreEqual(false, cryostatControl.StartCooldown());
            Assert.AreEqual(Controlstate.RecycleStart, cryostatControl.ControllerState);
            cryostatControl.CancelCommand();
            Assert.AreEqual(Controlstate.CancelAll, cryostatControl.ControllerState);
            Thread.Sleep(8000);
            Assert.AreEqual(Controlstate.Standby, cryostatControl.ControllerState);
            Assert.AreEqual(true, cryostatControl.StartManualControl());
            Assert.AreEqual(Controlstate.Manual, cryostatControl.ControllerState);
            Assert.AreEqual(false, cryostatControl.StartCooldown());
            Assert.AreEqual(Controlstate.Manual, cryostatControl.ControllerState);
            cryostatControl.CancelCommand();
            Assert.AreEqual(Controlstate.CancelAll, cryostatControl.ControllerState);
        }



        private CryostatControlServer.He7Cooler.He7Cooler getCoolerMock()
        {
            var AgilentMock = new Mock<Agilent34972A>();

            AgilentMock.Setup<double[]>((obj) => obj.GetVoltages(It.IsAny<Channels[]>())).Returns<Channels[]>(
                (channels) =>
                    {
                        var res = new double[channels.Length];
                        for (int i = 0; i < channels.Length; i++)
                        {
                            if (!this.values.TryGetValue(channels[i], out res[i]))
                            {
                                res[i] = 0.0;
                            }
                        }

                        return res;
                    });

            AgilentMock.Setup(obj => obj.SetHeaterVoltage(It.IsAny<Channels>(), It.IsAny<double>()))
                .Callback<Channels, double>(
                    (channel, value) =>
                        {
                            if (this.outvalues.ContainsKey(channel))
                            {
                                this.outvalues[channel] = value;
                            }
                            else
                            {
                                this.outvalues.Add(channel, value);
                            }
                        });
            AgilentMock.Setup(obj => obj.IsConnected()).Returns(true);
            var cooler = new CryostatControlServer.He7Cooler.He7Cooler();
            cooler.Connect(AgilentMock.Object, false);
            return cooler;
        }
    }
}