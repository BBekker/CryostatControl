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
        /// Method to check if the host is running
        /// </summary>
        /// <returns>The service state</returns>
        [OperationContract]
        bool IsAlive();

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
        /// Sets the compressor on or off.
        /// <c>true</c> to turn the compressor on.
        /// <c>false</c> to turn the compressor off.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [compressor on] if <c>false</c> [compressor off]</param>
        /// <returns>
        /// <c>true</c> if the status is set
        /// <c>false</c> status could not been set either there is no connection or the compressor is controlled by an automatic process.
        /// </returns>
        [OperationContract]
        bool ControlCompressor(bool status);

        /// <summary>
        /// Writes values to the helium7 heaters.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>
        /// <c>true</c> values could be set.
        /// <c>false</c> values could not be set, either there is no connection,
        /// input values are incorrect or manual control isn't allowed</returns>
        [OperationContract]
        bool WriteHelium7(double[] values);

        /// <summary>
        /// Reads the specified sensor.
        /// </summary>
        /// <param name="id">The identifier of the sensor</param>
        /// <returns>Current value of the sensor</returns>
        [OperationContract]
        float ReadSensor(int id);

        /// <summary>
        /// Reads the compressor temperature scale.
        /// </summary>
        /// <returns>Temperature scale in double</returns>
        [OperationContract]
        double ReadCompressorTemperatureScale();

        /// <summary>
        /// Reads the compressor pressure scale.
        /// </summary>
        /// <returns>Pressure scale in double</returns>
        [OperationContract]
        double ReadCompressorPressureScale();

        /// <summary>
        /// Writes the allowed settings to server.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>If the values have been written</returns>
        [OperationContract]
        bool WriteSettingValues(double[] values);

        #endregion Methods
    }
}