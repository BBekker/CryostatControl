// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionFaultReason.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.HostService.DataContracts
{
    /// <summary>
    /// The fault reason.
    /// </summary>
    public enum ActionFaultReason
    {
        /// <summary>
        /// Not connected to device.
        /// </summary>
        NotConnected,

        /// <summary>
        /// Not ready to issue command.
        /// Device may not be ready yet or server not ready.
        /// </summary>
        NotReady,

        /// <summary>
        /// Server is in automatic mode
        /// </summary>
        NotInManualMode,

        /// <summary>
        /// value was invalid. More info in reason string.
        /// </summary>
        InvalidValue,

        /// <summary>
        /// The unknown value.
        /// </summary>
        Unknown,
    }
}
