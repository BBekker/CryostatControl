// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingEnumeratorDescription.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   The setting descriptions.
// </summary>
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
                    "He3 heater max voltage used",
                    "He3 switch voltage used",
                    "He4 switch voltage used",
                    "He4 heater max voltage used",
                    "Pump heating start temperature",
                    "Pump heating temperature setpoint",
                    "Heatswitch ON temperature",
                    "Heatswitch safety temperature",
                    "Heatup cycle heater temperature setpoint",
                    "He4 adsorption start temperature",
                    "He3 adsorption start target temperature",
                    "Disable heater when switches are above",
                    "He3 adsorption start minimal temperature",
                    "He3 adsorption maximum wait time"
                };

        /// <summary>
        /// Gets a string with the unit of each setting.
        /// </summary>
        public static string[] UnitStrings
        {
            get;
        }
            =
                {
////                    "V", "V", "V", "V",
                    "V", "V", "V", "V", "K", "K", "K", "K", "K", "K", "K", "K", "K", "min."
                };
    }
}
