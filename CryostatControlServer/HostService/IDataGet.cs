//-----------------------------------------------------------------------
// <copyright file="IDataGet.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    /// <summary>
    /// Service contract for subscribing for callback methods
    /// </summary>
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IDataGetCallback))]
    public interface IDataGet
    {
        #region Methods

        /// <summary>
        /// Subscribes for data callback.
        /// </summary>
        /// <param name="interval">The interval.</param>
        [OperationContract(IsOneWay = true)]
        void SubscribeForData(int interval);

        /// <summary>
        /// Unsubscribes for data callback.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void UnsubscribeForData();

        #endregion Methods
    }
}