//-----------------------------------------------------------------------
// <copyright file="CompressorEnum.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService.Enumerators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Enumerator for the Compressor values
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum DataEnumerator
    {
        // helium cooler
        HeConnectionState = 0,

        He3Head = 1,
        He3HeadMax = 2,
        He3Pump = 3,
        He3PumpMax = 4,
        He4Head = 5,
        He4HeadMax = 6,
        He4PumpMax = 7,
        He4Pump = 8,
        He3Volt = 9,
        He4Volt = 10,
        He3SwitchTemp = 11,
        He3SwitchVolt = 12,
        He3SwitchMax1 = 13,
        He3SwitchMax2 = 14,
        He4SwitchTemp = 15,
        He4SwitchVolt = 16,
        He4SwitchMax1 = 17,
        He4SwitchMax2 = 18,
        HePlate2K = 19,
        HePlate4K = 20,
        HePlate4Kmax1 = 21,
        HePlate4Kmax2 = 22,

        // Compressor
        ComConnectionState = 21,

        ComWaterIn = 22,
        ComWaterOut = 23,
        ComHelium = 24,
        ComOil = 25,
        ComLow = 26,
        ComLowAvg = 27,
        ComHigh = 28,
        ComHighAvg = 29,
        ComDeltaAvg = 30,
        ComError = 31,
        ComWarning = 32,
        ComHoursOfOperation = 33,

        // Lakeshore
        LakeConnectionState = 34,

        LakePlate50K = 35,
        LakePlate3K = 36,
        LakeHeater = 37
    }
}