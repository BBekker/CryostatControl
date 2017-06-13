// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Heater.cs" company="SRON">
//   All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Representation a heater element on the H7 cooler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;

    using CryostatControlServer.Logging;

    /// <summary>
    /// The he 7 cooler.
    /// </summary>
    public partial class He7Cooler
    {
        /// <summary>
        /// Representation a heater element on the H7 cooler.
        /// </summary>
        public class Heater
        {
            /// <summary>
            /// The default safe range high.
            /// </summary>
            private const double DefaultSafeRangeHigh = 10.0;

            /// <summary>
            /// The default safe range low.
            /// </summary>
            private const double DefaultSafeRangeLow = 0.0;

            /// <summary>
            /// The resistance of the heater resistor.
            /// </summary>
            private readonly double resistance = 1;

            /// <summary>
            /// The amplifier calibration. converts from post amplification to pre-amplification.
            /// </summary>
            private Calibration calibration;

            /// <summary>
            /// The H7 cooler device.
            /// </summary>
            private He7Cooler device;

            /// <summary>
            /// The channel where current voltage is read.
            /// </summary>
            private Channels inchannel;

            /// <summary>
            /// The PID controller integrator.
            /// </summary>
            private double integrator = 0;

            /// <summary>
            /// The channel where to output the voltage set point.
            /// </summary>
            private Channels outchannel;

            /// <summary>
            /// The previous error used for the PID controller.
            /// </summary>
            private double previousError = 0.0;

            /// <summary>
            /// The previous loop time.
            /// </summary>
            private DateTime previousLoopTime = DateTime.MinValue;

            /// <summary>
            /// The temperature control enabled.
            /// </summary>
            private bool temperatureControlEnabled = false;

            /// <summary>
            /// The temperature feedback sensor
            /// </summary>
            private Sensor temperatureFeedback;

            /// <summary>
            /// The proportional gain.
            /// </summary>
            private double kP = 0.5;

            /// <summary>
            /// The integral gain.
            /// </summary>
            private double ki = 0.1;

            /// <summary>
            /// The derivative gain.
            /// </summary>
            private double kd = 0.1;

            /// <summary>
            /// Initializes a new instance of the <see cref="Heater"/> class.
            /// </summary>
            /// <param name="outputChannel">
            /// The voltage output channel.
            /// </param>
            /// <param name="inputChannel">
            /// The voltage input channel.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device the heater is connected to.
            /// </param>
            public Heater(Channels outputChannel, Channels inputChannel, He7Cooler device)
            {
                this.inchannel = inputChannel;
                this.outchannel = outputChannel;
                this.device = device;
                device.AddChannel(inputChannel);
                this.SafeRangeHigh = DefaultSafeRangeHigh;
                this.SafeRangeLow = DefaultSafeRangeLow;
                this.calibration = new Calibration();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Heater"/> class.
            /// </summary>
            /// <param name="outputChannel">
            /// The voltage output channel.
            /// </param>
            /// <param name="inputChannel">
            /// The voltage input channel.
            /// </param>
            /// <param name="temperatureFeedbackSensor">
            /// Temperature sensor used for feedback
            /// </param>
            /// <param name="resistance">
            /// The resistance.
            /// </param>
            /// <param name="outputCalibration">
            /// The output Calibration.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device the heater is connected to.
            /// </param>
            public Heater(
                Channels outputChannel,
                Channels inputChannel,
                Sensor temperatureFeedbackSensor,
                double resistance,
                Calibration outputCalibration,
                He7Cooler device)
            {
                this.inchannel = inputChannel;
                this.outchannel = outputChannel;
                this.device = device;
                device.AddChannel(inputChannel);
                this.SafeRangeHigh = DefaultSafeRangeHigh;
                this.SafeRangeLow = DefaultSafeRangeLow;

                this.temperatureFeedback = temperatureFeedbackSensor;
                this.resistance = resistance;
                this.calibration = outputCalibration;
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="Heater"/> class.
            /// </summary>
            ~Heater()
            {
                this.device.RemoveChannel(this.inchannel);
            }

            /// <summary>
            /// Gets or sets the current.
            /// </summary>
            public double Current
            {
                get
                {
                    return this.Voltage / this.resistance;
                }

                set
                {
                    this.Voltage = value * this.resistance;
                }
            }

            /// <summary>
            /// Gets or sets the power.
            /// </summary>
            public double Power
            {
                get
                {
                    return this.VoltageToPower(this.Voltage);
                }

                set
                {
                    this.Voltage = this.PowerToVoltage(value);
                }
            }

            /// <summary>
            /// Gets or sets the voltage safe range high side.
            /// </summary>
            public double SafeRangeHigh { get; set; }

            /// <summary>
            /// Gets or sets the voltage safe range low side.
            /// </summary>
            public double SafeRangeLow { get; set; }

            /// <summary>
            /// Gets or sets the voltage of the heater.
            /// </summary>
            public double Voltage
            {
                get
                {
                    return this.device.values[this.inchannel];
                }

                set
                {
                    this.SetOutput(this.calibration.ConvertValue(value));
                }
            }

            /// <summary>
            /// The control temperature loop function.
            /// </summary>
            /// <param name="TSet">
            /// The t set.
            /// </param>
            /// <param name="maxpower">
            /// The maxpower.
            /// </param>
            public void ControlTemperature(double TSet, double maxpower)
            {
                if (this.SafeRangeHigh < this.calibration.ConvertValue(this.PowerToVoltage(maxpower)))
                {
                    throw new ArgumentOutOfRangeException("maxpower exeeds the safety limits of this heater");
                }

                double error = TSet - this.temperatureFeedback.Value; // Positive if too cold

                double output = 0;
                output += error * this.kP;
                output += this.integrator * this.ki;
                output += (error - this.previousError) / (DateTime.Now - this.previousLoopTime).TotalSeconds * this.kd;

                if (output > maxpower)
                {
                    this.Power = maxpower;
                }
                else if (output < 0)
                {
                    this.Power = 0;
                    this.integrator += error;
                }
                else
                {
                    this.Power = output;
                    this.integrator += error;
                }

                this.previousLoopTime = DateTime.Now;
                this.previousError = error;
            }

            /// <summary>
            /// Convert power to voltage using the heater resistance.
            /// </summary>
            /// <param name="power">
            /// The power.
            /// </param>
            /// <returns>
            /// The <see cref="double"/>.
            /// </returns>
            private double PowerToVoltage(double power)
            {
                return Math.Sqrt(power * this.resistance);
            }

            /// <summary>
            /// The set output.
            /// </summary>
            /// <param name="volts">
            /// The volts.
            /// </param>
            private void SetOutput(double volts)
            {
                if (volts > this.SafeRangeHigh || volts < this.SafeRangeLow)
                {
                    DebugLogger.Error(
                        this.GetType().Name,
                        $"Voltage setpoint of {volts} is out of the safe range from {this.SafeRangeLow} to {this.SafeRangeHigh}");
                    throw new ArgumentOutOfRangeException(
                        $"Voltage setpoint of {volts} is out of the safe range from {this.SafeRangeLow} to {this.SafeRangeHigh}");
                }

                this.device.SetVoltage(this.outchannel, volts);
            }

            /// <summary>
            /// Convert voltage to power using the heater resistance.
            /// </summary>
            /// <param name="voltage">
            /// The voltage.
            /// </param>
            /// <returns>
            /// The <see cref="double"/>.
            /// </returns>
            private double VoltageToPower(double voltage)
            {
                return voltage * voltage / this.resistance;
            }
        }
    }
}