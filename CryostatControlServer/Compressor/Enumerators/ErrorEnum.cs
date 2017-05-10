//-----------------------------------------------------------------------
// <copyright file="ErrorEnum.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for Error states.
    /// </summary>
    public enum ErrorEnum
    {
        /// <summary>
        /// No errors
        /// </summary>
        NoErrors = 0,

        /// <summary>
        /// Coolant in has a too high temperature
        /// </summary>
        CoolantInHigh = -1,

        /// <summary>
        /// The coolant in has a too low temperature
        /// </summary>
        CoolantInLow = -2,

        /// <summary>
        /// The coolant out has a too high temperature
        /// </summary>
        CoolantOutHigh = -4,

        /// <summary>
        /// The coolant out has a too low to temperature
        /// </summary>
        CoolantOutLow = -8,

        /// <summary>
        /// The oil temperature is too high
        /// </summary>
        OilHigh = -16,

        /// <summary>
        /// The oil temperature is too low
        /// </summary>
        OilLow = -32,

        /// <summary>
        /// The helium temperature is too high
        /// </summary>
        HeliumHigh = -64,

        /// <summary>
        /// The helium temperature is too low
        /// </summary>
        HeliumLow = -128,

        /// <summary>
        /// The low pressure is too high
        /// </summary>
        LowPressureHigh = -256,

        /// <summary>
        /// The low pressure it too low
        /// </summary>
        LowPressureLow = -512,

        /// <summary>
        /// The high pressure is too high
        /// </summary>
        HighPressureHigh = -1024,

        /// <summary>
        /// The high pressure is too low
        /// </summary>
        HighPressureLow = -2048,

        /// <summary>
        /// The delta pressure is too high
        /// </summary>
        DeltaPressureHigh = -4096,

        /// <summary>
        /// The delta pressure is too low
        /// </summary>
        DeltaPressureLow = -8192,

        /// <summary>
        /// The motor current is too low
        /// </summary>
        MotorCurrentLow = -16384,

        /// <summary>
        /// The three phase error
        /// </summary>
        ThreePhaseError = -32768,

        /// <summary>
        /// The power supply error
        /// </summary>
        PowerSupplyError = -65536,

        /// <summary>
        /// The static pressure is too high
        /// </summary>
        StaticPressureHigh = -131072,

        /// <summary>
        /// The static pressure is too low
        /// </summary>
        StaticPressureLow = -262144
    }
}