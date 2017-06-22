//-----------------------------------------------------------------------
// <copyright file="TemperatureEnum.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for the temperature scale
    /// </summary>
    public enum TemperatureEnum
    {
        /// <summary>
        /// The fahrenheit scale
        /// </summary>
        Fahrenheit = 0,

        /// <summary>
        /// The celsius scale
        /// </summary>
        Celsius = 1,

        /// <summary>
        /// The kelvin scale
        /// </summary>
        Kelvin = 2
    }
}