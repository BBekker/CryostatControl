using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Logging
{
    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;

    using Moq;

    [TestClass]
    public class LogThreaderTest
    {
        [TestMethod]
        public void ConvertSecondsToMsTest()
        {
            LogThreader logThreader = new LogThreader(null);
            Assert.AreEqual(1000, logThreader.ConvertSecondsToMs(1));
        }

        [TestMethod]
        public void NewFileIsNeededFalseTest()
        {
            LogThreader logThreader = new LogThreader(null);
            DateTime today = DateTime.Now;
            string filePath = @"c\CryostatLogging\General\" + today.Year + @"\" + today.Month + @"\"
                              + today.Day + ".csv";
            Assert.IsFalse(logThreader.NewFileIsNeeded(filePath));
        }

        [TestMethod]
        public void NewFileIsNeededTrueTest()
        {
            LogThreader logThreader = new LogThreader(null);
            DateTime tomorrow = DateTime.Now.AddDays(1);
            string filePath = @"c\CryostatLogging\General\" + tomorrow.Year + @"\" + tomorrow.Month + @"\"
                              + tomorrow.Day + ".csv";
            Assert.IsTrue(logThreader.NewFileIsNeeded(filePath));
        }

        [TestMethod]
        public void NewFileIsNeededNoExtensionTest()
        {
            LogThreader logThreader = new LogThreader(null);
            DateTime tomorrow = DateTime.Now.AddDays(1);
            string filePath = @"c\CryostatLogging\General\" + tomorrow.Year + @"\" + tomorrow.Month + @"\"
                              + tomorrow.Day;
            Assert.IsFalse(logThreader.NewFileIsNeeded(filePath));
        }

        [TestMethod]
        public void NewFileIsNeededNullFileTest()
        {
            LogThreader logThreader = new LogThreader(null);
            string filePath = null;
            Assert.IsFalse(logThreader.NewFileIsNeeded(filePath));
        }
    }
}
