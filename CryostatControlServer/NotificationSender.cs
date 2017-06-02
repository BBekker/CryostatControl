// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationSender.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the NotificationSender type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;

    using CryostatControlServer.HostService;

    /// <summary>
    /// The notification sender.
    /// </summary>
    public class NotificationSender
    {
        /// <summary>
        /// The command service.
        /// </summary>
        private static CommandService commandService;

        /// <summary>
        /// The initialisation of the Notification Sender.
        /// </summary>
        /// <param name="newCommandService">
        /// The new command service.
        /// </param>
        public static void Init(CommandService newCommandService)
        {
            commandService = newCommandService;
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void Error(string time, string data)
        {
            string error = "ERROR";
            string[] message = new[] { time, error, data };
            SendData(message);
        }

        /// <summary>
        /// Warnings the specified tag.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void Warning(string time, string data)
        {
            string warning = "Warning";
            string[] message = new[] { time, warning, data };
            SendData(message);
        }

        /// <summary>
        /// Informations the specified tag.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public static void Info(string time, string data)
        {
            string info = "Info";
            string[] message = new[] { time, info, data };
            SendData(message);
        }

        /// <summary>
        /// The send data.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void SendData(string[] message)
        {
            commandService.UpdateNotification(message);
        }
    }
}
