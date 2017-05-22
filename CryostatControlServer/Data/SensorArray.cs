﻿namespace CryostatControlServer.Data
{
    using CryostatControlServer.Compressor;
    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.LakeShore;

    public class SensorArray
    {
        #region Fields

        private Compressor compressor;

        private He7Cooler he7Cooler;

        private LakeShore lakeShore;

        #endregion Fields

        #region Constructors

        public SensorArray(
            Compressor compressor,
            He7Cooler he7Cooler,
            LakeShore lakeShore)
        {
            this.compressor = compressor;
            this.he7Cooler = he7Cooler;
            this.lakeShore = lakeShore;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Fills the sensors initially with empty sensors than fills it for each component.
        /// <seealso cref="DataEnumerator" /> for the position of each sensor
        /// </summary>
        /// <returns> Array filled with new sensors</returns>
        public ISensor[] getSensorArray()
        {
            ISensor[] sensors = new ISensor[(int)DataEnumerator.DataLength];

            for (int i = 0; i < sensors.Length; i++)
            {
                sensors[i] = new EmptySensor();
            }

            this.FillLakeShoreSensors(sensors);
            this.FillCompressorSensors(sensors);
            this.FillHe7Sensors(sensors);

            return sensors;
        }

        /// <summary>
        /// Fills the lake shore sensors.
        /// </summary>
        private void FillLakeShoreSensors(ISensor[] sensors)
        {
            sensors[(int)DataEnumerator.LakePlate50K] =
                new CryostatControlServer.LakeShore.Sensor(SensorEnum.Sensor1, this.lakeShore);
            sensors[(int)DataEnumerator.LakePlate3K] =
                new CryostatControlServer.LakeShore.Sensor(SensorEnum.Sensor2, this.lakeShore);
        }

        /// <summary>
        /// Fills the compressor sensors.
        /// </summary>
        private void FillCompressorSensors(ISensor[] sensors)
        {
            sensors[(int)DataEnumerator.ComWaterIn] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.CoolantInTemp, this.compressor);
            sensors[(int)DataEnumerator.ComWaterOut] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.CoolantOutTemp, this.compressor);
            sensors[(int)DataEnumerator.ComHelium] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.HeliumTemp, this.compressor);
            sensors[(int)DataEnumerator.ComOil] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.OilTemp, this.compressor);
            sensors[(int)DataEnumerator.ComLow] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.LowPressure, this.compressor);
            sensors[(int)DataEnumerator.ComLowAvg] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.LowPressureAvg, this.compressor);
            sensors[(int)DataEnumerator.ComHigh] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.HighPressure, this.compressor);
            sensors[(int)DataEnumerator.ComHighAvg] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.HighPressureAvg, this.compressor);
            sensors[(int)DataEnumerator.ComDeltaAvg] =
                new CryostatControlServer.Compressor.Sensor(AnalogRegistersEnum.DeltaPressureAvg, this.compressor);
        }

        /// <summary>
        /// Fills the he7 sensors.
        /// </summary>
        private void FillHe7Sensors(ISensor[] sensors)
        {
            He7Cooler.Sensor.Calibration he3Calibration =
                He7Cooler.Sensor.Calibration.He3Calibration;
            He7Cooler.Sensor.Calibration he4Calibration =
                He7Cooler.Sensor.Calibration.He4Calibration;
            He7Cooler.Sensor.Calibration diodeCalibration =
                He7Cooler.Sensor.Calibration.DiodeCalibration;
            He7Cooler.Sensor.Calibration emptyCalibration =
                He7Cooler.Sensor.Calibration.EmptyCalibration;

            sensors[(int)DataEnumerator.He3Pump] =
                new He7Cooler.Sensor(Channels.SensHe3PumpT, this.he7Cooler, diodeCalibration);
            sensors[(int)DataEnumerator.HePlate2K] =
                new He7Cooler.Sensor(Channels.Sens2KplateT, this.he7Cooler, diodeCalibration);
            sensors[(int)DataEnumerator.HePlate4K] =
                new He7Cooler.Sensor(Channels.Sens4KplateT, this.he7Cooler, diodeCalibration);
            sensors[(int)DataEnumerator.He3Head] =
                new He7Cooler.Sensor(Channels.SensHe3HeadT, this.he7Cooler, he3Calibration);
            sensors[(int)DataEnumerator.He4Pump] =
                new He7Cooler.Sensor(Channels.SensHe4PumpT, this.he7Cooler, diodeCalibration);
            sensors[(int)DataEnumerator.He4SwitchTemp] = new He7Cooler.Sensor(
                Channels.SensHe4SwitchT,
                this.he7Cooler,
                diodeCalibration);
            sensors[(int)DataEnumerator.He3SwitchTemp] = new He7Cooler.Sensor(
                Channels.SensHe3SwitchT,
                this.he7Cooler,
                diodeCalibration);
            sensors[(int)DataEnumerator.He4Head] =
                new He7Cooler.Sensor(Channels.SensHe4HeadT, this.he7Cooler, he4Calibration);

            sensors[(int)DataEnumerator.He3VoltActual] =
                new He7Cooler.Sensor(Channels.SensHe3Pump, this.he7Cooler, emptyCalibration);
            sensors[(int)DataEnumerator.He4SwitchVoltActual] = new He7Cooler.Sensor(
                Channels.SensHe3Switch,
                this.he7Cooler,
                emptyCalibration);
            sensors[(int)DataEnumerator.He3SwitchVoltActual] = new He7Cooler.Sensor(
                Channels.SensHe4Switch,
                this.he7Cooler,
                emptyCalibration);
            sensors[(int)DataEnumerator.He4VoltActual] =
                new He7Cooler.Sensor(Channels.SensHe4Pump, this.he7Cooler, emptyCalibration);
        }

        #endregion Methods
    }
}