// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Notification.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient
{
    using System;
    using System.Globalization;
    using System.Windows.Media;

    /// <summary>
    /// The notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The unknown type.
        /// </summary>
        private const string UnknownType = "Unknown";

        /// <summary>
        /// The time.
        /// </summary>
        private string time;

        /// <summary>
        /// The level indicating Info, Warning or Error.
        /// </summary>
        private string level;

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
            this.Time = time;
            this.Level = level;
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time
        {
            get
            {
                return this.time;
            }

            set
            {
                if (this.IsATime(value))
                {
                    this.time = value;
                }
                else
                {
                    this.time = UnknownType;
                }
            }
        }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public string Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (this.IsALevel(value))
                {
                    this.level = value;
                }
                else
                {
                    this.level = UnknownType;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public string Data { get; set; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
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

        /// <summary>
        /// Determines whether [time] is [the specified time].
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        ///   <c>true</c> if [time] is [the specified time]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsATime(string time)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None,  out dateTime);
        }

        /// <summary>
        /// Determines whether [level] is [the specified level].
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns>
        ///   <c>true</c> if [level] is [the specified level]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsALevel(string level)
        {
            switch (level)
            {
                case "Info": return true;
                case "Warning": return true;
                case "Error": return true;
                default: return false;
            }
        }
    }
}
