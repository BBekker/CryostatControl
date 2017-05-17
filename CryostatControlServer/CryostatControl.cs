namespace CryostatControlServer
{
    using System;
    using System.IO;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.He7Cooler;
    using CryostatControlServer.HostService.Enumerators;
    using CryostatControlServer.LakeShore;

    public class CryostatControl
    {
        #region Fields

        /// <summary>
        /// The ruox calibration file location.
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

        private const string localhost = "127.0.0.1";
        private ISensor[] sensors = new ISensor[(int)DataEnumerator.SensorAmount];
        private Compressor.Compressor compressor;

        private LakeShore.LakeShore lakeShore;

        private He7Cooler.He7Cooler he7Cooler;

        #endregion Fields

        #region Methods

        public CryostatControl()
        {
            this.lakeShore = new LakeShore.LakeShore();
            this.he7Cooler = new He7Cooler.He7Cooler();

            try
            {
                this.lakeShore.Init("COM1");
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with LakeShore");

                //todo handle exception
            }

            try
            {
                this.he7Cooler.Connect(localhost);
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with He7");

                //todo handle exception
            }

            try
            {
                this.compressor = new Compressor.Compressor(localhost);
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with Compressor");

                //todo handle exception
            }

            this.FillSensors();
        }

        public double[] fillData()
        {
            double[] data = new double[(int)DataEnumerator.DataLenght];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = double.MinValue;
            }
            this.FillDataWithSensor(data);
            this.FillCompressorData(data);
            return data;
        }

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

                //todo: handle it further, try reconnecting?
            }
        }

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

                //todo: handle it further, try reconnecting?
            }
        }

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

                //todo: handle it further, try reconnecting?
            }
        }

        private void FillDataWithSensor(double[] data)
        {
            for (int i = 0; i < (int)DataEnumerator.SensorAmount; i++)
            {
                data[i] = this.sensors[i].Value;
            }
        }

        private void FillCompressorData(double[] data)
        {
            try
            {
                data[(int)DataEnumerator.ComError] = (double)this.compressor.ReadErrorState();
                data[(int)DataEnumerator.ComWarning] = (double)this.compressor.ReadWarningState();
                data[(int)DataEnumerator.ComHoursOfOperation] = (double)this.compressor.ReadHoursOfOperation();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the compressor");

                //todo handle exception
            }
        }

        #endregion Methods
    }
}