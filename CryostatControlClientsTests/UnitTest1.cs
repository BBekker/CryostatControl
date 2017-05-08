using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryostatControlClient;

namespace CryostatControlClientsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var homeScreen = new CryostatControlClient.Models.HomeScreen();
            Assert.AreEqual(2, homeScreen.simpleCalc());
        }
    }
}
