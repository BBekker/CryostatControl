// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="SRON">
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
    using System.Threading;

    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;
    using CryostatControlServer.Properties;

    /// <summary>
    /// Control class, controls the cryostat using a state machine.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// The timer period.
        /// </summary>
        private readonly int timerPeriod = 5000;

        /// <summary>
        /// The compressor
        /// </summary>
        private Compressor.Compressor compressor;

        /// <summary>
        /// The control timer.
        /// </summary>
        private Timer controlTimer;

        /// <summary>
        /// The H7 cooler
        /// </summary>
        private He7Cooler.He7Cooler cooler;

        /// <summary>
        /// The lakeshore.
        /// </summary>
        private LakeShore.LakeShore lakeshore;

        /// <summary>
        /// The start time.
        /// </summary>
        private DateTime startTime = DateTime.Now;

        /// <summary>
        /// The state.
        /// </summary>
        private Controlstate state = Controlstate.Setup;

        /// <summary>
        /// The time when the current state was entered
        /// </summary>
        private DateTime stateEnteredTime = DateTime.Now;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class. 
        /// </summary>
        /// <param name="cooler">
        /// The cooler.
        /// </param>
        /// <param name="ls">
        /// The Lake Shore instance.
        /// </param>
        /// <param name="compressor">
        /// The compressor.
        /// </param>
        public Controller(He7Cooler.He7Cooler cooler, LakeShore.LakeShore ls, Compressor.Compressor compressor)
        {
            this.cooler = cooler;
            this.lakeshore = ls;
            this.compressor = compressor;

            this.StartStateMachine();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Controller"/> class.
        /// </summary>
        ~Controller()
        {
            this.StopStateMachine();
        }

        /// <summary>
        /// Gets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 heater voltage.
        /// </summary>
        public double He3HeaterPower
        {
            get
            {
                return Settings.Default.ControllerHe3HeaterPower;
            }

            set
            {
                Settings.Default.ControllerHe3HeaterPower = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch voltage.
        /// </summary>
        public double He3SwitchVoltage
        {
            get
            {
                return Settings.Default.ControllerHe3SwitchVoltage;
            }

            set
            {
                Settings.Default.ControllerHe3SwitchVoltage = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 heater voltage.
        /// </summary>
        public double He4HeaterPower
        {
            get
            {
                return Settings.Default.ControllerHe4HeaterPower;
            }

            set
            {
                Settings.Default.ControllerHe4HeaterPower = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 start temperature.
        /// </summary>
        public double He4StartTemperature
        {
            get
            {
                return Settings.Default.ControllerHe4StartTemperature;
            }

            set
            {
                Settings.Default.ControllerHe4StartTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch voltage.
        /// </summary>
        public double He4SwitchVoltage
        {
            get
            {
                return Settings.Default.ControllerHe4SwitchVoltage;
            }

            set
            {
                Settings.Default.ControllerHe4SwitchVoltage = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 7 start temperature.
        /// </summary>
        public double He7StartTemperature
        {
            get
            {
                return Settings.Default.ControllerHe7StartTemperature;
            }

            set
            {
                Settings.Default.ControllerHe7StartTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the heater temperature set point.
        /// </summary>
        public double HeaterTemperatureSetpoint
        {
            get
            {
                return Settings.Default.ControllerHeaterTemperatureSetpoint;
            }

            set
            {
                Settings.Default.ControllerHeaterTemperatureSetpoint = value;
            }
        }

        /// <summary>
        /// Gets or sets the heat switch on temperature.
        /// </summary>
        public double HeatSwitchOnTemperature
        {
            get
            {
                return Settings.Default.ControllerHeatSwitchOnTemperature;
            }

            set
            {
                Settings.Default.ControllerHeatSwitchOnTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the heat switch safe value.
        /// </summary>
        public double HeatSwitchSafeValue
        {
            get
            {
                return Settings.Default.ControllerHeatSwitchSafeValue;
            }

            set
            {
                Settings.Default.ControllerHeatSwitchSafeValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the heat up temperature.
        /// </summary>
        public double HeatupTemperature
        {
            get
            {
                return Settings.Default.ControllerHeatupTemperature;
            }

            set
            {
                Settings.Default.ControllerHeatupTemperature = value;
            }
        }

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
                string message = "[Control] Switched from state " + this.state + " to " + value;
                DebugLogger.Info(this.GetType().Name, message);
                this.stateEnteredTime = DateTime.Now;
                this.state = value;
            }
        }

        /// <summary>
        /// Gets or sets the disable heater heat switch temperature.
        /// </summary>
        private double DisableHeaterHeatSwitchTemperature
        {
            get
            {
                return Settings.Default.ControllerDisableHeaterHeatSwitchTemperature;
            }

            set
            {
                Settings.Default.ControllerDisableHeaterHeatSwitchTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 start temperature.
        /// </summary>
        private double He3StartMinimalTemperature
        {
            get
            {
                return Settings.Default.ControllerHe3StartMinimalTemperature;
            }

            set
            {
                Settings.Default.ControllerHe3StartMinimalTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 start temperature.
        /// </summary>
        private double He3StartTemperature
        {
            get
            {
                return Settings.Default.ControllerHe3StartTemperature;
            }

            set
            {
                Settings.Default.ControllerHe3StartTemperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 start temperature.
        /// </summary>
        private double He3StartWaitTimeMinutes
        {
            get
            {
                return Settings.Default.ControllerHe3StartWaitTimeMinutes;
            }

            set
            {
                Settings.Default.ControllerHe3StartWaitTimeMinutes = value;
            }
        }

        /// <summary>
        /// Cancels the current command safely.
        /// </summary>
        public void CancelCommand()
        {
            this.State = Controlstate.CancelAll;
        }

        /// <summary>
        /// Starts the cool down id possible.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        /// true if cool down is started, false otherwise
        /// </returns>
        public bool StartCooldown(DateTime time)
        {
            if (this.State == Controlstate.Standby)
            {
                this.startTime = time;
                this.State = Controlstate.CooldownStart;
                Console.WriteLine($"Starting cooldown at: {time}");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Starts the heat up.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        /// true if heat up is started, false otherwise
        /// </returns>
        public bool StartHeatup(DateTime time)
        {
            if (this.State == Controlstate.Standby)
            {
                this.startTime = time;
                this.State = Controlstate.WarmupStart;
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
        /// Starts a recycle.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>
        /// true if recycle is started, false otherwise
        /// </returns>
        public bool StartRecycle(DateTime time)
        {
            if (this.State == Controlstate.Standby)
            {
                this.startTime = time;
                this.State = Controlstate.RecycleStart;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Controls the he3 pump heater.
        /// </summary>
        private void ControlHe3PumpHeater()
        {
            if (this.cooler.He3SwitchT.Value < this.DisableHeaterHeatSwitchTemperature)
            {
                this.SetHeaterTemperature(this.cooler.He3Pump, this.HeaterTemperatureSetpoint, this.He3HeaterPower);
            }
            else
            {
                this.SetHeaterVoltage(this.cooler.He3Pump, 0.0);
            }
        }

        /// <summary>
        /// Controls the he4 pump heater.
        /// </summary>
        private void ControlHe4PumpHeater()
        {
            if (this.cooler.He4SwitchT.Value < this.DisableHeaterHeatSwitchTemperature)
            {
                this.SetHeaterTemperature(this.cooler.He4Pump, this.HeaterTemperatureSetpoint, this.He4HeaterPower);
            }
            else
            {
                this.SetHeaterVoltage(this.cooler.He4Pump, 0.0);
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
                this.SetHeaterVoltage(this.cooler.He4Switch, 0.0);
            }

            if (this.cooler.Plate4KT.Value > this.HeatSwitchSafeValue && this.cooler.He3Switch.Voltage > 0.2)
            {
                this.SetHeaterVoltage(this.cooler.He3Switch, 0.0);
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
                this.SetHeaterVoltage(this.cooler.He3Pump, 0.0);
            }

            if (this.cooler.Plate4KT.Value > 70.0 && this.cooler.He4Pump.Voltage > 0.2)
            {
                this.SetHeaterVoltage(this.cooler.He4Pump, 0.0);
            }
        }

        /// <summary>
        /// The set heater voltage capturing any errors.
        /// </summary>
        /// <param name="heater">
        /// The heater.
        /// </param>
        /// <param name="voltage">
        /// The voltage.
        /// </param>
        private void SetHeaterVoltage(He7Cooler.He7Cooler.Heater heater, double voltage)
        {
            try
            {
                heater.TemperatureControlEnabled = false;
                heater.Voltage = voltage;
            }
            catch (Exception ex)
            {
                DebugLogger.Error(this.GetType().Name, "Error while setting heater: " + ex.Message);
            }
        }

        private void SetHeaterTemperature(He7Cooler.He7Cooler.Heater heater, double temperature, double maxpower)
        {
            heater.TemperatureSetpoint = temperature;
            try
            {
                heater.PowerLimit = maxpower;
            }
            catch (ArgumentOutOfRangeException e)
            {
                DebugLogger.Error("heater", e.Message, true);
                DebugLogger.Error("Controller", "Tried to set too high power setting to heater!, not heating!", true);
            }
            heater.TemperatureControlEnabled = true;
        }

        /// <summary>
        /// Start the thread running the state machine.
        /// </summary>
        private void StartStateMachine()
        {
            this.controlTimer = new Timer(timerState => this.StateMachine(), null, 0, this.timerPeriod);
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

                case Controlstate.Standby:
                    break;

                case Controlstate.Manual:
                    break;

                case Controlstate.CooldownStart:
                    this.lakeshore.SetHeater(false);
                    if (DateTime.Now > this.startTime)
                    {
                        this.State = Controlstate.CooldownWaitForPressure;
                    }
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
                        DebugLogger.Error(this.GetType().Name, "Compressor gave error: " + ex);
                    }

                    this.State = Controlstate.CooldownWait70K;
                    break;

                case Controlstate.CooldownWait70K:
                    if (this.cooler.He3PumpT.Value < this.He7StartTemperature
                        || this.cooler.He4PumpT.Value < this.He7StartTemperature)
                    {
                        this.State = Controlstate.CooldownWaitSwitches;
                    }

                    break;

                case Controlstate.CooldownWaitSwitches:
                    this.SetHeaterTemperature(this.cooler.He3Pump, this.HeaterTemperatureSetpoint, Settings.Default.ControllerHeaterLowPowerValue);
                    this.SetHeaterTemperature(this.cooler.He4Pump, this.HeaterTemperatureSetpoint, Settings.Default.ControllerHeaterLowPowerValue);

                    if (this.cooler.He3SwitchT.Value < this.HeatSwitchOnTemperature
                        && this.cooler.He4SwitchT.Value < this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownWait4K;
                    }
                    break;

                case Controlstate.CooldownWait4K:
                    this.ControlHe3PumpHeater();
                    this.ControlHe4PumpHeater();
                    if (this.cooler.He3HeadT.Value < this.He4StartTemperature
                        && this.cooler.He4HeadT.Value < this.He4StartTemperature)
                    {
                        this.State = Controlstate.CooldownCondenseHe4;
                    }

                    break;

                case Controlstate.CooldownCondenseHe4:
                    this.ControlHe3PumpHeater();
                    this.ControlHe4PumpHeater();
                    if (this.cooler.He4HeadT.Value < this.He4StartTemperature)
                    {
                        this.State = Controlstate.CooldownTurnOffHe4;
                    }

                    break;

                case Controlstate.CooldownTurnOffHe4:
                    this.ControlHe3PumpHeater();
                    this.SetHeaterVoltage(this.cooler.He4Pump, 0.0);
                    this.State = Controlstate.CooldownControlHe4Switch;
                    break;

                case Controlstate.CooldownControlHe4Switch:
                    this.ControlHe3PumpHeater();

                    if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.cooler.He4Switch.Voltage = this.He4SwitchVoltage;
                    }

                    if (this.cooler.He4SwitchT.Value > this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownWaitHe3Heater;
                    }

                    break;

                case Controlstate.CooldownWaitHe3Heater:
                    this.ControlHe3PumpHeater();
                    if (this.cooler.He3PumpT.Value > this.HeaterTemperatureSetpoint * 0.8 &&
                        this.cooler.He3PumpT.Value > 25.0)
                    {
                        this.state = Controlstate.CooldownDisableHe3PumpHeater;
                    }

                    break;

                case Controlstate.CooldownDisableHe3PumpHeater:
                    this.SetHeaterVoltage(this.cooler.He3Pump, 0.0);
                    this.State = Controlstate.CooldownCondenseHe3;
                    break;

                case Controlstate.CooldownCondenseHe3:
                    if (this.cooler.He3HeadT.Value < this.He3StartTemperature
                        || (this.cooler.He3HeadT.Value < this.He3StartMinimalTemperature
                            && (DateTime.Now - this.stateEnteredTime)
                            > new TimeSpan(0, (int)this.He3StartWaitTimeMinutes, 0)))
                    {
                        this.State = Controlstate.CooldownControlHe3;
                    }

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
                    if (DateTime.Now > this.startTime)
                    {
                        this.SetHeaterVoltage(this.cooler.He3Switch, 0.0);
                        this.SetHeaterVoltage(this.cooler.He4Switch, 0.0);
                        this.compressor.TurnOn();

                        this.State = Controlstate.RecycleHeatPumps;
                    }

                    break;

                case Controlstate.RecycleHeatPumps:
                    this.ControlHe3PumpHeater();
                    this.ControlHe4PumpHeater();
                    if (this.cooler.He3PumpT.Value > this.HeaterTemperatureSetpoint - 1.0
                        && this.cooler.He4PumpT.Value > this.HeaterTemperatureSetpoint - 1.0)
                    {
                        this.State = Controlstate.CooldownCondenseHe4;
                    }

                    break;

                case Controlstate.WarmupStart:
                    if (DateTime.Now > this.startTime)
                    {
                        try
                        {
                            this.lakeshore.SetHeater(true);
                        }
                        catch (Exception)
                        {
                            DebugLogger.Warning(this.GetType().Name, "lakeshore did not respond");
                        }

                        try
                        {
                            this.compressor.TurnOff();
                        }
                        catch (Exception)
                        {
                            DebugLogger.Warning(this.GetType().Name, "Compressor not connected, make sure it is turned off!");
                        }

                        this.State = Controlstate.WarmupHeating;
                    }

                    break;

                case Controlstate.WarmupHeating:

                    this.SetHeaterTemperature(this.cooler.He3Pump, this.HeatupTemperature, Settings.Default.ControllerHe3HeaterPower);
                    this.SetHeaterTemperature(this.cooler.He4Pump, this.HeatupTemperature, Settings.Default.ControllerHe4HeaterPower);
                    this.cooler.He3Switch.Voltage = this.He3SwitchVoltage;
                    this.cooler.He4Switch.Voltage = this.He4SwitchVoltage;

                    if (this.cooler.He4PumpT.Value > this.HeatupTemperature
                        && this.cooler.He3PumpT.Value > this.HeatupTemperature
                        && this.cooler.He4SwitchT.Value > this.HeatupTemperature
                        && this.cooler.He3SwitchT.Value > this.HeatupTemperature)
                    {
                        this.State = Controlstate.WarmupFinished;
                    }

                    break;

                case Controlstate.WarmupFinished:
                    this.State = Controlstate.Standby;
                    break;

                case Controlstate.CancelAll:
                    
                    this.SetHeaterVoltage(this.cooler.He3Pump, 0.0);
                    this.SetHeaterVoltage(this.cooler.He4Pump, 0.0);

                    // Keep switches and compressor on if cold, turn off otherwise.
                    if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue && 
                        this.cooler.He3Switch.Voltage > this.HeatSwitchOnTemperature &&
                        this.cooler.He4Switch.Voltage > this.HeatSwitchOnTemperature)
                    {
                        this.cooler.He3Switch.Voltage = this.He3SwitchVoltage;
                        this.cooler.He4Switch.Voltage = this.He4SwitchVoltage;
                        try
                        {
                            this.compressor.TurnOn();
                        }
                        catch (Exception)
                        {
                            DebugLogger.Warning(this.GetType().Name, "Compressor not turning on");
                        }
                    }
                    else
                    {
                        this.SetHeaterVoltage(this.cooler.He3Switch, 0.0);
                        this.SetHeaterVoltage(this.cooler.He4Switch, 0.0);
                        try
                        {
                            this.compressor.TurnOff();
                        }
                        catch (Exception)
                        {
                            DebugLogger.Warning(this.GetType().Name, "Compressor not turning off");
                        }
                    }

                    this.lakeshore.SetHeater(false);

                    this.State = Controlstate.Standby;
                    break;
            }
        }

        /// <summary>
        /// Stop the thread running the state machine.
        /// </summary>
        private void StopStateMachine()
        {
            this.controlTimer.Dispose();
        }
    }
}
