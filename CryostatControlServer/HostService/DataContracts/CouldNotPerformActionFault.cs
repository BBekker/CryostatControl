﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CouldNotPerformActionFault.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.HostService.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    using CryostatControlServer.Logging;

    /// <summary>
    /// The could not perform action fault.
    /// </summary>
    [DataContract]
    [Serializable]
    public class CouldNotPerformActionFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CouldNotPerformActionFault"/> class.
        /// </summary>
        /// <param name="reason">
        /// The reason.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public CouldNotPerformActionFault(ActionFaultReason reason, string message)
        {
            this.Message = message;
            this.Operation = "not set";
            this.Reason = reason;
            DebugLogger.Error(this.GetType().Name, reason + " => " + message);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CouldNotPerformActionFault"/> class.
        /// </summary>
        /// <param name="reason">
        /// The reason.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="operation">
        /// The operation.
        /// </param>
        public CouldNotPerformActionFault(ActionFaultReason reason, string message, string operation)
        {
            this.Message = message;
            this.Operation = operation;
            this.Reason = reason;
            DebugLogger.Error(this.GetType().Name, reason + " => " + message);
        }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [DataMember]
        public ActionFaultReason Reason { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>
        /// The operation.
        /// </value>
        [DataMember]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember]
        public string Message { get; set; }
    }
}