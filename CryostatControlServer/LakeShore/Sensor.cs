// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sensor.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the Sensor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.LakeShore
{
    /// <summary>
    /// The sensor.
    /// </summary>
    public class Sensor : ISensor
    {
        /// <summary>
        /// The sensor id.
        /// </summary>
        private SensorEnum sensorId;

        /// <summary>
        /// The device.
        /// </summary>
        private LakeShore device;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor"/> class.
        /// </summary>
        /// <param name="sensorId">
        /// The sensor id.
        /// </param>
        /// <param name="device">
        /// The device.
        /// </param>
        public Sensor(SensorEnum sensorId, LakeShore device)
        {
            this.sensorId = sensorId;
            this.device = device;
        }

        /// <summary>
        /// Gets or sets the interval.
        /// This is ignored for now.
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public double Value
        {
            get
            {
                return this.device.SensorValues[(int)this.sensorId];
            }
        }
    }
}
