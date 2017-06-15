//-----------------------------------------------------------------------
// <copyright file="TimerPackage.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    /// <summary>
    /// Data class to hold the data needed in the Timer, as only one parameter can be sent,
    /// the required data needs to be wrapped into a single class.
    /// </summary>
    public class TimerPackage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerPackage"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="waitTime">The wait time.</param>
        public TimerPackage(string key, IDataGetCallback callback, int waitTime)
        {
            this.Key = key;
            this.Callback = callback;
            this.WaitTime = waitTime;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the callback.
        /// </summary>
        /// <value>
        /// The callback.
        /// </value>
        public IDataGetCallback Callback { get; set; }

        /// <summary>
        /// Gets or sets the wait time.
        /// </summary>
        /// <value>
        /// The wait time.
        /// </value>
        public int WaitTime { get; set; }
    }
}