// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the MessageBoxModel type.
// </summary>
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
        /// The message
        /// </summary>
        private string[] message;

        /// <summary>
        /// The notifications.
        /// </summary>
        private ObservableCollection<Notification> notifications;

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string[] Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public ObservableCollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }
    }
}
