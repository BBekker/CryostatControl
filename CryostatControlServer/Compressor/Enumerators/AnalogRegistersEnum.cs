//-----------------------------------------------------------------------
// <copyright file="AnalogRegistersEnum.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for analog input registers
    /// </summary>
    public enum AnalogRegistersEnum
    {
        /// <summary>
        /// The operating state register
        /// </summary>
        OperatingState = 1,

        /// <summary>
        /// The energy state register
        /// </summary>
        EnergyState = 2,

        /// <summary>
        /// The warning state register
        /// </summary>
        WarningState = 3,

        /// <summary>
        /// The error state register
        /// </summary>
        ErrorState = 5,

        /// <summary>
        /// The coolant in temperature register
        /// </summary>
        CoolantInTemp = 7,

        /// <summary>
        /// The coolant out temperature register
        /// </summary>
        CoolantOutTemp = 9,

        /// <summary>
        /// The oil temperature register
        /// </summary>
        OilTemp = 11,

        /// <summary>
        /// The helium temperature register
        /// </summary>
        HeliumTemp = 13,

        /// <summary>
        /// The low pressure register
        /// </summary>
        LowPressure = 15,

        /// <summary>
        /// The low pressure average register
        /// </summary>
        LowPressureAvg = 17,

        /// <summary>
        /// The high pressure register
        /// </summary>
        HighPressure = 19,

        /// <summary>
        /// The high pressure average register
        /// </summary>
        HighPressureAvg = 21,

        /// <summary>
        /// The delta pressure average register
        /// </summary>
        DeltaPressureAvg = 23,

        /// <summary>
        /// The motor current register
        /// </summary>
        MotorCurrent = 25,

        /// <summary>
        /// The hours of operation register
        /// </summary>
        HoursOfOperation = 27,

        /// <summary>
        /// The pressure scale register
        /// </summary>
        PressureScale = 29,

        /// <summary>
        /// The temperature scale register
        /// </summary>
        TempScale = 30,

        /// <summary>
        /// The panel serial number register
        /// </summary>
        PanelSerialNumber = 31,

        /// <summary>
        /// The model number register
        /// </summary>
        Model = 32
    }
}