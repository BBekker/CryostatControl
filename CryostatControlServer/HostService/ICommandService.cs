//-----------------------------------------------------------------------
// <copyright file="ICommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.HostService.Enumerators;

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
        /// Start cool down process timed
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// If the cool down process could be started
        /// </returns>
        [OperationContract]
        bool CooldownTime(string time);

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
        /// Go to manual mode
        /// </summary>
        /// <returns>If the server could go to manual mode</returns>
        [OperationContract]
        bool Manual();

        /// <summary>
        /// Cancel the current operation, such as warm up, cool down, recycle and manual.
        /// </summary>
        /// <returns>true if canceled</returns>
        [OperationContract]
        bool Cancel();

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <returns>integer representing the controller state <see cref="Controlstate"/></returns>
        [OperationContract]
        int GetState();

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
        bool SetCompressorState(bool status);

        /// <summary>
        /// Writes values to the helium7 heaters.
        /// <seealso cref="HeaterEnumerator"/> for position for each heater.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>
        /// <c>true</c> values could be set.
        /// <c>false</c> values could not be set, either there is no connection,
        /// input values are incorrect or manual control isn't allowed</returns>
        [OperationContract]
        bool WriteHelium7(double[] values);

        /// <summary>
        /// Reads the compressor temperature scale.
        /// </summary>
        /// <returns>Temperature scale in double <seealso cref="TemperatureEnum"/></returns>
        [OperationContract]
        double ReadCompressorTemperatureScale();

        /// <summary>
        /// Reads the compressor pressure scale.
        /// </summary>
        /// <returns>Pressure scale in double <seealso cref="PressureEnum"/></returns>
        [OperationContract]
        double ReadCompressorPressureScale();

        /// <summary>
        /// Writes the allowed settings to server.
        /// </summary>
        /// <param name="setting">
        /// The setting <see cref="SettingEnumerator"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// If the values have been written
        /// </returns>
        [OperationContract]
        bool WriteSettingValue(int setting, double value);

        /// <summary>
        /// Read all settings, ordered by the SettingEnumerator
        /// </summary>
        /// <returns>
        /// The settings ordered by SettingEnumerator <see cref="double[]"/>.
        /// </returns>
        [OperationContract]
        double[] ReadSettings();

        [OperationContract]
        bool SetBlueforsHeater(bool status);

        #endregion Methods
    }
}