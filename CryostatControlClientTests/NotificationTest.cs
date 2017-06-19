using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlClientTests
{
    using CryostatControlClient;

    [TestClass]
    public class NotificationTest
    {
        [TestMethod]
        public void IsATimeTestCorrect()
        {
            string data = "Iets interessants of niet";
            string level = "Error";
            string time = DateTime.Now.ToString("HH:mm:ss");
            Notification notification = new Notification(time, level, data);

            Assert.AreEqual(data, notification.Data);
            Assert.AreEqual(level, notification.Level);
            Assert.AreEqual(time, notification.Time);
        }

        [TestMethod]
        public void IsATimeTestCorrect2()
        {
            string data = "Iets interessants of niet";
            string level = "Error";
            string time = "02:50:40";
            Notification notification = new Notification(time, level, data);

            Assert.AreEqual(data, notification.Data);
            Assert.AreEqual(level, notification.Level);
            Assert.AreEqual(time, notification.Time);
        }

        [TestMethod]
        public void IsATimeTestIncorrect()
        {
            string data = "Iets interessants of niet";
            string level = "Error";
            string time = "14:2:04";
            Notification notification = new Notification(time, level, data);

            Assert.AreEqual(data, notification.Data);
            Assert.AreEqual(level, notification.Level);
            Assert.AreEqual("Unknown", notification.Time);
        }

        [TestMethod]
        public void IsATimeTestIncorrect2()
        {
            string data = "Iets interessants of niet";
            string level = "Error";
            string time = "02:40:77";
            Notification notification = new Notification(time, level, data);

            Assert.AreEqual(data, notification.Data);
            Assert.AreEqual(level, notification.Level);
            Assert.AreEqual("Unknown", notification.Time);
        }

        [TestMethod]
        public void IsALevelTestCorrect()
        {
            string data = "Iets interessants of niet";
            string level = "Error";
            string level2 = "Warning";
            string level3 = "Info";
            string time = DateTime.Now.ToString("HH:mm:ss");
            Notification notification = new Notification(time, level, data);
            Notification notification2 = new Notification(time, level2, data);
            Notification notification3 = new Notification(time, level3, data);

            Assert.AreEqual(level, notification.Level);
            Assert.AreEqual(level2, notification2.Level);
            Assert.AreEqual(level3, notification3.Level);
        }

        [TestMethod]
        public void IsALevelTestIncorrect()
        {
            string data = "Iets interessants of niet";
            string level = "Errorr";
            string level2 = "warning";
            string level3 = "Information";
            string time = DateTime.Now.ToString("HH:mm:ss");
            Notification notification = new Notification(time, level, data);
            Notification notification2 = new Notification(time, level2, data);
            Notification notification3 = new Notification(time, level3, data);

            Assert.AreEqual("Unknown", notification.Level);
            Assert.AreEqual("Unknown", notification2.Level);
            Assert.AreEqual("Unknown", notification3.Level);
        }
    }
}
