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

    /// <summary>
    /// Compressor class, which contains the functions for the compressor.
    /// </summary>
    internal class Compressor
    {
        #region Fields

        /// <summary>
        /// The Slave number, needed for identification.
        /// </summary>
        private const byte Slave = 1;

        /// <summary>
        /// The standard port for MODBUS communication.
        /// </summary>
        private const ushort Port = 502;

        /// <summary>
        /// SingleRegister for limiting number of registers.
        /// </summary>
        private const ushort SingleRegister = 1;

        /// <summary>
        /// DoubleRegister for limiting number of registers.
        /// </summary>
        private const ushort DoubleRegister = 2;

        /// <summary>
        /// Master instance where MODBUS calls can be called on.
        /// </summary>
        private readonly ModbusIpMaster master;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Compressor"/> class.
        /// </summary>
        /// <param name="address">The IP address of the compressor.</param>
        public Compressor(string address)
        {
            TcpClient client = new TcpClient(address, Port);
            this.master = ModbusIpMaster.CreateIp(client);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Turns the compressor on.
        /// </summary>
        public void TurnOn()
        {
            const ushort on = 0x001;
            this.master.WriteSingleRegister(Slave, (ushort)HoldingRegistersEnum.Control, on);
            Console.WriteLine("Compressor turned on");
        }

        /// <summary>
        /// Turns the compressor off.
        /// </summary>
        public void TurnOff()
        {
            const ushort off = 0x00FF;
            this.master.WriteSingleRegister(Slave, (ushort)HoldingRegistersEnum.Control, off);
            Console.WriteLine("Compressor turned off");
        }

        /// <summary>
        /// Reads if the compressor is set on or off.
        /// </summary>
        /// <returns>
        ///     0 if no value is set.
        ///     1 if the compressor is set on.
        ///     255 if the compressor is set off.
        /// </returns>
        public ushort ReadOnOff()
        {
            ushort[] status = this.master.ReadHoldingRegisters((ushort)HoldingRegistersEnum.Control, SingleRegister);
            return status[0];
        }

        /// <summary>
        /// Reads the operating state of the compressor.
        /// </summary>
        /// <returns>Returns the enumerator <see cref="StatusEnum"/> </returns>
        public StatusEnum ReadOperatingState()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.OperatingState, SingleRegister);
            return (StatusEnum)status[0];
        }

        /// <summary>
        /// Reads the energy state of the compressor.
        /// </summary>
        /// <returns>Returns the enumerator <see cref="EnergizedEnum"/> </returns>
        public EnergizedEnum ReadEnergyState()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.EnergyState, SingleRegister);
            return (EnergizedEnum)status[0];
        }

        /// <summary>
        /// Reads the warning state of the compressor.
        /// </summary>
        /// <returns>Returns the enumerator <see cref="WarningsEnum"/> </returns>
        public WarningsEnum ReadWarningState()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.WarningState, DoubleRegister);
            return (WarningsEnum)this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the error state of the compressor.
        /// </summary>
        /// <returns>Returns the enumerator <see cref="ErrorEnum"/> </returns>
        public ErrorEnum ReadErrorState()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.ErrorState, DoubleRegister);
            return (ErrorEnum)this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the incoming cooling water temperature of the compressor.
        /// </summary>
        /// <returns>Returns incoming cooling water temperature.</returns>
        public float ReadCoolInTemp()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.CoolantInTemp, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the outgoing cooling water temperature of the compressor.
        /// </summary>
        /// <returns>Returns outgoing cooling water temperature.</returns>
        public float ReadCoolOutTemp()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.CoolantOutTemp, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the oil temperature of the compressor.
        /// </summary>
        /// <returns>Returns oil temperature.</returns>
        public float ReadOilTemp()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.OilTemp, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the helium temperature of the compressor.
        /// </summary>
        /// <returns>Returns helium temperature.</returns>
        public float ReadHeliumTemp()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.HeliumTemp, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the low pressure of the compressor.
        /// </summary>
        /// <returns>Returns low pressure.</returns>
        public float ReadLowPressure()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.LowPressure, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the low pressure average of the compressor.
        /// </summary>
        /// <returns>Returns low pressure average.</returns>
        public float ReadLowPressureAverage()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.LowPressureAvg, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the high pressure of the compressor.
        /// </summary>
        /// <returns>Returns high pressure.</returns>
        public float ReadHighPressure()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.HighPressure, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the high average pressure of the compressor.
        /// </summary>
        /// <returns>Returns high average pressure.</returns>
        public float ReadHighPressureAverage()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.HighPressureAvg, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the delta average pressure of the compressor.
        /// </summary>
        /// <returns>Returns delta average pressure.</returns>
        public float ReadDeltaPressureAverage()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.DeltaPressureAvg, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the motor current of the compressor.
        /// </summary>
        /// <returns>Returns motor current.</returns>
        public float ReadMotorCurrent()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.MotorCurrent, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the hours of operation of the compressor.
        /// </summary>
        /// <returns>Hours of operation</returns>
        public float ReadHoursOfOperation()
        {
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.HoursOfOperation, DoubleRegister);
            return this.ParseFloat(status);
        }

        /// <summary>
        /// Reads the pressure scale of the compressor.
        /// </summary>
        /// <returns>Pressure scale.</returns>
        public PressureEnum ReadPressureScale()
        {
            ////todo: check
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.PressureScale, SingleRegister);
            return (PressureEnum)status[0];
        }

        /// <summary>
        /// Reads the temperature scale of the compressor.
        /// </summary>
        /// <returns>Temperature scale.</returns>
        public TemperatureEnum ReadTemperatureScale()
        {
            ////todo: check
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.TempScale, SingleRegister);
            return (TemperatureEnum)status[0];
        }

        /// <summary>
        /// Reads the panel serial number.
        /// </summary>
        /// <returns>Panel Serial number.</returns>
        public ushort ReadPanelSerialNumber()
        {
            ////todo: check
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.PanelSerialNumber, SingleRegister);
            return status[0];
        }

        /// <summary>
        /// Reads the model number.
        /// </summary>
        /// <returns>Model number.</returns>
        public byte[] ReadModel()
        {
            ////todo: check
            ushort[] status = this.master.ReadInputRegisters((ushort)AnalogRegistersEnum.Model, SingleRegister);
            byte[] bytes = BitConverter.GetBytes(status[0]);
            return bytes;
        }

        /// <summary>
        /// Helper method for converting the incoming <see cref="ushort"/> into floats. By shifting the bytes.
        /// </summary>
        /// <param name="input">array with two <see cref="ushort"/> variables</param>
        /// <returns>float number from the two<see cref="ushort"/></returns>
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