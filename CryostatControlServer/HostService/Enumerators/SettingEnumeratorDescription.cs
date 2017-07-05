// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingEnumeratorDescription.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.HostService.Enumerators
{
    /// <summary>
    /// The setting descriptions.
    /// </summary>
    public static class SettingEnumeratorDescription
    {
        /// <summary>
        /// Gets description strings of each setting, matches with settingEnumerator
        /// </summary>
        /// <value>
        /// The description strings.
        /// </value>
        public static string[] DescriptionStrings
        {
            get;
        }
            =
                {
////                    "He3 pump heater max voltage",
////                    "He4 pump heater max voltage",
////                    "He4 Switch max voltage",
////                    "He3 Switch max voltage",
                    "He3 heater max power used",
                    "He4 heater max power used",
                    "He3 switch voltage used",
                    "He4 switch voltage used",
                    "Pump heating start temperature",
                    "Pump heating temperature setpoint",
                    "Heatswitch ON temperature",
                    "Heatswitch safety temperature",
                    "Heatup cycle heater temperature setpoint",
                    "He4 adsorption start temperature",
                    "He3 adsorption start target temperature",
                    "Disable heater when switches are above",
                    "He3 adsorption start minimal temperature",
                    "He3 adsorption maximum wait time",
                    "Heater power while waiting for switches"
                };

        /// <summary>
        /// Gets a string with the unit of each setting.
        /// </summary>
        /// <value>
        /// The unit strings.
        /// </value>
        public static string[] UnitStrings
        {
            get;
        }
            =
                { "W", "W", "V", "V", "K", "K", "K", "K", "K", "K", "K", "K", "K", "min.", "W" };
    }
}
