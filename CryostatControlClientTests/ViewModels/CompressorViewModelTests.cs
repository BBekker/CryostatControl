using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryostatControlClient.ViewModels;
//-----------------------------------------------------------------------
// <copyright file="CompressorViewModelTests.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    /// <summary>
    /// Tests for compressor view model
    /// </summary>
    [TestClass]
    public class CompressorViewModelTests
    {
        private CompressorViewModel compressorViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.compressorViewModel = new CompressorViewModel();
        }

        /// <summary>
        /// Converts the warning state number to string test.
        /// </summary>
        [TestMethod]
        public void ConvertWarningStateNumberToStringTest()
        {
            double warningStateNumber = -8;
            string expected = "Water OUT running Low";
            string actual = this.compressorViewModel.ConvertWarningStateNumberToString(warningStateNumber);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Converts the operating state number to string test.
        /// </summary>
        [TestMethod]
        public void ConvertOperatingStateNumberToStringTest()
        {
            double operatingStateNumber = 5;
            string expected = "Stopping";
            string actual = this.compressorViewModel.ConvertOperatingStateNumberToString(operatingStateNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatingStateTest()
        {
            this.compressorViewModel.OperatingState = 1;
            Assert.AreEqual(this.compressorViewModel.OperatingState, 1);
        }

        [TestMethod()]
        public void OperatingStateConvertedTest()
        {
            this.compressorViewModel.OperatingState = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.OperatingStateConverted));
        }

        [TestMethod()]
        public void WarningStateTest()
        {
            this.compressorViewModel.WarningState = 1;
            Assert.AreEqual(this.compressorViewModel.WarningState, 1);
        }

        [TestMethod()]
        public void WarningStateConvertedTest()
        {
            this.compressorViewModel.WarningState = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.WarningStateConverted));
        }

        [TestMethod()]
        public void ErrorStateTest()
        {
            this.compressorViewModel.ErrorState = 1;
            Assert.AreEqual(this.compressorViewModel.ErrorState, 1);
        }

        [TestMethod()]
        public void ErrorStateConvertedTest()
        {
            this.compressorViewModel.ErrorState = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.ErrorStateConverted));
        }

        [TestMethod()]
        public void WaterInTempTest()
        {
            this.compressorViewModel.WaterInTemp = 1;
            Assert.AreEqual(this.compressorViewModel.WaterInTemp, 1);
        }

        [TestMethod()]
        public void WaterOutTest()
        {
            this.compressorViewModel.WaterOutTemp = 1;
            Assert.AreEqual(this.compressorViewModel.WaterOutTemp, 1);
        }

        [TestMethod()]
        public void OilTempTest()
        {
            this.compressorViewModel.OilTemp = 1;
            Assert.AreEqual(this.compressorViewModel.OilTemp, 1);
        }

        [TestMethod()]
        public void HeliumTempTest()
        {
            this.compressorViewModel.HeliumTemp = 1;
            Assert.AreEqual(this.compressorViewModel.HeliumTemp, 1);
        }

        [TestMethod()]
        public void LowPressureTest()
        {
            this.compressorViewModel.LowPressure = 1;
            Assert.AreEqual(this.compressorViewModel.LowPressure, 1);
        }

        [TestMethod()]
        public void LowPressureAverageTest()
        {
            this.compressorViewModel.LowPressureAverage = 1;
            Assert.AreEqual(this.compressorViewModel.LowPressureAverage, 1);
        }

        [TestMethod()]
        public void HighPressureTest()
        {
            this.compressorViewModel.HighPressure = 1;
            Assert.AreEqual(this.compressorViewModel.HighPressure, 1);
        }

        [TestMethod()]
        public void HighPressureAverageTest()
        {
            this.compressorViewModel.HighPressureAverage = 1;
            Assert.AreEqual(this.compressorViewModel.HighPressureAverage, 1);
        }

        [TestMethod()]
        public void DeltaPressureAverageTest()
        {
            this.compressorViewModel.DeltaPressureAverage = 1;
            Assert.AreEqual(this.compressorViewModel.DeltaPressureAverage, 1);
        }

        [TestMethod()]
        public void HoursOfOperationTest()
        {
            this.compressorViewModel.HoursOfOperation = 1;
            Assert.AreEqual(this.compressorViewModel.HoursOfOperation, 1);
        }

        [TestMethod()]
        public void PressureScaleTest()
        {
            this.compressorViewModel.PressureScale = 1;
            Assert.AreEqual(this.compressorViewModel.PressureScale, 1);
        }

        [TestMethod()]
        public void PressureScaleConvertedTest()
        {
            this.compressorViewModel.PressureScale = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.PressureScaleConverted));
        }

        [TestMethod()]
        public void TempScaleTest()
        {
            this.compressorViewModel.TempScale = 1;
            Assert.AreEqual(this.compressorViewModel.TempScale, 1);
        }

        [TestMethod()]
        public void TempScaleConvertedTest()
        {
            this.compressorViewModel.TempScale = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.TempScaleConverted));
        }

        [TestMethod()]
        public void ConnectionStateTest()
        {
            this.compressorViewModel.ConnectionState = 1;
            Assert.AreEqual(this.compressorViewModel.ConnectionState, 1);
        }

        [TestMethod()]
        public void ConnectionStateConvertedTest()
        {
            this.compressorViewModel.ConnectionState = 1;
            Assert.IsFalse(String.IsNullOrEmpty(this.compressorViewModel.ConnectionStateConverted));
        }

        [TestMethod()]
        public void TurnOnTestTrue()
        {
            this.compressorViewModel.OperatingState = 0;
            Assert.IsTrue(this.compressorViewModel.CanTurnOn);
        }

        [TestMethod()]
        public void TurnOnTestFalse()
        {
            this.compressorViewModel.OperatingState = 1;
            Assert.IsFalse(this.compressorViewModel.CanTurnOn);
        }

        [TestMethod()]
        public void TurnOffTestTrue()
        {
            this.compressorViewModel.OperatingState = 3;
            Assert.IsTrue(this.compressorViewModel.CanTurnOff);
        }

        [TestMethod()]
        public void TurnOffTestFalse()
        {
            this.compressorViewModel.OperatingState = 1;
            Assert.IsFalse(this.compressorViewModel.CanTurnOff);
        }
    }
}