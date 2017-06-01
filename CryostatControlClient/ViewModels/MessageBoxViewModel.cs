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
    using System.Collections.ObjectModel;
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

        /// <summary>
        /// The notifications.
        /// </summary>
        private ObservableCollection<Notification> notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxViewModel"/> class.
        /// </summary>
        public MessageBoxViewModel()
        {
            this.messageBoxModel = new MessageBoxModel();
            this.notifications = new ObservableCollection<Notification>();
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
                this.notifications.Insert(0, this.CreateNotification(value));
                this.RaisePropertyChanged("Message");
                this.RaisePropertyChanged("MessageAttributes");
            } 
        }

        /// <summary>
        /// Gets the message attributes.
        /// </summary>
        public ObservableCollection<Notification> MessageAttributes
        {
            get
            {
                return this.notifications;
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
