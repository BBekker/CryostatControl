using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer
{
    using CryostatControlServer.Logging;
    using CryostatControlServer.Properties;

    public partial class Controller
    {

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
                    if (this.cooler != null && this.cooler.IsConnected() && this.lakeshore != null && this.compressor != null)
                    {
                        this.State = Controlstate.Standby;
                    }

                    break;

                case Controlstate.Standby:
                    break;

                case Controlstate.Manual:
                    break;

                case Controlstate.CooldownStart:
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
                    this.resetAllValues();
                    this.State = Controlstate.Standby;
                    break;
            }
        }
    }
}
