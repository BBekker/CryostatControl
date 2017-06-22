// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxViewModel.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System.Collections.ObjectModel;
    using CryostatControlClient.Models;

    /// <summary>
    /// The message box view model.
    /// </summary>
    public class MessageBoxViewModel : AbstractViewModel 
    {
        /// <summary>
        /// The max amount of notifications showing in the GUI.
        /// </summary>
        private const int MaxAmountNotifications = 100;

        /// <summary>
        /// The message box model.
        /// </summary>
        private MessageBoxModel messageBoxModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxViewModel"/> class.
        /// </summary>
        public MessageBoxViewModel()
        {
            this.messageBoxModel = new MessageBoxModel();
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
                this.AddToNotificationList(this.CreateNotification(value));
                this.RaisePropertyChanged("Message");
                this.RaisePropertyChanged("Notifications");
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
                return this.messageBoxModel.Notifications ?? new ObservableCollection<Notification>();
            }

            set
            {
                this.messageBoxModel.Notifications = value;
            }
        }

        /// <summary>
        /// Creates a notification.
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

        /// <summary>
        /// Adds notification to notification list and removes last item if size reached its max.
        /// </summary>
        /// <param name="notification">The notification.</param>
        private void AddToNotificationList(Notification notification)
        {
            ObservableCollection<Notification> notifications = this.Notifications;
            notifications.Insert(0, notification);
            if (notifications.Count > MaxAmountNotifications)
            {
               notifications.RemoveAt(notifications.Count - 1);
            }

            this.Notifications = notifications;
        }
    }
}
