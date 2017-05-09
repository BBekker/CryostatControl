//-----------------------------------------------------------------------
// <copyright file="Compressor.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    using System;
    using System.Net.Sockets;
    using Modbus.Device;

    internal class Compressor
    {
        #region Fields

        /// <summary>
        /// The slave
        /// </summary>
        private const byte Slave = 1;

        /// <summary>
        /// The port
        /// </summary>
        private const ushort Port = 502;

        private const ushort Single = 1;

        private const ushort Double = 2;

        /// <summary>
        ///
        /// </summary>
        private readonly ModbusIpMaster _master;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        public Compressor(String address)
        {
            TcpClient client = new TcpClient(address, Port);
            _master = ModbusIpMaster.CreateIp(client);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///
        /// </summary>
        public void TurnOn()
        {
            ushort on = 0x001;
            _master.WriteSingleRegister(Slave, (ushort)HoldingRegistersEnum.Control, on);
            Console.WriteLine("Compressor turned on");
        }

        /// <summary>
        ///
        /// </summary>
        public void TurnOff()
        {
            ushort off = 0x00FF;
            _master.WriteSingleRegister(Slave, (ushort)HoldingRegistersEnum.Control, off);
            Console.WriteLine("Compressor turned off");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public String ReadOnOff()
        {
            ushort[] status = _master.ReadHoldingRegisters((ushort)HoldingRegistersEnum.Control, Single);
            return status[0].ToString();
        }

        public StatusEnum ReadOperatingState()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.OperatingState, Single);
            return (StatusEnum)status[0];
        }

        public EnergizedEnum ReadEnergyState()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.EnergyState, Single);
            return (EnergizedEnum)status[0];
        }

        public WarningsEnum ReadWarningState()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.WarningState, Double);
            return (WarningsEnum)ParseFloat(status);
        }

        public ErrorEnum ReadErrorState()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.ErrorState, Double);
            return (ErrorEnum)ParseFloat(status);
        }

        public float ReadCoolInTemp()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.CoolantInTemp, Double);
            return ParseFloat(status);
        }

        public float ReadCoolOutTemp()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.CoolantOutTemp, Double);
            return ParseFloat(status);
        }

        public float ReadOilTemp()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.OilTemp, Double);
            return ParseFloat(status);
        }

        public float ReadHeliumTemp()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.HeliumTemp, Double);
            return ParseFloat(status);
        }

        public float ReadLowPressure()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.LowPressure, Double);
            return ParseFloat(status);
        }

        public float ReadLowPressureAverage()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.LowPressureAvg, Double);
            return ParseFloat(status);
        }

        public float ReadHighPressure()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.HighPressure, Double);
            return ParseFloat(status);
        }

        public float ReadHighPressureAverage()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.HighPressureAvg, Double);
            return ParseFloat(status);
        }

        public float ReadDeltaPressureAverage()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.DeltaPressureAvg, Double);
            return ParseFloat(status);
        }

        public float ReadMotorCurrent()
        {
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.MotorCurrent, Double);
            return ParseFloat(status);
        }

        public PressureEnum ReadPressureScale()
        {
            //todo: check
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.PressureScale, Single);
            return (PressureEnum)status[0];
        }

        public TemperatureEnum ReadTemperatureScale()
        {
            //todo: check
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.TempScale, Single);
            return (TemperatureEnum)status[0];
        }

        public ushort ReadPanelSerialNumber()
        {
            //todo: check
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.PanelSerialNumber, Single);
            return status[0];
        }

        public byte[] ReadModel()
        {
            //todo: check
            ushort[] status = _master.ReadInputRegisters((ushort)AnalogRegistersEnum.Model, Single);
            byte[] bytes = BitConverter.GetBytes(status[0]);
            return bytes;
        }

        private float ParseFloat(ushort[] input)
        {
            Console.WriteLine("eerste {0}", input[0]);
            Console.WriteLine("tweede {0}", input[1]);
            byte[] bytes1 = BitConverter.GetBytes(input[0]);
            byte[] bytes2 = BitConverter.GetBytes(input[1]);
            byte[] arbyWorker = new byte[4];
            arbyWorker[3] = bytes2[1];
            arbyWorker[2] = bytes2[0];
            arbyWorker[1] = bytes1[1];
            arbyWorker[0] = bytes1[0];
            return BitConverter.ToSingle(arbyWorker, 0);
        }

        #endregion Methods
    }
}