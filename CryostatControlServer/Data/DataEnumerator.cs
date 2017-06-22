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
        LakePlate50K,
        LakePlate3K,

        ComWaterIn,
        ComWaterOut,
        ComHelium,
        ComOil,
        ComLow,
        ComLowAvg,
        ComHigh,
        ComHighAvg,
        ComDeltaAvg,

        He3Pump,
        He3Head,
        He3SwitchTemp,
        He4Pump,
        He4Head,
        He4SwitchTemp,
        HePlate2K,
        HePlate4K,

        He3VoltActual,
        He3SwitchVoltActual,
        He4VoltActual,
        He4SwitchVoltActual,

        SensorAmount,

        HeConnectionState = SensorAmount,
        ComConnectionState,
        LakeConnectionState,

        ComError,
        ComWarning,
        ComHoursOfOperation,
        ComOperationState,

        DataLength
    }
}