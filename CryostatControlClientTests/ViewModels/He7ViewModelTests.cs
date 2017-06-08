//-----------------------------------------------------------------------
// <copyright file="CompressorViewModelTests.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.Tests
{
    using System;
    using System.Windows;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class He7ViewModelTests
    {
        private He7ViewModel he7ViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.he7ViewModel = new He7ViewModel();
        }

        [TestMethod()]
        public void TwoKPlateVisibilityTest()
        {
            this.he7ViewModel.TwoKPlateVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.TwoKPlateVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void FourKPlateVisibilityTest()
        {
            this.he7ViewModel.FourKPlateVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.FourKPlateVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He3HeadVisibilityTest()
        {
            this.he7ViewModel.He3HeadVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He3HeadVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He3SwitchVisibilityTest()
        {
            this.he7ViewModel.He3SwitchVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He3SwitchVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He3PumpVisibilityTest()
        {
            this.he7ViewModel.He3PumpVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He3PumpVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He4HeadVisibilityTest()
        {
            this.he7ViewModel.He4HeadVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He4HeadVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He4SwitchVisibilityTest()
        {
            this.he7ViewModel.He4SwitchVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He4SwitchVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void He4PumpVisibilityTest()
        {
            this.he7ViewModel.He4PumpVisibility = System.Windows.Visibility.Hidden;
            Assert.AreEqual(this.he7ViewModel.He4PumpVisibility, Visibility.Hidden);
        }

        [TestMethod()]
        public void FourKPlateTempTest()
        {
            this.he7ViewModel.FourKPlateTemp = 1;
            Assert.AreEqual(this.he7ViewModel.FourKPlateTemp, 1);
        }

        [TestMethod()]
        public void FourKPlateMax1Test()
        {
            this.he7ViewModel.FourKPlateMax1 = 1;
            Assert.AreEqual(this.he7ViewModel.FourKPlateMax1, 1);
        }

        [TestMethod()]
        public void FourKPlateMax2Test()
        {
            this.he7ViewModel.FourKPlateMax2 = 1;
            Assert.AreEqual(this.he7ViewModel.FourKPlateMax2, 1);
        }

        [TestMethod()]
        public void He3HeadTempTest()
        {
            this.he7ViewModel.He3HeadTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He3HeadTemp, 1);
        }

        [TestMethod()]
        public void He3HeadMaxTest()
        {
            this.he7ViewModel.He3HeadMax = 1;
            Assert.AreEqual(this.he7ViewModel.He3HeadMax, 1);
        }

        [TestMethod()]
        public void He3PumpTempTest()
        {
            this.he7ViewModel.He3PumpTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He3PumpTemp, 1);
        }

        [TestMethod()]
        public void He3PumpActualVoltTest()
        {
            this.he7ViewModel.He3PumpActualVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He3PumpActualVolt, 1);
        }

        [TestMethod()]
        public void He3PumpNewVoltTest()
        {
            this.he7ViewModel.He3PumpNewVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He3PumpNewVolt, 1);
        }

        [TestMethod()]
        public void He3PumpMaxTest()
        {
            this.he7ViewModel.He3PumpMax = 1;
            Assert.AreEqual(this.he7ViewModel.He3PumpMax, 1);
        }

        [TestMethod()]
        public void He3SwitchTempTest()
        {
            this.he7ViewModel.He3SwitchTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He3SwitchTemp, 1);
        }

        [TestMethod()]
        public void He3SwitchActualVoltTest()
        {
            this.he7ViewModel.He3SwitchActualVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He3SwitchActualVolt, 1);
        }

        [TestMethod()]
        public void He3SwitchNewVoltTest()
        {
            this.he7ViewModel.He3SwitchNewVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He3SwitchNewVolt, 1);
        }

        [TestMethod()]
        public void He3SwitchMax1Test()
        {
            this.he7ViewModel.He3SwitchMax1 = 1;
            Assert.AreEqual(this.he7ViewModel.He3SwitchMax1, 1);
        }

        [TestMethod()]
        public void He3SwitchMax2Test()
        {
            this.he7ViewModel.He3SwitchMax2 = 1;
            Assert.AreEqual(this.he7ViewModel.He3SwitchMax2, 1);
        }

        [TestMethod()]
        public void He4HeadTempTest()
        {
            this.he7ViewModel.He4HeadTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He4HeadTemp, 1);
        }

        [TestMethod()]
        public void He4HeadMaxTest()
        {
            this.he7ViewModel.He4HeadMax = 1;
            Assert.AreEqual(this.he7ViewModel.He4HeadMax, 1);
        }

        [TestMethod()]
        public void He4PumpTempTest()
        {
            this.he7ViewModel.He4PumpTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He4PumpTemp, 1);
        }

        [TestMethod()]
        public void He4PumpActualVoltTest()
        {
            this.he7ViewModel.He4PumpActualVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He4PumpActualVolt, 1);
        }

        [TestMethod()]
        public void He4PumpNewVoltTest()
        {
            this.he7ViewModel.He4PumpNewVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He4PumpNewVolt, 1);
        }

        [TestMethod()]
        public void He4PumpMaxTest()
        {
            this.he7ViewModel.He4PumpMax = 1;
            Assert.AreEqual(this.he7ViewModel.He4PumpMax, 1);
        }

        [TestMethod()]
        public void He4SwitchTempTest()
        {
            this.he7ViewModel.He4SwitchTemp = 1;
            Assert.AreEqual(this.he7ViewModel.He4SwitchTemp, 1);
        }

        [TestMethod()]
        public void He4SwitchActualVoltTest()
        {
            this.he7ViewModel.He4SwitchActualVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He4SwitchActualVolt, 1);
        }

        [TestMethod()]
        public void He4SwitchNewVoltTest()
        {
            this.he7ViewModel.He4SwitchNewVolt = 1;
            Assert.AreEqual(this.he7ViewModel.He4SwitchNewVolt, 1);
        }

        [TestMethod()]
        public void He4SwitchMax1Test()
        {
            this.he7ViewModel.He4SwitchMax1 = 1;
            Assert.AreEqual(this.he7ViewModel.He4SwitchMax1, 1);
        }

        [TestMethod()]
        public void He4SwitchMax2Test()
        {
            this.he7ViewModel.He4SwitchMax2 = 1;
            Assert.AreEqual(this.he7ViewModel.He4SwitchMax2, 1);
        }

        [TestMethod()]
        public void TwoKPlateTemp()
        {
            this.he7ViewModel.TwoKPlateTemp = 1;
            Assert.AreEqual(this.he7ViewModel.TwoKPlateTemp, 1);
        }

        [TestMethod()]
        public void OperatingStateTest()
        {
            this.he7ViewModel.ConnectionState = 1;
            Assert.AreEqual(this.he7ViewModel.ConnectionState, 1);
        }

        [TestMethod()]
        public void OperatingStateConvertedTest()
        {
            this.he7ViewModel.ConnectionState = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.he7ViewModel.ConnectionStateConverted));
        }

        [TestMethod()]
        public void UpdateEnableTestTrue()
        {
            this.he7ViewModel.ConnectionState = 1;
            Assert.IsTrue(this.he7ViewModel.UpdateEnable);
        }

        [TestMethod()]
        public void UpdateEnableTestFalse()
        {
            this.he7ViewModel.ConnectionState = 2;
            Assert.IsFalse(this.he7ViewModel.UpdateEnable);
        }
    }
}