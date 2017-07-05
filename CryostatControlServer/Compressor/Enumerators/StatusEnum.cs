//-----------------------------------------------------------------------
// <copyright file="StatusEnum.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for status
    /// </summary>
    public enum StatusEnum
    {
        /// <summary>
        /// The idling state
        /// </summary>
        Idling = 0,

        /// <summary>
        /// The starting state
        /// </summary>
        Starting = 2,

        /// <summary>
        /// The running state
        /// </summary>
        Running = 3,

        /// <summary>
        /// The stopping state
        /// </summary>
        Stopping = 5,

        /// <summary>
        /// The error lockout state
        /// </summary>
        ErrorLockout = 6,

        /// <summary>
        /// The error state
        /// </summary>
        Error = 7,

        /// <summary>
        /// The helium cool down state
        /// </summary>
        HeliumCoolDown = 8,

        /// <summary>
        /// The error power related state
        /// </summary>
        ErrorPowerRelated = 9,

        /// <summary>
        /// The error recovery state
        /// </summary>
        ErrorRecovery = 16
    }
}