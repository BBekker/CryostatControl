// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CryostatControl.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    using System;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.HostService.Enumerators;
    using CryostatControlServer.LakeShore;

    /// <summary>
    /// Class which handles all the request by the client.
    /// </summary>
    public class CryostatControl
    {
        #region Fields

        /// <summary>
        /// The calibration file location for helium heads.
        /// </summary>
        private const string RuoxFile = "..\\..\\RUOX.CAL";

        /// <summary>
        /// The he 3 column.
        /// </summary>
        private const int He3Col = 2;

        /// <summary>
        /// The he 4 column.
        /// </summary>
        private const int He4Col = 3;

        /// <summary>
        /// The diode calibration file location.
        /// </summary>
        private const string DiodeFile = "..\\..\\DIODE.CAL";

        /// <summary>
        /// The data read out
        /// </summary>
        private readonly DataReadOut dataReadOut;

        /// <summary>
        /// The sensors
        /// </summary>
        private ISensor[] sensors = new ISensor[(int)DataEnumerator.SensorAmount];

        /// <summary>
        /// The compressor
        /// </summary>
        private Compressor.Compressor compressor;

        /// <summary>
        /// The lake shore
        /// </summary>
        private LakeShore.LakeShore lakeShore;

        /// <summary>
        /// The he7 cooler
        /// </summary>
        private He7Cooler.He7Cooler he7Cooler;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CryostatControl"/> class.
        /// </summary>
        /// <param name="compressor">The compressor.</param>
        /// <param name="lakeShore">The lake shore.</param>
        /// <param name="he7Cooler">The he7 cooler.</param>
        public CryostatControl(
            Compressor.Compressor compressor,
            LakeShore.LakeShore lakeShore,
            He7Cooler.He7Cooler he7Cooler)
        {
            this.compressor = compressor;
            this.lakeShore = lakeShore;
            this.he7Cooler = he7Cooler;

            ////this.FillSensors();
            this.dataReadOut = new DataReadOut(this.compressor, this.sensors);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <returns>data array with sensor values</returns>
        public double[] ReadData()
        {
            return this.dataReadOut.FillData();
        }

        /// <summary>
        /// Fills the sensors initially with empty sensors than fills it for each component.
        /// </summary>
        private void FillSensors()
        {
            for (int i = 0; i < this.sensors.Length; i++)
            {
                this.sensors[i] = new EmptySensor();
            }

            this.FillLakeShoreSensors();
            this.FillCompressorSensors();
            this.FillHe7Sensors();
        }

        /// <summary>
        /// Fills the lake shore sensors.
        /// </summary>
        private void FillLakeShoreSensors()
        {
            try
            {
                this.sensors[(int)DataEnumerator.LakePlate50K] =
                    new LakeShore.Sensor(SensorEnum.Sensor1, this.lakeShore);
                this.sensors[(int)DataEnumerator.LakePlate50K] =
                    new LakeShore.Sensor(SensorEnum.Sensor2, this.lakeShore);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong filling lakeShore sensors");

                ////todo: handle it further, try reconnecting?
            }
        }

        /// <summary>
        /// Fills the compressor sensors.
        /// </summary>
        private void FillCompressorSensors()
        {
            try
            {
                this.sensors[(int)DataEnumerator.ComWaterIn] = new Compressor.Sensor(AnalogRegistersEnum.CoolantInTemp, this.compressor);
                this.sensors[(int)DataEnumerator.ComWaterOut] = new Compressor.Sensor(AnalogRegistersEnum.CoolantOutTemp, this.compressor);
                this.sensors[(int)DataEnumerator.ComHelium] = new Compressor.Sensor(AnalogRegistersEnum.HeliumTemp, this.compressor);
                this.sensors[(int)DataEnumerator.ComOil] = new Compressor.Sensor(AnalogRegistersEnum.OilTemp, this.compressor);
                this.sensors[(int)DataEnumerator.ComLow] = new Compressor.Sensor(AnalogRegistersEnum.LowPressure, this.compressor);
                this.sensors[(int)DataEnumerator.ComLowAvg] = new Compressor.Sensor(AnalogRegistersEnum.LowPressureAvg, this.compressor);
                this.sensors[(int)DataEnumerator.ComHigh] = new Compressor.Sensor(AnalogRegistersEnum.HighPressure, this.compressor);
                this.sensors[(int)DataEnumerator.ComHighAvg] = new Compressor.Sensor(AnalogRegistersEnum.HighPressureAvg, this.compressor);
                this.sensors[(int)DataEnumerator.ComDeltaAvg] = new Compressor.Sensor(AnalogRegistersEnum.DeltaPressureAvg, this.compressor);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong filling Compressor sensors");

                ////todo: handle it further, try reconnecting?
            }
        }

        /// <summary>
        /// Fills the he7 sensors.
        /// </summary>
        private void FillHe7Sensors()
        {
            try
            {
                He7Cooler.He7Cooler.Sensor.Calibration he3Calibration = new He7Cooler.He7Cooler.Sensor.Calibration(RuoxFile, He3Col, 0);
                He7Cooler.He7Cooler.Sensor.Calibration he4Calibration = new He7Cooler.He7Cooler.Sensor.Calibration(RuoxFile, He4Col, 0);
                He7Cooler.He7Cooler.Sensor.Calibration diodeCalibration = new He7Cooler.He7Cooler.Sensor.Calibration(DiodeFile, 1, 0);

                this.sensors[(int)DataEnumerator.He3Pump] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3PumpT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.HePlate2K] = new He7Cooler.He7Cooler.Sensor(Channels.Sens2KplateT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.HePlate4K] = new He7Cooler.He7Cooler.Sensor(Channels.Sens4KplateT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.He3Head] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3HeadT, this.he7Cooler, he3Calibration);
                this.sensors[(int)DataEnumerator.He4Pump] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4PumpT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.He4SwitchTemp] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4SwitchT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.He3SwitchTemp] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3SwitchT, this.he7Cooler, diodeCalibration);
                this.sensors[(int)DataEnumerator.He4Head] = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4HeadT, this.he7Cooler, he4Calibration);

                this.sensors[(int)DataEnumerator.He3Volt] =
                    new He7Cooler.He7Cooler.Sensor(Channels.SensHe3Pump, this.he7Cooler, new He7Cooler.He7Cooler.Sensor.Calibration());
                this.sensors[(int)DataEnumerator.He4SwitchVolt] =
                    new He7Cooler.He7Cooler.Sensor(Channels.SwitchHe4, this.he7Cooler, new He7Cooler.He7Cooler.Sensor.Calibration());
                this.sensors[(int)DataEnumerator.He3SwitchVolt] =
                    new He7Cooler.He7Cooler.Sensor(Channels.SwitchHe3, this.he7Cooler, new He7Cooler.He7Cooler.Sensor.Calibration());
                this.sensors[(int)DataEnumerator.He4Volt] =
                    new He7Cooler.He7Cooler.Sensor(Channels.SensHe4Pump, this.he7Cooler, new He7Cooler.He7Cooler.Sensor.Calibration());
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong filling He7 sensors");

                ////todo: handle it further, try reconnecting?
            }
        }

        #endregion Methods
    }
}