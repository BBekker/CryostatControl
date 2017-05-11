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
        // Temperature sensors
        SensHe3PumpT = 101,
        Sens2KplateT = 104,
        Sens4KplateT = 105,
        SensHe3HeadT = 107,
        SensHe4PumpT = 106,
        SensHe4SwitchT = 102,
        SensHe3SwitchT = 103,
        SensHe4HeadT = 108,

        // Heater sensors
        SensHe3Pump = 110,
        SensHe4Switch = 111,
        SensHe3Switch = 112,
        SensHe4Pump = 109,

        // Digital Channel
        CtrlDigOut = 201,

        // Heaters
        PumpHe3 = 204,
        PumpHe4 = 205,
        SwitchHe3 = 305,
        SwitchHe4 = 304,
    }
}