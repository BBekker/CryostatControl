//-----------------------------------------------------------------------
// <copyright file="WarningsEnum.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for the warnings
    /// </summary>
    public enum WarningsEnum
    {
        /// <summary>
        /// No warnings
        /// </summary>
        NoWarnings = 0,

        /// <summary>
        /// The coolant in temperature running high
        /// </summary>
        CoolantInRunningHigh = -1,

        /// <summary>
        /// The coolant in temperature running low
        /// </summary>
        CoolantInRunningLow = -2,

        /// <summary>
        /// The coolant out temperature running high
        /// </summary>
        CoolantOutRunningHigh = -4,

        /// <summary>
        /// The coolant out temperature running low
        /// </summary>
        CoolantOutRunningLow = -8,

        /// <summary>
        /// The oil temperature running high
        /// </summary>
        OilRunningHigh = -16,

        /// <summary>
        /// The oil temperature running low
        /// </summary>
        OilRunningLow = -32,

        /// <summary>
        /// The helium temperature running high
        /// </summary>
        HeliumRunningHigh = -64,

        /// <summary>
        /// The helium temperature running low
        /// </summary>
        HeliumRunningLow = -128,

        /// <summary>
        /// The low pressure running high
        /// </summary>
        LowPressureRunningHigh = -256,

        /// <summary>
        /// The low pressure running low
        /// </summary>
        LowPressureRunningLow = -512,

        /// <summary>
        /// The high pressure running high
        /// </summary>
        HighPressureRunningHigh = -1024,

        /// <summary>
        /// The high pressure running low
        /// </summary>
        HighPressureRunningLow = -2048,

        /// <summary>
        /// The delta pressure running high
        /// </summary>
        DeltaPressureRunningHigh = -4096,

        /// <summary>
        /// The delta pressure running low
        /// </summary>
        DeltaPressureRunningLow = -8192,

        /// <summary>
        /// The static pressure running high
        /// </summary>
        StaticPressureRunningHigh = -131072,

        /// <summary>
        /// The static pressure running low
        /// </summary>
        StaticPressureRunningLow = -262144,

        /// <summary>
        /// The cold head motor stall
        /// </summary>
        ColdHeadMotorStall = -524288
    }
}