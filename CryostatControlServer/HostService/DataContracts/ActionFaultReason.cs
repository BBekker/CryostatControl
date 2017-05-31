// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionFaultReason.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   The fault reason.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.HostService.DataContracts
{
    /// <summary>
    /// The fault reason.
    /// </summary>
    public enum ActionFaultReason
    {
        /// <summary>
        /// not connected to device.
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
        /// The unknown.
        /// </summary>
        Unknown,
    }
}
