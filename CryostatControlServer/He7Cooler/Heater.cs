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
    using System.Diagnostics.CodeAnalysis;

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
            /// The temperature feedback sensor
            /// </summary>
            private Sensor temperatureFeedback;

            /// <summary>
            /// The proportional gain.
            /// </summary>
            private double kP = 0.18;

            /// <summary>
            /// The integral gain.
            /// </summary>
            private double ki = 0.004;

            /// <summary>
            /// The derivative gain.
            /// </summary>
            private double kd = 0.5;

            /// <summary>
            /// The filtered error.
            /// </summary>
            private double filteredError = 0.0;

            /// <summary>
            /// The filter factor.
            /// </summary>
            private double filterFactor = 0.2;

            /// <summary>
            /// The max value of the integrator.
            /// </summary>
            private double integratorMax = 20;

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


                device.AddHeater(this);
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="Heater"/> class.
            /// </summary>
            ~Heater()
            {
                this.device.RemoveChannel(this.inchannel);
            }

            private double temperatureSetpoint;
            /// <summary>
            /// Gets or sets the temperature setpoint in Kelvin.
            /// </summary>
            public double TemperatureSetpoint {
                get
                {
                    return this.temperatureSetpoint;
                }
                set
                {
                    this.temperatureSetpoint = value;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether temperature control enabled.
            /// </summary>
            public bool TemperatureControlEnabled { get; set; } = false;

            private double powerLimit;

            /// <summary>
            /// Gets or sets the power limit in Watt.
            /// </summary>
            public double PowerLimit
            {
                get
                {
                    return this.powerLimit;
                }

                set
                {
                    if (this.SafeRangeHigh < this.calibration.ConvertValue(this.PowerToVoltage(value)))
                    {
                        throw new ArgumentOutOfRangeException($"maxPower {value} -> voltage {this.calibration.ConvertValue(this.PowerToVoltage(value))} exeeds the safety limit {this.SafeRangeHigh} of this heater.");
                    }
                    this.powerLimit = value;
                }
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
                    if (!this.TemperatureControlEnabled)
                    {
                        this.SetOutput(this.calibration.ConvertValue(value));
                    }
                }
            }

            /// <summary>
            /// Notify the heater it has received new measurements.
            /// </summary>
            public void Notify()
            {
                if (this.TemperatureControlEnabled)
                {
                    this.ControlTemperature(this.TemperatureSetpoint, this.PowerLimit);
                }
            }

            private double LowPassFilter(double error)
            {
                this.filteredError = ((1.0 - this.filterFactor) * this.filteredError) + (this.filterFactor * error);
                return this.filteredError;
            }

            /// <summary>
            /// The control temperature loop function.
            /// </summary>
            /// <param name="TSet">
            /// The t set.
            /// </param>
            /// <param name="maxPower">
            /// The maxPower.
            /// </param>
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
            public void ControlTemperature(double TSet, double maxPower)
            {
                double error = TSet - this.temperatureFeedback.Value; // Positive if too cold
                var lpfError = this.LowPassFilter(error);

                var P = error * this.kP;
                var I = this.integrator * this.ki;
                var D = (lpfError - this.previousError) / (DateTime.Now - this.previousLoopTime).TotalSeconds * this.kd;

                double output = P + I + D;

                Console.WriteLine($"out:{output}, P: {P}, I: {I}, D: {D}");

                try
                {
                    if (output > maxPower)
                    {
                        this.SetOutput(this.calibration.ConvertValue(this.PowerToVoltage(maxPower)));
                    }
                    else if (output < 0)
                    {
                        this.SetOutput(0);
                        this.integrator = Math.Min(Math.Max(error + this.integrator, 0),this.integratorMax);
                    }
                    else
                    {
                        this.SetOutput(this.calibration.ConvertValue(this.PowerToVoltage(output)));
                        this.integrator = Math.Max(error + this.integrator, 0);
                    }
                }
                catch (Exception e)
                {
                    DebugLogger.Error("Heater",e.ToString(), false);
                }

                this.previousLoopTime = DateTime.Now;
                this.previousError = lpfError;
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