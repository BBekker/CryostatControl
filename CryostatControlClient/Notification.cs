// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Notification.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the Notification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient
{
    using System.Collections.Specialized;
    using System.Windows.Media;

    using Color = System.Drawing.Color;

    /// <summary>
    /// The notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The time.
        /// </summary>
        private string time;

        /// <summary>
        /// The level indicating Info, Warning or Error.
        /// </summary>
        private string level;

        /// <summary>
        /// The data.
        /// </summary>
        private string data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public Notification(string time, string level, string data)
        {
            this.time = time;
            this.level = level;
            this.data = data;
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public string Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public string Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public string Data
        {
            get
            {
                return this.data;
            }

            set
            {
                this.data = value;
            }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        public SolidColorBrush Color
        {
            get
            {
                switch (this.level)
                {
                    case "Error": return new SolidColorBrush(Colors.Red);
                    case "Warning": return new SolidColorBrush(Colors.Orange);
                    default: return new SolidColorBrush(Colors.Black);
                }
            }
        }
    }
}
