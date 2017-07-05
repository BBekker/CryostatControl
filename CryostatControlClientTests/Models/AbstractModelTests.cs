namespace CryostatControlClient.Models.Tests
{
    using LiveCharts.Defaults;
    using LiveCharts.Geared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Windows;
    using System;
    using System.Linq;

    [TestClass()]
    public class AbstractModelTests
    {
        private He7Model he7Model;

        [TestInitialize]
        public void TestInitialize()
        {
            this.he7Model = new He7Model();
        }

        [TestMethod()]
        public void AddToGraphTestNoDecimal()
        {
            double value = 5;

            for (int i = 0; i < 31; i++)
            {
                this.he7Model.He3PumpTemp = value;
            }

            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[0]).Value);
            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[1]).Value);
        }

        [TestMethod()]
        public void AddToGraphTestDecimal()
        {
            double value = 10.5;

            for (int i = 0; i < 31; i++)
            {
                this.he7Model.He3PumpTemp = value;
            }

            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[0]).Value);
            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[1]).Value);
        }

        [TestMethod()]
        public void AddToGraphTestNaN()
        {
            double value = 5;

            for (int i = 0; i < 100; i++)
            {
                this.he7Model.He3PumpTemp = double.NaN;
            }

            for (int i = 0; i < 31; i++)
            {
                this.he7Model.He3PumpTemp = value;
            }

            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[0]).Value);
            Assert.AreEqual(value, ((DateTimePoint)this.he7Model.He3PumpLineSeries.Values[1]).Value);
        }
    }
}