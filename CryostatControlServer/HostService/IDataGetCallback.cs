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
        /// Sends the BlueFors data.
        /// </summary>
        /// <param name="data">The data.</param>
        [OperationContract(IsOneWay = true)]
        void SendBlueForsData(float[] data);

        /// <summary>
        /// Sends the compressor data.
        /// </summary>
        /// <param name="data">The data.</param>
        [OperationContract(IsOneWay = true)]
        void SendCompressorData(float[] data);

        /// <summary>
        /// Sends the helium7 data.
        /// </summary>
        /// <param name="data">The data.</param>
        [OperationContract(IsOneWay = true)]
        void SendHelium7Data(float[] data);

        #endregion Methods
    }
}