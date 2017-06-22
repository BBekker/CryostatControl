// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISensor.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Data
{
    /// <summary>
    /// The Sensor interface.
    /// </summary>
    public interface ISensor
    {
        #region Properties

        /// <summary>
        /// Gets or sets the interval data is read at.
        /// </summary>
        int Interval { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        double Value { get; }

        #endregion Properties
    }
}