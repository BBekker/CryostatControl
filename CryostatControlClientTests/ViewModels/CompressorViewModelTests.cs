﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryostatControlClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlClient.ViewModels.Tests
{
    [TestClass]
    public class CompressorViewModelTests
    {
        [TestMethod]
        public void ConvertWarningStateNumberToStringTest()
        {
            CompressorViewModel compressorViewModel = new CompressorViewModel();
            int warningStateNumber = -8;
            string expected = "Coolant OUT running Low";
            string actual = compressorViewModel.ConvertWarningStateNumberToString(warningStateNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertOperatingStateNumberToStringTest()
        {
            CompressorViewModel compressorViewModel = new CompressorViewModel();
            int warningStateNumber = 5;
            string expected = "Stopping";
            string actual = compressorViewModel.ConvertOperatingStateNumberToString(warningStateNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}