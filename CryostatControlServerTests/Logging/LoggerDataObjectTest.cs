using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.Logging
{
    using CryostatControlServer.Logging;

    [TestClass]
    public class LoggerDataObjectTest
    {
        [TestMethod]
        public void LoggerDataObjectCreate()
        {
            AbstractDataLogger abstractDataLogger = new GeneralDataLogger();
            string filePath = "test.csv";
            LoggerDataObject loggerDataObject = new LoggerDataObject(abstractDataLogger, filePath);
            Assert.AreEqual(abstractDataLogger, loggerDataObject.GetAbstractLogData());
            Assert.AreEqual(filePath, loggerDataObject.GetFilePath());
        }
    }
}
