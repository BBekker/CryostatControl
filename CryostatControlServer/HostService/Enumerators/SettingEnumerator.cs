// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingEnumerator.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   List of all settings
//   Make sure these names EXACTLY match those in settings property, ordering doesn't matter
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.HostService.Enumerators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// List of all settings
    /// Make sure these names EXACTLY match those in settings property, ordering doesn't matter
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum SettingEnumerator
    {
        He3PumpMaxVoltage,
        He4PumpMaxVoltage,
        He4SwitchMaxVoltage,
        He3SwitchMaxVoltage,
        ControllerHe3HeaterVoltage,
        ControllerHe3SwitchVoltage,
        ControllerHe4SwitchVoltage,
        ControllerHe4HeaterVoltage,
        ControllerHe7StartTemperature,
        ControllerHeaterTemperatureSetpoint,
        ControllerHeatSwitchOnTemperature,
        ControllerHeatSwitchSafeValue,
        ControllerHeatupTemperature,
    }
}
