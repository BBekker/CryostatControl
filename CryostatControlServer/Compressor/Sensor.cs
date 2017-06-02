// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sensor.cs" company="SRON">
//   bla
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   The sensor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Compressor
{
    using CryostatControlServer.Data;

    /// <summary>
    /// The sensor.
    /// </summary>
    public class Sensor : ISensor
    {
        #region Fields

        /// <summary>
        /// The register.
        /// </summary>
        private AnalogRegistersEnum register;

        /// <summary>
        /// The device.
        /// </summary>
        private Compressor device;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor"/> class.
        /// </summary>
        /// <param name="register">
        /// The register.
        /// </param>
        /// <param name="device">
        /// The device.
        /// </param>
        public Sensor(AnalogRegistersEnum register, Compressor device)
        {
            this.register = register;
            this.device = device;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the interval.
        /// Not relevant for this device
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public double Value
        {
            get
            {
                return this.device.ReadDoubleAnalogRegister(this.register);
            }
        }

        #endregion Properties
    }
}