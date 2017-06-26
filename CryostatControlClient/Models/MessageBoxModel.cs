// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxModel.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The message box model.
    /// </summary>
    public class MessageBoxModel
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string[] Message { get; set; }

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public ObservableCollection<Notification> Notifications { get; set; }
    }
}
