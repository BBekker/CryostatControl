using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryostatControlServerTests.He7Cooler
{
    using System.Collections.Generic;
    using System.Threading;

    using CryostatControlServer.He7Cooler;

    using Moq;
    using Moq.Protected;

    [TestClass]
    public class HeaterTest
    {
        private Dictionary<Channels, double> values = new Dictionary<Channels, double>();
        private Dictionary<Channels, double> outvalues = new Dictionary<Channels, double>();


        private He7Cooler getCoolerMock()
        {
            var AgilentMock = new Mock<Agilent34972A>();

            AgilentMock.Setup<double[]>((obj) => obj.GetVoltages(It.IsAny<Channels[]>())).Returns<Channels[]>(
                (channels) =>
                    {
                        var res = new double[channels.Length];
                        for (int i = 0; i < channels.Length; i++)
                        {
                            if (!this.values.TryGetValue(channels[i], out res[i]))
                            {
                                res[i] = 0.0;
                            }
                        }
                        return res;
                    });
            AgilentMock.Setup(obj => obj.SetHeaterVoltage(It.IsAny<Channels>(), It.IsAny<double>()))
                .Callback<Channels, double>(
                    (channel, value) =>
                        {
                            if (this.outvalues.ContainsKey(channel))
                            {
                                this.outvalues[channel] = value;
                            }
                            else
                            {
                                this.outvalues.Add(channel, value);
                            }
                        });
            var cooler = new He7Cooler();
            cooler.Connect(AgilentMock.Object, false);
            return cooler;
        }

        [TestMethod]
        public void TestReadVoltage()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            cooler.ReadVoltages();
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler);
            Assert.AreEqual(1.0, heater.Voltage);
            this.values[Channels.SensHe3Pump] = 10.0;
            cooler.ReadVoltages();
            Assert.AreEqual(10.0, heater.Voltage);

        }

        [TestMethod]
        public void TestReadCurrent()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 100, Calibration.EmptyCalibration, cooler);
            cooler.ReadVoltages();
            
            Assert.AreEqual(0.01, heater.Current);

            this.values[Channels.SensHe3Pump] = 10;
            cooler.ReadVoltages();
            Assert.AreEqual(0.1, heater.Current);
        }

        [TestMethod]
        public void TestReadPower()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 100, Calibration.EmptyCalibration, cooler);
            cooler.ReadVoltages();

            Assert.AreEqual(0.01, heater.Power);

            this.values[Channels.SensHe3Pump] = 10;
            cooler.ReadVoltages();
            Assert.AreEqual(1, heater.Power);
        }

        [TestMethod]
        public void TestWritePower()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 10, Calibration.EmptyCalibration, cooler);
            heater.Power = 1;
            Assert.AreEqual(3.162, this.outvalues[Channels.PumpHe3], 0.001);
        }


        [TestMethod]
        public void TestWriteCurrent()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 10, Calibration.EmptyCalibration, cooler);
            heater.Current = 0.5;
            Assert.AreEqual(5.0, this.outvalues[Channels.PumpHe3], 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Should have thrown out of range exception, but didn't.")]
        public void TestWriteVoltageSafety()
        {
            var cooler = this.getCoolerMock();
            this.values.Add(Channels.SensHe3Pump, 1.0);
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 10, Calibration.EmptyCalibration, cooler);
            heater.SafeRangeHigh = 5.0;
            heater.Voltage = 6.0;
        }

        [TestMethod]
        public void TestWriteVoltageCalibration()
        {
            var cooler = this.getCoolerMock();
            var calibration = new Calibration();
            calibration.AddCalibrationDatapoint(new Tuple<double,double>(0.0,0.0));
            calibration.AddCalibrationDatapoint(new Tuple<double, double>(10.0, 20.0));
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 10, calibration, cooler);
            heater.SafeRangeHigh = 20.0;
            heater.Voltage = 5.0;
            Assert.AreEqual(10, this.outvalues[Channels.PumpHe3], 0.001);
        }

        [TestMethod]
        public void TestTemperatureControlPower()
        {
            var cooler = this.getCoolerMock();
            He7Cooler.Heater heater = new He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler.He3PumpT, 10, Calibration.EmptyCalibration, cooler);
            heater.TemperatureSetpoint = 100.0;
            heater.TemperatureControlEnabled = true;
            heater.PowerLimit = 1.0;

            this.values[Channels.SensHe3PumpT] = 1.7;
            cooler.ReadVoltages();
            heater.Notify();
            Assert.AreEqual(3.162, this.outvalues[Channels.PumpHe3], 0.001);
            
        }

    }
}
