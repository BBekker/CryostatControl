// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Control.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the Control type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Control class, controls the cryostat using a state machine.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// The compressor
        /// </summary>
        private Compressor.Compressor compressor;

        /// <summary>
        /// The H7 cooler
        /// </summary>
        private He7Cooler.He7Cooler cooler;

        /// <summary>
        /// The lakeshore.
        /// </summary>
        private LakeShore.LakeShore lakeshore;

        /// <summary>
        /// The state.
        /// </summary>
        private Controlstate state = Controlstate.Setup;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        /// <param name="cooler">
        /// The cooler.
        /// </param>
        /// <param name="ls">
        /// The ls.
        /// </param>
        /// <param name="compressor">
        /// The compressor.
        /// </param>
        public Controller(He7Cooler.He7Cooler cooler, LakeShore.LakeShore ls, Compressor.Compressor compressor)
        {
            this.cooler = cooler;
            this.lakeshore = ls;
            this.compressor = compressor;
        }

        /// <summary>
        /// Gets or sets the he 3 heater voltage.
        /// </summary>
        public double He3HeaterVoltage { get; set; } = 6.0;

        /// <summary>
        /// Gets or sets the he 3 switch voltage.
        /// </summary>
        public double He3SwitchVoltage { get; set; } = 3.0;

        /// <summary>
        /// Gets or sets the he 4 heater voltage.
        /// </summary>
        public double He4HeaterVoltage { get; set; } = 10.0;

        /// <summary>
        /// Gets or sets the he 4 switch voltage.
        /// </summary>
        public double He4SwitchVoltage { get; set; } = 4.0;

        /// <summary>
        /// Gets or sets the he 7 start temperature.
        /// </summary>
        public double He7StartTemperature { get; set; } = 70.0;

        /// <summary>
        /// Gets or sets the heater temperature set point.
        /// </summary>
        public double HeaterTemperatureSetpoint { get; set; } = 35.0;

        /// <summary>
        /// Gets or sets the heat switch on temperature.
        /// </summary>
        public double HeatSwitchOnTemperature { get; set; } = 15.0;

        /// <summary>
        /// Gets or sets the heat switch safe value.
        /// </summary>
        public double HeatSwitchSafeValue { get; set; } = 9.0;

        /// <summary>
        /// Gets or sets the heat up temperature.
        /// </summary>
        public double HeatupTemperature { get; set; } = 50.0;

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public Controlstate State
        {
            get
            {
                return this.state;
            }

            private set
            {
                Console.WriteLine("[Control] Switched from state {0} to {1}", this.state, value);
                this.state = value;
            }
        }

        /// <summary>
        /// Starts the cool down id possible.
        /// </summary>
        /// <returns>true if cool down is started, false otherwise</returns>
        public bool StartCooldown()
        {
            if (this.State == Controlstate.Standby)
            {
                this.State = Controlstate.CooldownStart;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Starts the heat up.
        /// </summary>
        /// <returns>true if heat up is started, false otherwise</returns>
        public bool StartHeatup()
        {
            if (this.State == Controlstate.Standby)
            {
                this.State = Controlstate.WarmupStart;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Starts a recycle.
        /// </summary>
        /// <returns>true if recycle is started, false otherwise</returns>
        public bool StartRecycle()
        {
            if (this.State == Controlstate.Standby)
            {
                this.State = Controlstate.RecycleStart;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Switch to manual control. Can only be started from Standby.
        /// </summary>
        /// <returns>
        /// true if switched to manual control, false otherwise <see cref="bool"/>.
        /// </returns>
        public bool StartManualControl()
        {
            if (this.State == Controlstate.Standby)
            {
                this.State = Controlstate.Manual;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Cancels the current command safely.
        /// </summary>
        public void CancelCommand()
        {
            this.State = Controlstate.CancelAll;
        }

        /// <summary>
        /// Control a heater
        /// Uses a simple P controllerfor the last part, might be updated to PI later.
        /// </summary>
        /// <param name="heater">
        /// The heater.
        /// </param>
        /// <param name="sensor">
        /// The temperature sensor.
        /// </param>
        /// <param name="TSet">
        /// The temperature set point
        /// </param>
        /// <param name="voltage">
        /// The voltage used to control the heater.
        /// </param>
        [SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1306:FieldNamesMustBeginWithLowerCaseLetter",
            Justification = "SI naming, T is uppercase")]
        private void ControlHeater(He7Cooler.He7Cooler.Heater heater, ISensor sensor, double TSet, double voltage)
        {
            double kP = voltage * 0.2;
            if (sensor.Value < TSet)
            {
                heater.Voltage = Math.Min(voltage, (TSet - sensor.Value) * kP);
            }
            else
            {
                heater.Voltage = 0.0;
            }
        }

        /// <summary>
        /// Checks if the heat switches are allowed to be turned on.
        /// If the cooler temperature is too high, the heaters are turned off.
        /// </summary>
        private void SafetyCheckHeatSwitch()
        {
            if (this.cooler.Plate4KT.Value > this.HeatSwitchSafeValue && this.cooler.He4Switch.Voltage > 0.2)
            {
                this.cooler.He4Switch.Voltage = 0.0;
            }

            if (this.cooler.Plate4KT.Value > this.HeatSwitchSafeValue && this.cooler.He3Switch.Voltage > 0.2)
            {
                this.cooler.He3Switch.Voltage = 0.0;
            }
        }

        /// <summary>
        /// Safety check of the pump heaters.
        /// If the cooler is to warm, the heaters are turned off
        /// </summary>
        private void SafetyCheckPumps()
        {
            if (this.cooler.Plate4KT.Value > 70.0 && this.cooler.He3Pump.Voltage > 0.2)
            {
                this.cooler.He3Pump.Voltage = 0.0;
            }

            if (this.cooler.Plate4KT.Value > 70.0 && this.cooler.He4Pump.Voltage > 0.2)
            {
                this.cooler.He4Pump.Voltage = 0.0;
            }
        }

        /// <summary>
        /// The state machine that controls the heater.
        /// Controls the Cool down, Heat up and Recycle processes, by walking trough a state machine.
        /// State should not be modified by external classes.
        /// </summary>
        /// <para>
        /// State machine design
        /// The entire state machine is intentionally placed in a single function.
        /// Use of the State pattern was considered but rejected for clarity and maintainability. 
        /// The design of the state machine is discussed in github:
        /// https://github.com/BBekker/CryostatControl/pull/88
        /// access can be requested by emailing: Bernard@BernardBekker.nl
        /// </para>
        /// <para>
        /// States
        /// To view all states see <see cref="Controlstate"/>
        /// </para>
        private void StateMachine()
        {
            this.SafetyCheckHeatSwitch();
            this.SafetyCheckPumps();

            switch (this.State)
            {
                case Controlstate.Setup:
                    if (this.cooler != null && this.lakeshore != null && this.compressor != null)
                    {
                        this.State = Controlstate.Standby;
                    }

                    break;

                case Controlstate.Standby: break;

                case Controlstate.Manual: break;

                case Controlstate.CooldownStart:
                    this.State = Controlstate.CooldownWaitForPressure;
                    break;

                case Controlstate.CooldownWaitForPressure:
                    // TODO: wait for pressure when sensor is connected
                    this.State = Controlstate.CooldownStartCompressor;
                    break;

                case Controlstate.CooldownStartCompressor:
                    try
                    {
                        this.compressor.TurnOn();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Compressor gave error: " + ex);
                    }

                    this.State = Controlstate.CooldownWait70K;
                    break;

                case Controlstate.CooldownWait70K:
                    if (this.cooler.He3PumpT.Value < this.He7StartTemperature
                        || this.cooler.He4PumpT.Value < this.He7StartTemperature)
                    {
                        this.State = Controlstate.CooldownWait4K;
                    }

                    break;

                case Controlstate.CooldownWait4K:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He4Pump,
                        this.cooler.He4PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He4HeaterVoltage);
                    if (this.cooler.He3HeadT.Value < 4.0 && this.cooler.He4HeadT.Value < 4.0)
                    {
                        this.State = Controlstate.CooldownCondenseHe4;
                    }

                    break;

                case Controlstate.CooldownCondenseHe4:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He4Pump,
                        this.cooler.He4PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He4HeaterVoltage);
                    if (this.cooler.He4HeadT.Value < 4.0)
                    {
                        this.State = Controlstate.CooldownTurnOffHe4;
                    }

                    break;

                case Controlstate.CooldownTurnOffHe4:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);
                    this.cooler.He4Pump.Voltage = 0.0;
                    this.State = Controlstate.CooldownControlHe4Switch;
                    break;

                case Controlstate.CooldownControlHe4Switch:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);

                    if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.cooler.He4Switch.Voltage = this.He4SwitchVoltage;
                    }

                    if (this.cooler.He4SwitchT.Value > this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownCondenseHe3;
                    }

                    break;

                case Controlstate.CooldownCondenseHe3:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);
                    if (this.cooler.He3HeadT.Value < 2.0)
                    {
                        this.State = Controlstate.CooldownDisableHe3PumpHeater;
                    }

                    break;

                case Controlstate.CooldownDisableHe3PumpHeater:
                    this.cooler.He3Pump.Voltage = 0.0;
                    this.State = Controlstate.CooldownControlHe3;
                    break;

                case Controlstate.CooldownControlHe3:
                    if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.cooler.He3Switch.Voltage = this.He3SwitchVoltage;
                    }

                    if (this.cooler.He3SwitchT.Value > this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownFinished;
                    }

                    break;

                case Controlstate.CooldownFinished:
                    this.State = Controlstate.Standby;
                    break;

                case Controlstate.RecycleStart:
                    this.cooler.He3Switch.Voltage = 0.0;
                    this.cooler.He3Switch.Voltage = 0.0;

                    this.State = Controlstate.RecycleHeatPumps;
                    break;

                case Controlstate.RecycleHeatPumps:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He3HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He4Pump,
                        this.cooler.He4PumpT,
                        this.HeaterTemperatureSetpoint,
                        this.He4HeaterVoltage);
                    if (this.cooler.He3PumpT.Value > this.HeaterTemperatureSetpoint - 1.0
                        && this.cooler.He4PumpT.Value > this.HeaterTemperatureSetpoint - 1.0)
                    {
                        this.State = Controlstate.CooldownTurnOffHe4;
                    }

                    break;

                case Controlstate.WarmupStart:
                    // TODO: start Lakeshore heater?
                    break;

                case Controlstate.WarmupHeating:
                    this.ControlHeater(
                        this.cooler.He3Pump,
                        this.cooler.He3PumpT,
                        this.HeatupTemperature,
                        this.He3HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He4Pump,
                        this.cooler.He4PumpT,
                        this.HeatupTemperature,
                        this.He4HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He3Switch,
                        this.cooler.He3SwitchT,
                        this.HeatupTemperature,
                        this.He4HeaterVoltage);
                    this.ControlHeater(
                        this.cooler.He4Switch,
                        this.cooler.He4SwitchT,
                        this.HeatupTemperature,
                        this.He4HeaterVoltage);
                    if (this.cooler.He4PumpT.Value > this.HeatupTemperature - 1.0)
                    {
                        this.State = Controlstate.WarmupFinished;
                    }

                    break;

                case Controlstate.WarmupFinished:
                    this.State = Controlstate.Standby;
                    break;

                case Controlstate.CancelAll:
                    this.cooler.He3Pump.Voltage = 0.0;
                    this.cooler.He4Pump.Voltage = 0.0;

                    // Keep switches on if cold, turn off otherwise.
                    if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.cooler.He3Switch.Voltage = this.He3SwitchVoltage;
                        this.cooler.He4Switch.Voltage = this.He4SwitchVoltage;
                    }
                    else
                    {
                        this.cooler.He3Switch.Voltage = 0.0;
                        this.cooler.He4Switch.Voltage = 0.0;
                    }

                    this.State = Controlstate.Standby;
                    break;
            }
        }
    }
}