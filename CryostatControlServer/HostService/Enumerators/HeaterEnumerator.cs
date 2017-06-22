//-----------------------------------------------------------------------
// <copyright file="HeaterEnumerator.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService.Enumerators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Enumerator for the heater places
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum HeaterEnumerator
    {
        He3Pump = 0,
        He4Pump = 1,
        He3Switch = 2,
        He4Switch = 3,
        HeaterAmount = 4
    }
}