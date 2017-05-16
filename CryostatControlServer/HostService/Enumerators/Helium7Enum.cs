//-----------------------------------------------------------------------
// <copyright file="Helium7Enum.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService.Enumerators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Enumerator for the BlueFors values
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum Helium7Enum
    {
        ConnectontionState = 0,
        WaterIn = 1,
        WaterOut = 2,
        Helium = 3,
        Oil = 4,
        Low = 5,
        LowAvg = 6,
        High = 7,
        HighAvg = 8,
        DeltaAvg = 9
    }
}