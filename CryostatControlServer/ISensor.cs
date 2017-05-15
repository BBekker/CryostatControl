using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer
{
    using System.Data;

    /// <summary>
    /// The Sensor interface.
    /// </summary>
    public interface ISensor
    {
        /// <summary>
        /// Gets or sets the interval data is read at.
        /// </summary>
        int Interval { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        double Value { get; }
    }
}
