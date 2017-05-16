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
    public enum CompressorEnum
    {
        ConnectionState = 0,
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
        Plate2K = 11,
        Plate4K = 12
    }
}