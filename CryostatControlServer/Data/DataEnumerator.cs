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
        LakeHeater = 2,

        ComWaterIn = 3,
        ComWaterOut = 4,
        ComHelium = 5,
        ComOil = 6,
        ComLow = 7,
        ComLowAvg = 8,
        ComHigh = 9,
        ComHighAvg = 10,
        ComDeltaAvg = 11,

        He3Pump = 12,
        HePlate2K = 13,
        HePlate4K = 14,
        He3Head = 15,
        He4Pump = 16,
        He4SwitchTemp = 17,
        He3SwitchTemp = 18,
        He4Head = 19,

        He3VoltActual = 20,
        He4SwitchVoltActual = 21,
        He3SwitchVoltActual = 22,
        He4VoltActual = 23,

        SensorAmount = 24,

        HeConnectionState = 24,
        ComConnectionState = 25,
        LakeConnectionState = 26,

        ComError = 27,
        ComWarning = 28,
        ComHoursOfOperation = 29,
        ComOperationState = 30,

        DataLength = 31
    }
}