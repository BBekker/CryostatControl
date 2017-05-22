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
    /// <summary>
    /// The sensor.
    /// </summary>
    public class Sensor : ISensor
    {
        /// <summary>
        /// The register.
        /// </summary>
        private AnalogRegistersEnum register;

        /// <summary>
        /// The device.
        /// </summary>
        private Compressor device;

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
                return this.device.ReadAnalogRegister(this.register);
            }
        }
    }
}
