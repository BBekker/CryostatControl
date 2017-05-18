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

    /// <summary>
    /// The agilent exception.
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
