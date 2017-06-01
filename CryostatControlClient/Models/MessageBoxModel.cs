﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBoxModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the MessageBoxModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
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
    }
}