//-----------------------------------------------------------------------
// <copyright file="BlueForsEnum.cs" company="SRON">
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
    public enum BlueForsEnum
    {
        ConnectionState = 0,
        Plate50K = 1,
        Plate3K = 2,
        Heater = 3
    }
}