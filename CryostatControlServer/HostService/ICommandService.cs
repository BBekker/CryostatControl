//-----------------------------------------------------------------------
// <copyright file="ICommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using CryostatControlServer.HostService.DataContracts;

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
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "IsAlive")]
        [OperationContract]
        bool IsAlive();

        /// <summary>
        /// Start cool down process
        /// </summary>
        /// <returns>If the cool down process could be started</returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool CooldownTime(DateTime time);


        /// <summary>
        /// Start recycle process
        /// </summary>
        /// <returns>If the recycle process could be started</returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        bool Recycle();

        /// <summary>
        /// Start recycle process
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        /// If the recycle process could be started
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool RecycleTime(DateTime time);

        /// <summary>
        /// Start warm up process
        /// </summary>
        /// <returns>If the warm up process could be started</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool Warmup();

        /// <summary>
        /// Start warm up process
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        /// If the warm up process could be started
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool WarmupTime(DateTime time);

        /// <summary>
        /// Go to manual mode
        /// </summary>
        /// <returns>If the server could go to manual mode</returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        bool Manual();

        /// <summary>
        /// Cancel the current operation, such as warm up, cool down, recycle and manual.
        /// </summary>
        /// <returns>true if canceled</returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        bool Cancel();

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <returns>integer representing the controller state <see cref="Controlstate"/></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool SetCompressorState(bool status);

        /// <summary>
        /// Writes values to the helium7 heaters.
        /// <seealso cref="HeaterEnumerator"/>
        /// for position for each heater.
        /// </summary>
        /// <param name="heater">
        /// The heater.
        /// <seealso cref="HeaterEnumerator"/>
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// <c>true</c> values could be set.
        /// <c>false</c> values could not be set, either there is no connection,
        /// input values are incorrect or manual control isn't allowed
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CouldNotPerformActionFault))]
        bool WriteHelium7(int heater, double value);

        /// <summary>
        /// Get a sensor value
        /// </summary>
        /// <param name="sensor">
        /// The sensor.
        /// <see cref="DataEnumerator"/> for all sensor numbers
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "value/{sensor}/")]
        double GetValue(string sensor);

        /// <summary>
        /// Reads the compressor temperature scale.
        /// </summary>
        /// <returns>Temperature scale in double <seealso cref="TemperatureEnum"/></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        double ReadCompressorTemperatureScale();

        /// <summary>
        /// Reads the compressor pressure scale.
        /// </summary>
        /// <returns>Pressure scale in double <seealso cref="PressureEnum"/></returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        double ReadCompressorPressureScale();

        /// <summary>
        /// Read the lakeshore/Bluefors heater power.
        /// </summary>
        /// <returns>
        /// The power in percentage of max power<see cref="double"/>.
        /// </returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        double ReadBlueforsHeaterPower();

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
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        bool WriteSettingValue(int setting, double value);

        /// <summary>
        /// Read all settings, ordered by the SettingEnumerator
        /// </summary>
        /// <returns>
        /// The settings ordered by SettingEnumerator <see cref="double[]"/>.
        /// </returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        double[] ReadSettings();

        /// <summary>
        /// Sets the bluefors heater.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <returns>if the value could be set</returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        bool SetBlueforsHeater(bool status);

        /// <summary>
        /// Reads the single sensor.
        /// </summary>
        /// <param name="sensorId">The sensor identifier.</param>
        /// <returns>The value of the sensor or NaN if no value could be read</returns>
        [OperationContract]
        double ReadSingleSensor(int sensorId);

        /// Starts the logging.
        /// </summary>
        /// <param name="interval">
        /// The interval in milliseconds.
        /// </param>
        /// <param name="logData">
        /// Array which tells which data be logged
        /// <seealso cref="DataEnumerator"/>
        /// for the places of the sensors
        /// </param>
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void StartLogging(int interval, bool[] logData);

        /// <summary>
        /// Stops the logging.
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void CancelLogging();

        /// <summary>
        /// Determines whether this instance is logging.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is logging; otherwise, <c>false</c>.
        /// </returns>
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        bool IsLogging();

        #endregion Methods
    }
}