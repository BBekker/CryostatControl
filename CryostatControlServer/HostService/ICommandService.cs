//-----------------------------------------------------------------------
// <copyright file="ICommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    /// <summary>
    /// Interface for the available commands
    /// </summary>
    [ServiceContract]
    public interface ICommandService
    {
        #region Methods

        /// <summary>
        /// Says hello.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Hello string with name</returns>
        [OperationContract]
        string SayHello(string name);

        /// <summary>
        /// Start cool down process
        /// </summary>
        /// <returns>If the cool down process could be started</returns>
        [OperationContract]
        bool Cooldown();

        /// <summary>
        /// Start recycle process
        /// </summary>
        /// <returns>If the recycle process could be started</returns>
        [OperationContract]
        bool Recycle();

        /// <summary>
        /// Start warm up process
        /// </summary>
        /// <returns>If the warm up process could be started</returns>
        [OperationContract]
        bool Warmup();

        /// <summary>
        /// Reads the specified sensor.
        /// </summary>
        /// <param name="id">The identifier of the sensor</param>
        /// <returns>Current value of the sensor</returns>
        [OperationContract]
        float ReadSensor(int id);

        /// <summary>
        /// Sets the specified sensor to the given value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns>If the value could be set or not</returns>
        [OperationContract]
        bool UpdateSensor(int id, float value);

        #endregion Methods
    }
}