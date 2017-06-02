//-----------------------------------------------------------------------
// <copyright file="CompressorViewModelTests.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for compressor view model
    /// </summary>
    [TestClass]
    public class CompressorViewModelTests
    {
        /// <summary>
        /// Converts the warning state number to string test.
        /// </summary>
        [TestMethod]
        public void ConvertWarningStateNumberToStringTest()
        {
            CompressorViewModel compressorViewModel = new CompressorViewModel();
            double warningStateNumber = -8;
            string expected = "Water OUT running Low";
            string actual = compressorViewModel.ConvertWarningStateNumberToString(warningStateNumber);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Converts the operating state number to string test.
        /// </summary>
        [TestMethod]
        public void ConvertOperatingStateNumberToStringTest()
        {
            CompressorViewModel compressorViewModel = new CompressorViewModel();
            double operatingStateNumber = 5;
            string expected = "Stopping";
            string actual = compressorViewModel.ConvertOperatingStateNumberToString(operatingStateNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}