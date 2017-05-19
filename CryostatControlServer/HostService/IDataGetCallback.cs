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

        #endregion Methods
    }
}