// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.Threading;

    using CryostatControlServer.Logging;
    using CryostatControlServer.Properties;

    /// <summary>
    /// Control class, controls the cryostat using a state machine.
    /// </summary>
    public partial class Controller
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
        /// The He7 cooler
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
        /// Gets or sets the he 3 heater voltage.
        /// </summary>
        /// <value>
        /// The he3 heater power.
        /// </value>
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
        /// <value>
        /// The he3 switch voltage.
        /// </value>
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
        /// <value>
        /// The he4 heater power.
        /// </value>
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
        /// <value>
        /// The he4 start temperature.
        /// </value>
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
        /// <value>
        /// The he4 switch voltage.
        /// </value>
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
        /// <value>
        /// The he7 start temperature.
        /// </value>
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
        /// <value>
        /// The heater temperature setpoint.
        /// </value>
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
        /// <value>
        /// The heat switch on temperature.
        /// </value>
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
        /// <value>
        /// The heat switch safe value.
        /// </value>
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
        /// <value>
        /// The heatup temperature.
        /// </value>
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
        /// <value>
        /// The disable heater heat switch temperature.
        /// </value>
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
        /// <value>
        /// The he3 start minimal temperature.
        /// </value>
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
        /// <value>
        /// The he3 start temperature.
        /// </value>
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
        /// <value>
        /// The he3 start wait time minutes.
        /// </value>
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
        /// The reset all values.
        /// </summary>
        private void ResetAllValues()
        {
            // Keep switches and compressor on if cold, turn off otherwise.
            if (this.cooler.Plate4KT.Value < this.HeatSwitchSafeValue
                && this.cooler.He3Switch.Voltage > this.HeatSwitchOnTemperature
                && this.cooler.He4Switch.Voltage > this.HeatSwitchOnTemperature)
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
            if ((this.cooler.Plate4KT.Value > 100.0 || this.cooler.He3PumpT.Value > 150.0)
                && this.cooler.He3Pump.Voltage > 0.1)
            {
                this.SetHeaterVoltage(this.cooler.He3Pump, 0.0);
            }

            if ((this.cooler.Plate4KT.Value > 100.0 || this.cooler.He4PumpT.Value > 150.0)
                && this.cooler.He4Pump.Voltage > 0.1)
            {
                this.SetHeaterVoltage(this.cooler.He4Pump, 0.0);
            }
        }

        /// <summary>
        /// Set a heater to temperature control with temperature and power settings.
        /// </summary>
        /// <param name="heater">
        /// The heater.
        /// </param>
        /// <param name="temperature">
        /// The temperature.
        /// </param>
        /// <param name="maxpower">
        /// The maximum power.
        /// </param>
        private void SetHeaterTemperature(He7Cooler.He7Cooler.Heater heater, double temperature, double maxpower)
        {
            heater.TemperatureSetpoint = temperature;
            try
            {
                heater.PowerLimit = maxpower;
                heater.TemperatureControlEnabled = true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                DebugLogger.Error("heater", e.Message, true);
                DebugLogger.Error("Controller", "Tried to set too high power setting to heater!, not heating!", true);
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

        /// <summary>
        /// Start the thread running the state machine.
        /// </summary>
        private void StartStateMachine()
        {
            this.controlTimer = new Timer(timerState => this.StateMachine(), null, 0, this.timerPeriod);
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