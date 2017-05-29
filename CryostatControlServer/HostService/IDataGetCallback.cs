//-----------------------------------------------------------------------
// <copyright file="IDataGetCallback.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    /// <summary>
    /// Methods which can be used for callbacks.
    /// </summary>
    public interface IDataGetCallback
    {
        #region Methods

        /// <summary>
        /// Sends the data readout.
        /// </summary>
        /// <param name="data">The data.</param>
        [OperationContract(IsOneWay = true)]
        void SendData(double[] data);

        /// <summary>
        /// Sends the data readout.
        /// </summary>
        /// <param name="modus">The modus.</param>
        [OperationContract(IsOneWay = true)]
        void SendModus(int modus);

        /// <summary>
        /// Sets the state of the logging.
        /// </summary>
        /// <param name="status">if set to <c>true</c> logging is active.</param>
        [OperationContract(IsOneWay = true)]
        void SetLoggingState(bool status);

        /// <summary>
        /// Sets the state of the control.
        /// </summary>
        /// <param name="status">if set to <c>true</c> the server is activily controlling the cryostat and manual control is not allowed.</param>
        [OperationContract(IsOneWay = true)]
        void SetCompressorState(bool status);

        #endregion Methods
    }
}