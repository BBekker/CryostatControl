// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoomingModeConverter.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using LiveCharts;

    /// <summary>
    /// Converter for the zooming mode
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class ZoomingModeConverter : IValueConverter
    {
        /// <summary>
        /// Converts the zoomingoption to a string.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ZoomingOptions)value)
            {
                case ZoomingOptions.None:
                    return "is off";
                case ZoomingOptions.X:
                    return "the X-axis";
                case ZoomingOptions.Y:
                    return "the Y-axis";
                case ZoomingOptions.Xy:
                    return "the X- and Y-axis";
                default:
                    return "is off";
            }
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="System.NotImplementedException">Indicates not implemented.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
