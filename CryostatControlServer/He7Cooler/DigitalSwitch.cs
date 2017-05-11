// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DigitalSwitch.cs" company="SRON">
//   All rights reseverd.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   The digital switches.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The digital switches.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum DigitalSwitch
    {
        SensHe3HeadT = 0,
        SensHe4HeadT = 1,
        PumpHe3 = 2,
        PumpHe4 = 3,
    }
}
