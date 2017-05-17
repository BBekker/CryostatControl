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
        He3Pump = 2,
        He4Head = 3,
        He4Pump = 4,
        He3Volt = 5,
        He4Volt = 6,
        He3SwitchTemp = 7,
        He3SwitchVolt = 8,
        He4SwitchTemp = 9,
        He4SwitchVolt = 10,
        HePlate2K = 11,
        HePlate4K = 12,

        // Compressor
        ComConnectionState = 13,

        ComWaterIn = 14,
        ComWaterOut = 15,
        ComHelium = 16,
        ComOil = 17,
        ComLow = 18,
        ComLowAvg = 19,
        ComHigh = 20,
        ComHighAvg = 21,
        ComDeltaAvg = 22,

        // Lakeshore
        LakeConnectionState = 23,

        LakePlate50K = 24,
        LakePlate3K = 25,
        LakeHeater = 26
    }
}