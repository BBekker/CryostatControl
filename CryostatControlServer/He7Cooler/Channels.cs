// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Channels.cs" company="SRON">
// SRON 2017.
// </copyright>
// <summary>
//   used DAQ channels.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// used DAQ channels.
    /// </summary> 
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum Channels
    {
        // Digital Channel
        CtrlDigOut = 201,

        // Heaters
        PumpHe3 = 204,

        PumpHe4 = 205,

        Sens2KplateT = 104,

        Sens4KplateT = 105,

        SensHe3HeadT = 107,

        // Heater sensors
        SensHe3Pump = 110,

        SensHe3PumpT = 101,

        SensHe3Switch = 112,

        SensHe3SwitchT = 103,

        SensHe4HeadT = 108,

        SensHe4Pump = 109,

        // Temperature sensors
        SensHe4PumpT = 106,

        SensHe4Switch = 111,

        SensHe4SwitchT = 102,

        SwitchHe3 = 305,

        SwitchHe4 = 304,
    }
}
