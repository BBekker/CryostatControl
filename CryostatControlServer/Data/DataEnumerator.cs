//-----------------------------------------------------------------------
// <copyright file="DataEnumerator.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Data
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Enumerator for the Compressor values
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum DataEnumerator
    {
        LakePlate50K = 0,
        LakePlate3K = 1,

        ComWaterIn = 2,
        ComWaterOut = 3,
        ComHelium = 4,
        ComOil = 5,
        ComLow = 6,
        ComLowAvg = 7,
        ComHigh = 8,
        ComHighAvg = 9,
        ComDeltaAvg = 10,

        He3Pump = 11,
        HePlate2K = 12,
        HePlate4K = 13,
        He3Head = 14,
        He4Pump = 15,
        He4SwitchTemp = 16,
        He3SwitchTemp = 17,
        He4Head = 18,

        He3VoltActual = 19,
        He4SwitchVoltActual = 20,
        He3SwitchVoltActual = 21,
        He4VoltActual = 22,

        SensorAmount = 23,

        HeConnectionState = 23,
        ComConnectionState = 24,
        LakeConnectionState = 25,

        ComError = 26,
        ComWarning = 27,
        ComHoursOfOperation = 28,

        LakeHeater = 29,

        DataLength = 30
    }
}