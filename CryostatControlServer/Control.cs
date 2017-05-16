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
            CooldownDisableHeatSwitch,
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

        void StateMachine()
        {

            switch (this.state)
            {
                case Controlstate.Setup:
                    if (this.cooler != null && this.lakeshore != null && this.compressor != null)
                    { 
                        this.state = Controlstate.Standby;
                    }
                    break;

                case Controlstate.Standby:
                    break;

                case Controlstate.Manual:
                    break;

                case Controlstate.CooldownStart:
                    this.state = Controlstate.CooldownWaitForPressure;
                    break;

                case Controlstate.CooldownWaitForPressure:
                    //TODO: wait for pressure when sensor is connected
                    this.state = Controlstate.CooldownStartCompressor;
                    break;

                case Controlstate.CooldownStartCompressor:
                    this.compressor.TurnOn();
                    this.state = Controlstate.CooldownWait70K;
                    break;

                case Controlstate.CooldownWait70K:
                    if (this.He3PumpT.Value < 70.0 || this.He4PumpT.Value < 70.0)
                    {
                        this.state = Controlstate.CooldownDisableHeatSwitch;
                    }
                    break;

                case Controlstate.CooldownDisableHeatSwitch:
                    new He7Cooler.He7Cooler.Heater(Channels.SwitchHe3, Channels.SensHe3Switch, this.cooler).Voltage = 0.0;
                    new He7Cooler.He7Cooler.Heater(Channels.SwitchHe4, Channels.SensHe4Switch, this.cooler).Voltage = 0.0;
                    this.state = Controlstate.CooldownWait4K;
                    break;

                case Controlstate.CooldownWait4K:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, 35, 10);
                    this.ControlHeater(this.He4Pump, this.He4PumpT, 35, 10);
                    if (this.He3HeadT.Value < 4.0 && this.He4HeadT.Value < 4.0)
                    {
                        this.state = Controlstate.CooldownCondenseHe4;
                    }

                    break;
                case Controlstate.CooldownCondenseHe4:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, 35, 10);
                    this.ControlHeater(this.He4Pump, this.He4PumpT, 35, 10);
                    if (this.He4HeadT.Value < 4.0)
                    {
                        this.state = Controlstate.CooldownCondenseHe4;
                    }
                    break;
                case Controlstate.CooldownTurnOffHe4:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, 35, 10);
                    this.He4Pump.Voltage = 0.0;
                    break;

                case Controlstate.CooldownControlHe4Switch:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, 35, 10);

                    //I don't know why we measure the 4k plate... Should never get this high anyway
                    if (this.Plate4KT.Value > 9.0)
                    {
                        this.He4Switch.Voltage = 0.0;
                    }
                    else
                    {
                        this.He4Switch.Voltage = 4.0;
                    }

                    if ((this.He4SwitchT.Value > 15.0) && (this.Plate4KT.Value < 9.0))
                    {
                        // Shouldn't we turn off the switch here? Or at least keep controlling it?
                        this.state = Controlstate.CooldownCondenseHe3;
                    }
                    break;

                case Controlstate.CooldownCondenseHe3:
                    this.ControlHeater(this.He3Pump, this.He3PumpT, 35, 10);
                    if (this.He3HeadT.Value < 2.0)
                    {
                        this.state = Controlstate.CooldownDisableHe3PumpHeater;
                    }
                    break;

                case Controlstate.CooldownDisableHe3PumpHeater:
                    this.He3Pump.Voltage = 0.0;
                    state = Controlstate.CooldownControlHe3;
                    break;

                case Controlstate.CooldownControlHe3:
                    //Also mysterious
                    //I don't know why we measure the 4k plate... Should never get this high anyway
                    if (this.Plate4KT.Value > 9.0)
                    {
                        this.He3Switch.Voltage = 0.0;
                    }
                    else
                    {
                        this.He3Switch.Voltage = 3.0;
                    }

                    if ((this.He3SwitchT.Value > 15.0) && (this.Plate4KT.Value < 9.0))
                    {
                        // Shouldn't we turn off the switch here? Or at least keep controlling it?
                        // also  strange conditions
                        this.state = Controlstate.CooldownFinished;
                    }
                    break;
                case Controlstate.CooldownFinished:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
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
