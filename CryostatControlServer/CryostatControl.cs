// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CryostatControl.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.Data;
    using CryostatControlServer.HostService.Enumerators;
    using CryostatControlServer.Logging;

    /// <summary>
    /// Class which handles all the request by the client.
    /// </summary>
    public class CryostatControl
    {
        #region Fields

        /// <summary>
        /// The data read out
        /// </summary>
        private readonly DataReader dataReader;

        /// <summary>
        /// The compressor
        /// </summary>
        private readonly Compressor.Compressor compressor;

        /// <summary>
        /// The lake shore
        /// </summary>
        private readonly LakeShore.LakeShore lakeShore;

        /// <summary>
        /// The he7 cooler
        /// </summary>
        private readonly He7Cooler.He7Cooler he7Cooler;

        /// <summary>
        /// The controller.
        /// </summary>
        private readonly Controller controller;

        /// <summary>
        /// The heaters
        /// </summary>
        private readonly He7Cooler.He7Cooler.Heater[] heaters = new He7Cooler.He7Cooler.Heater[(int)HeaterEnumerator.HeaterAmount];

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CryostatControl"/> class.
        /// </summary>
        /// <param name="compressor">
        /// The compressor.
        /// </param>
        /// <param name="lakeShore">
        /// The lake shore.
        /// </param>
        /// <param name="he7Cooler">
        /// The he7 cooler.
        /// </param>
        /// <param name="controller">
        /// The controller.
        /// </param>
        public CryostatControl(
            Compressor.Compressor compressor,
            LakeShore.LakeShore lakeShore,
            He7Cooler.He7Cooler he7Cooler,
            Controller controller)
        {
            this.compressor = compressor;
            this.lakeShore = lakeShore;
            this.he7Cooler = he7Cooler;
            this.controller = controller;
            this.dataReader = new DataReader(this.compressor, this.he7Cooler, this.lakeShore);
            this.FillHeaters();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="CryostatControl"/> class.
        /// </summary>
        public CryostatControl()
        {
        }

        /// <summary>
        /// Gets the state of the controller.
        /// </summary>
        /// <returns>The controller state <see cref="Controlstate"/></returns>
        public Controlstate ControllerState
        {
            get
            {
                return this.controller.State;
            }
        }

        /// <summary>
        /// Gets a value indicating whether Manual control is allowed or not
        /// </summary>
        private bool ManualControl
        {
            get
            {
                return this.ControllerState == Controlstate.Manual;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The read heater power.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double ReadBlueforsHeaterPower()
        {
            return this.lakeShore.GetHeaterPower();
        }

        /// <summary>
        /// Cancels the current command safely.
        /// </summary>
        public void CancelCommand()
        {
            this.controller.CancelCommand();
        }

        /// <summary>
        /// Starts the cool down id possible.
        /// </summary>
        /// <returns>true if cool down is started, false otherwise</returns>
        public bool StartCooldown()
        {
            return this.controller.StartCooldown(DateTime.Now);
        }

        /// <summary>
        /// Starts the cool down id possible.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <returns>
        /// true if cool down is started, false otherwise
        /// </returns>
        public bool StartCooldown(string time)
        {
            return this.controller.StartCooldown(DateTime.Parse(time));
        }

        /// <summary>
        /// Starts the heat up.
        /// </summary>
        /// <returns>true if heat up is started, false otherwise</returns>
        public bool StartHeatup()
        {
            return this.controller.StartHeatup();
        }

        /// <summary>
        /// Switch to manual control. Can only be started from Standby.
        /// </summary>
        /// <returns>
        /// true if switched to manual control, false otherwise <see cref="bool"/>.
        /// </returns>
        public bool StartManualControl()
        {
            return this.controller.StartManualControl();
        }

        /// <summary>
        /// Starts a recycle.
        /// </summary>
        /// <returns>true if recycle is started, false otherwise</returns>
        public bool StartRecycle()
        {
            return this.controller.StartRecycle();
        }

        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <returns>data array with sensor values</returns>
        public double[] ReadData()
        {
            return this.dataReader.GetDataArray();
        }

        /// <summary>
        /// Turn bluefors heater on or off.
        /// </summary>
        /// <param name="status">
        /// The status.
        /// </param>
        /// <returns>
        /// True if successfully executed <see cref="bool"/>.
        /// </returns>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        public bool SetBlueforsHeater(bool status)
        {
            if (!this.ManualControl)
            {
                return false;
            }

            this.lakeShore.SetHeater(true);
            return true;
        }

        /// <summary>
        /// Turns the compressor on or off.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [on].</param>
        /// <returns>
        /// <c>true</c> if the status is set.
        /// <c>false</c> status could not been set, either is has no connection or manual control isn't allowed.
        /// </returns>
        public bool SetCompressorState(bool status)
        {
            if (!this.ManualControl)
            {
                return false;
            }

            try
            {
                if (status)
                {
                    this.compressor.TurnOn();
                }
                else
                {
                    this.compressor.TurnOff();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong setting compressor state");

#if DEBUG
                Console.WriteLine("Exception thrown: {0}", e);
#endif
                return false;
            }

            return true;
        }

        /// <summary>
        /// Writes values to the helium7 heaters.
        /// <seealso cref="HeaterEnumerator"/> for position for each heater.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>
        /// <c>true</c> values could be set.
        /// <c>false</c> values could not be set, either there is no connection,
        /// input values are incorrect or manual control isn't allowed</returns>
        public bool WriteHelium7Heaters(double[] values)
        {
            ////todo add safety check, what happens if a wrong value is set.

            if (values.Length != (int)HeaterEnumerator.HeaterAmount || !this.ManualControl)
            {
                return false;
            }

            bool status = true;

            for (int i = 0; i < values.Length; i++)
            {
                try
                {
                    this.heaters[i].Voltage = values[i];
                }
                catch (Exception e)
                {
                    status = false;
                    Console.WriteLine("Sensor {0} could not be set", i);
#if DEBUG
                    Console.WriteLine("Exception thrown: {0}", e);
#endif
                }
            }

            return status;
        }

        /// <summary>
        /// Reads the compressor temperature scale.
        /// </summary>
        /// <returns>Temperature scale in double <seealso cref="TemperatureEnum"/></returns>
        public double ReadCompressorTemperatureScale()
        {
            return (double)this.compressor.ReadTemperatureScale();
        }

        /// <summary>
        /// Reads the compressor pressure scale.
        /// </summary>
        /// <returns>Pressure scale in double <seealso cref="PressureEnum"/></returns>
        public double ReadCompressorPressureScale()
        {
            return (double)this.compressor.ReadPressureScale();
        }

        /// <summary>
        /// Fills the heaters.
        /// <seealso cref="HeaterEnumerator"/> for the position of each heater
        /// </summary>
        private void FillHeaters()
        {
            this.heaters[(int)HeaterEnumerator.He3Pump] = this.he7Cooler.He3Pump;
            this.heaters[(int)HeaterEnumerator.He4Pump] = this.he7Cooler.He4Pump;
            this.heaters[(int)HeaterEnumerator.He3Switch] = this.he7Cooler.He3Switch;
            this.heaters[(int)HeaterEnumerator.He4Switch] = this.he7Cooler.He4Switch;
        }

        #endregion Methods
    }
}