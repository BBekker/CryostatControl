// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the MessageBoxViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Documents;

    using CryostatControlClient.Models;

    /// <summary>
    /// The message box view model.
    /// </summary>
    public class MessageBoxViewModel : AbstractViewModel
    {
        /// <summary>
        /// The message box model.
        /// </summary>
        private MessageBoxModel messageBoxModel;

        private List<Notification> notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxViewModel"/> class.
        /// </summary>
        public MessageBoxViewModel()
        {
            this.messageBoxModel = new MessageBoxModel();
            this.notifications = new List<Notification>();
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string[] Message
        {
            get
            {
                return this.messageBoxModel.Message;
            }

            set
            {
                this.messageBoxModel.Message = value;
                this.notifications.Add(this.CreateNotification(value));
                this.RaisePropertyChanged("Message");
                this.RaisePropertyChanged("MessageAttributes");
                this.RaisePropertyChanged("MessageAttributesCount");
            } 
        }

        /// <summary>
        /// Gets the message attributes.
        /// </summary>
        public List<Notification> MessageAttributes
        {
            get
            {
                return this.notifications;
            }
        }

        /// <summary>
        /// Gets the message attributes count.
        /// </summary>
        public int MessageAttributesCount
        {
            get
            {
                return this.notifications.Count - 1;
            }
        }

        /// <summary>
        /// The create notification.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="Notification"/>.
        /// </returns>
        public Notification CreateNotification(string[] data)
        {
            Notification notification = new Notification(data[0], data[1], data[2]);
            return notification;
        }


    }
}
