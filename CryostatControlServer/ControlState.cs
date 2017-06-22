// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlState.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    /// <summary>
    /// Enum of possible states for the control state machine
    /// </summary>
    public enum Controlstate
    {
        /// <summary>
        /// Waiting for everything to be connected and ready
        /// </summary>
        Setup,

        /// <summary>
        /// Everything ready, waiting for a command
        /// </summary>
        Standby,

        /// <summary>
        /// Manual control mode
        /// </summary>
        Manual,

        /// <summary>
        /// Entry point for the cool down routine.
        /// </summary>
        CooldownStart,

        /// <summary>
        /// Wait for the pressure inside the cryostat to drop below the critical point.
        /// </summary>
        CooldownWaitForPressure,

        /// <summary>
        /// Start the pulse tube compressor.
        /// </summary>
        CooldownStartCompressor,

        /// <summary>
        /// Wait for the pulse tube to cool the cryostat to 70K.
        /// </summary>
        CooldownWait70K,

        /// <summary>
        /// Wait for the heat switches to turn OFF 
        /// </summary>
        CooldownWaitSwitches,

        /// <summary>
        /// Activate pump heaters and wait to cool to 4K.
        /// </summary>
        CooldownWait4K,

        /// <summary>
        /// Wait for all He4 to be condensed
        /// </summary>
        CooldownCondenseHe4,

        /// <summary>
        /// Turn off the He4 heater
        /// </summary>
        CooldownTurnOffHe4,

        /// <summary>
        /// Turn on the He4 switch.
        /// </summary>
        CooldownControlHe4Switch,

        /// <summary>
        /// He4 cooling down the He3.
        /// Wait for He3 to be condensed.
        /// </summary>
        CooldownCondenseHe3,

        /// <summary>
        /// Wait for He3 heater to reach the set point. Should always immediately skip.
        /// </summary>
        CooldownWaitHe3Heater,

        /// <summary>
        /// disable he3 pump heater
        /// </summary>
        CooldownDisableHe3PumpHeater,

        /// <summary>
        /// Turn on the He3 heat switch.
        /// </summary>
        CooldownControlHe3,

        /// <summary>
        /// "Fridge is cooling nicely."
        ///  - Chase Research He7 cooler manual
        /// </summary>
        CooldownFinished,

        /// <summary>
        /// Recycle sequence entry point
        /// </summary>
        RecycleStart,

        /// <summary>
        /// Heat pumps
        /// Rest of recycle follows cool down from "CoolDownTurnOffHe4"
        /// </summary>
        RecycleHeatPumps,

        /// <summary>
        /// Warm up entry point
        /// </summary>
        WarmupStart,

        /// <summary>
        /// Warming up stuff
        /// </summary>
        WarmupHeating,

        /// <summary>
        /// The warm up is finished
        /// </summary>
        WarmupFinished,

        /// <summary>
        /// Cancel the current action and go back to standby.
        /// </summary>
        CancelAll,
    }
}