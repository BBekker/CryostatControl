// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AgilentException.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   The agilent exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System.ComponentModel;

    using CryostatControlServer.Logging;

    /// <summary>
    /// The agilent exception.
    /// Thrown when there is an error in communication with the Agilent, or an internal error in the device occurred
    /// </summary>
    public class AgilentException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgilentException"/> class.
        /// </summary>
        public AgilentException() : base("generic agilent error")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgilentException"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public AgilentException(string description)
            : base(description)
        {
            DebugLogger.Error(this.GetType().Name, this.GetType().Name + ": " + description);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgilentException"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public AgilentException(string description, System.Exception innerException)
            : base(description, innerException)
        {
        }
    }
}
