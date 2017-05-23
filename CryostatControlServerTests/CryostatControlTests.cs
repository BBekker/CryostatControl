using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests
{
    using CryostatControlServer;
    using CryostatControlServer.HostService;
    using CryostatControlServer.HostService.Enumerators;

    using Moq;

    [TestClass]
    public class CryostatControlTests
    {
        [TestMethod]
        public void TestReadingSettings()
        {
            CommandService cs = new CommandService(new Mock<CryostatControl>().Object);

            var result = cs.ReadSettings();
            Assert.AreEqual(Enum.GetNames(typeof(SettingEnumerator)).Length, result.Length);         

        }


        [TestMethod]
        public void TestWritingSettings()
        {
            CommandService cs = new CommandService(new Mock<CryostatControl>().Object);
            cs.WriteSettingValue((int)SettingEnumerator.ControllerHeatupTemperature, 20);
            var readvals = cs.ReadSettings();
            Assert.AreEqual(readvals[(int)SettingEnumerator.ControllerHeatupTemperature], 20);

            cs.WriteSettingValue((int)SettingEnumerator.ControllerHeatupTemperature, 50);
            readvals = cs.ReadSettings();
            Assert.AreEqual(readvals[(int)SettingEnumerator.ControllerHeatupTemperature], 50);

        }
    }
}
