//-----------------------------------------------------------------------
// <copyright file="CompressorViewModelTests.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.Tests
{
    using System.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class BlueforsViewModelTests
    {
        private BlueforsViewModel blueforsViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.blueforsViewModel = new BlueforsViewModel();
        }

        [TestMethod()]
        public void ColdPlate3KTempTest()
        {
            this.blueforsViewModel.ColdPlate3KTemp = 50;
            Assert.AreEqual(this.blueforsViewModel.ColdPlate3KTemp, 50);
        }

        [TestMethod()]
        public void ColdPlate50KTempTest()
        {
            this.blueforsViewModel.ColdPlate50KTemp = 50;
            Assert.AreEqual(this.blueforsViewModel.ColdPlate50KTemp, 50);
        }

        [TestMethod()]
        public void ConnectionStateTest()
        {
            this.blueforsViewModel.ConnectionState = 1;
            Assert.AreEqual(this.blueforsViewModel.ConnectionState, 1);
        }

        [TestMethod()]
        public void ConnectionStateConvertedTest()
        {
            this.blueforsViewModel.ConnectionState = 1;
            Assert.AreNotEqual(this.blueforsViewModel.ConnectionStateConverted, string.Empty);
        }

        [TestMethod()]
        public void ColdPlate3KVisibilityTest()
        {
            this.blueforsViewModel.ColdPlate3KVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.blueforsViewModel.ColdPlate3KVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void ColdPlate50KVisibilityTest()
        {
            this.blueforsViewModel.ColdPlate50KVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.blueforsViewModel.ColdPlate50KVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void OnColdPlate50KVisibilityTest()
        {
            this.blueforsViewModel.ColdPlate50KVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.blueforsViewModel.ColdPlate50KVisibility, Visibility.Hidden);
        }
    }
}