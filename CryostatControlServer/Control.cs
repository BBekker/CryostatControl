namespace CryostatControlServer
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using He7Cooler;
    using LakeShore;
    using Compressor;

    class Control
    {
        private He7Cooler.He7Cooler cooler;

        private LakeShore.LakeShore lakeshore;

        private Compressor.Compressor compressor;

        

        enum Controlstate
        {
            Setup,
            Standby,
            Manual,
            CooldownStart,
            CooldownWaitForPressure,
            CooldownStartCompressor,
            CooldownWait70K,
            CooldownWait4K,
            CooldownCondenseHe4,
            CooldownTurnOffHe4,
            CooldownControlHe4Switch,
            CooldownCondenseHe3,
            CooldownDisableHe3PumpHeater,
            CooldownControlHe3,
            CooldownFinished,


        }

        private Controlstate state = Controlstate.Setup;

        private Controlstate State
        {
            set
            {
                Console.WriteLine("[Control] Switched from state {0} to {1}", this.state, value);
                this.state = value;
                
            }
            get
            {
                return this.state;
            }
        }

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
        public Control(He7Cooler.He7Cooler cooler, LakeShore.LakeShore ls, Compressor.Compressor compressor)
        {
            this.cooler = cooler;
            this.lakeshore = ls;
            this.compressor = compressor;

            He3PumpT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3PumpT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            He4PumpT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4PumpT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            He4SwitchT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4SwitchT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            He3SwitchT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3SwitchT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            Plate4KT = new He7Cooler.He7Cooler.Sensor(Channels.Sens4KplateT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            Plate2KT = new He7Cooler.He7Cooler.Sensor(Channels.Sens2KplateT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.DiodeCalibration);

            He4HeadT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4HeadT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.He4Calibration);

            He3HeadT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3HeadT, cooler, He7Cooler.He7Cooler.Sensor.Calibration.He3Calibration);

            He3Pump = new He7Cooler.He7Cooler.Heater(Channels.PumpHe3, Channels.SensHe3Pump, cooler);
            He4Pump = new He7Cooler.He7Cooler.Heater(Channels.PumpHe4, Channels.SensHe4Pump, cooler);
            He4Switch = new He7Cooler.He7Cooler.Heater(Channels.SwitchHe4, Channels.SensHe4Switch, cooler);
            He3Switch = new He7Cooler.He7Cooler.Heater(Channels.SwitchHe3, Channels.SensHe3Switch, cooler);


        }

        private He7Cooler.He7Cooler.Sensor He3PumpT;

        He7Cooler.He7Cooler.Sensor He4PumpT;

        He7Cooler.He7Cooler.Sensor He4SwitchT;

        He7Cooler.He7Cooler.Sensor He3SwitchT;

        He7Cooler.He7Cooler.Sensor Plate4KT;

        He7Cooler.He7Cooler.Sensor Plate2KT;

        He7Cooler.He7Cooler.Sensor He4HeadT;

        He7Cooler.He7Cooler.Sensor He3HeadT;

        He7Cooler.He7Cooler.Heater He3Pump;
        He7Cooler.He7Cooler.Heater He4Pump;
        He7Cooler.He7Cooler.Heater He4Switch;
        He7Cooler.He7Cooler.Heater He3Switch;

        private double HeaterTemperatureSetpoint = 35.0;

        private double He4HeaterVoltage = 10.0;

        private double He3HeaterVoltage = 6.0;

        private double He3SwitchVoltage = 3.0;

        private double He4SwitchVoltage = 4.0;

        private double He7StartTemperature = 70.0;

        private double HeatSwitchSafeValue = 9.0;

        private double HeatSwitchOnTemperature = 15.0;

        /// <summary>
        /// Checks if the heat switches are allowed to be turned on.
        /// If the cooler temperature is too high, the heaters are turned off.
        /// </summary>
        private void SafetyCheckHeatSwitch()
        {
            if (this.Plate4KT.Value > HeatSwitchSafeValue && this.He4Switch.Voltage > 0.2)
            {
                this.He4Switch.Voltage = 0.0;
            }

            if (this.Plate4KT.Value > HeatSwitchSafeValue && this.He3Switch.Voltage > 0.2)
            {
                this.He3Switch.Voltage = 0.0;
            }
        }

        /// <summary>
        /// Safety check of the pump heaters.
        /// If the cooler is to warm, the heaters are turned off
        /// </summary>
        private void SafetyCheckPumps()
        {
            if (this.Plate4KT.Value > 70.0 && this.He3Pump.Voltage > 0.2)
            {
                this.He3Pump.Voltage = 0.0;
            }

            if (this.Plate4KT.Value > 70.0 && this.He4Pump.Voltage > 0.2)
            {
                this.He4Pump.Voltage = 0.0;
            }
        }

        /// <summary>
        /// The state machine that controls the heater.
        /// Controls the 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        void StateMachine()
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
                    this.State = Controlstate.CooldownWaitForPressure;
                    break;

                case Controlstate.CooldownWaitForPressure:
                    //TODO: wait for pressure when sensor is connected
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
                    if (this.He3PumpT.Value < this.He7StartTemperature || this.He4PumpT.Value < this.He7StartTemperature)
                    {
                        this.State = Controlstate.CooldownWait4K;
                    }
                    break;

                case Controlstate.CooldownWait4K:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, this.HeaterTemperatureSetpoint, this.He3HeaterVoltage);
                    this.ControlHeater(this.He4Pump, this.He4PumpT, this.HeaterTemperatureSetpoint, this.He4HeaterVoltage);
                    if (this.He3HeadT.Value < 4.0 && this.He4HeadT.Value < 4.0)
                    {
                        this.State = Controlstate.CooldownCondenseHe4;
                    }

                    break;
                case Controlstate.CooldownCondenseHe4:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, this.HeaterTemperatureSetpoint, this.He3HeaterVoltage);
                    this.ControlHeater(this.He4Pump, this.He4PumpT, this.HeaterTemperatureSetpoint, this.He4HeaterVoltage);
                    if (this.He4HeadT.Value < 4.0)
                    {
                        this.State = Controlstate.CooldownCondenseHe4;
                    }
                    break;
                case Controlstate.CooldownTurnOffHe4:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, this.HeaterTemperatureSetpoint, this.He3HeaterVoltage);
                    this.He4Pump.Voltage = 0.0;
                    break;

                case Controlstate.CooldownControlHe4Switch:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, this.HeaterTemperatureSetpoint, this.He3HeaterVoltage);

                    if (this.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.He4Switch.Voltage = this.He4SwitchVoltage;
                    }

                    if (this.He4SwitchT.Value > this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownCondenseHe3;
                    }
                    break;

                case Controlstate.CooldownCondenseHe3:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, this.HeaterTemperatureSetpoint, this.He3HeaterVoltage);
                    if (this.He3HeadT.Value < 2.0)
                    {
                        this.State = Controlstate.CooldownDisableHe3PumpHeater;
                    }
                    break;

                case Controlstate.CooldownDisableHe3PumpHeater:
                    this.He3Pump.Voltage = 0.0;
                    this.State = Controlstate.CooldownControlHe3;
                    break;

                case Controlstate.CooldownControlHe3:
                    if (this.Plate4KT.Value < this.HeatSwitchSafeValue)
                    {
                        this.He3Switch.Voltage = this.He3SwitchVoltage;
                    }

                    if (this.He3SwitchT.Value > this.HeatSwitchOnTemperature)
                    {
                        this.State = Controlstate.CooldownFinished;
                    }
                    break;
                case Controlstate.CooldownFinished:
                    this.State = Controlstate.Standby;
                    break;
                    
            }

        }

        /// <summary>
        /// Control a heater
        /// Uses a simple P controller, might be updated to PI later.
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
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "SI naming, T is uppercase")]
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
    }
}
