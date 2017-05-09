//==============================================================================
//
// Title:       Agilent34972A.cs
// Purpose:     A short description of the interface.
//
// Created on:  02/03/2011 at 16:28:02 by Joep Lohmann.
// Modified:    08/05/2017 by Bernard Bekker
// Copyright:   SRON. All Rights Reserved.
//
//==============================================================================

using System;
using CryostatControlServer.Streams;

namespace CryostatControlServer
{
    internal class Agilent34972A
    {
        private readonly ManagedStream _connection = new ManagedStream();

        #region Constant values

        // Temperature sensors
        public const int SENS_HE4PUMP_T = 106;

        public const int SENS_HE3PUMP_T = 101;
        public const int SENS_HE4SWITCH_T = 102;
        public const int SENS_HE3SWITCH_T = 103;
        public const int SENS_4KPLATE_T = 105;
        public const int SENS_2KPLATE_T = 104;
        public const int SENS_HE4HEAD_T = 108;
        public const int SENS_HE3HEAD_T = 107;

        // Heater sensors
        public const int SENS_HE3PUMP = 110;

        public const int SENS_HE3SWITCH = 112;
        public const int SENS_HE4PUMP = 109;
        public const int SENS_HE4SWITCH = 111;

        // Digital Channel
        public const int CTRL_DIG_OUT = 201;

        // Heaters
        public const int PUMP_HE3 = 204;

        public const int SWITCH_HE3 = 305;
        public const int PUMP_HE4 = 205;
        public const int SWITCH_HE4 = 304;

        private static readonly int[] Dig_Switch_Channels = { SENS_HE3HEAD_T, SENS_HE4HEAD_T, PUMP_HE3, PUMP_HE4 };

        private const int TCP_PORT = 5025;
        private const int TCP_TIMEOUT = 5000;

        #endregion Constant values

        public void Init(string ipAddress)
        {
            _connection.ConnectTCP(ipAddress, TCP_PORT);

            //-------- INITIALIZE AGILENT CONTROLLER

            _connection.WriteString("FORM:READ:CHAN ON\n");
            CheckState();
        }

        /// <summary>
        /// Checks if the device is in a consistent state and all commands are performed. used for synchronisation.
        /// </summary>
        /// <exception cref="System.Exception">invalid agilent state</exception>
        private void CheckState()
        {
            _connection.WriteString("*OPC?\n");

            var res = int.Parse(_connection.ReadString());
            if (res < 1)
                throw new Exception("invalid agilent state");
        }

        /// <summary>
        ///     Gets voltages from the device
        /// </summary>
        /// <param name="sensIDs">Sensor ID's to measure.</param>
        /// <returns>array of voltages in the same ordering as sensIDs</returns>
        public double[] GetVoltages(int[] sensIDs)
        {
            var n_sensors = sensIDs.Length;
            var n_chan = new int[n_sensors];
            var rVolt = new double[n_sensors];
            var Values = new double[2 * n_sensors];
            var readVolt = new double[n_sensors];

            //construct a command to read all specified voltages
            var cmd_str = "ROUT:SCAN (@";

            for (var k = 0; k < n_sensors - 1; k++)
                cmd_str += $"{sensIDs[k]},";

            cmd_str += $"{sensIDs[n_sensors - 1]})\n";
            cmd_str += "READ?\n";
            _connection.WriteString(cmd_str);

            //read response
            var res = _connection.ReadString();

            //Extract data
            Values = GetDataFromString(res);

            //split into voltages and channels
            for (var k = 0; k < n_sensors; k++)
            {
                rVolt[k] = Values[2 * k];
                n_chan[k] = (int) Values[2 * k + 1];
            }

            //Order temperature in order of sens_IDs
            for (var k = 0; k < n_sensors; k++)
            for (var i = 0; i < n_sensors; i++)
                if (sensIDs[i] == n_chan[k])
                    readVolt[i] = rVolt[k];

            // Write ABOR command to return
            _connection.WriteString("ABOR\n");
            CheckState();

            return readVolt;
        }

        /// <summary>
        ///     Sets the heater voltage.
        /// </summary>
        /// <param name="heatId">The heater identifier.</param>
        /// <param name="setVoltage">The set voltage.</param>
        public void SetHeaterVoltage(int heatId, double setVoltage)
        {
            _connection.WriteString($"SOUR:VOLT {setVoltage:F3}, (@{heatId})\n");
        }


        public void SetDigitalOutput(int switch_ID, bool b_set)
        {
            // Get current digital output values
            _connection.WriteString($"SOUR:DIG:DATA:BYTE? (@{CTRL_DIG_OUT})\n");
            var res_string = _connection.ReadString();
            var get_byte = int.Parse(res_string); //TODO: Catch error

            //find corresponding bits
            var bit_val = 1;
            for (var k = 0; k < Dig_Switch_Channels.Length; k++)
                if (switch_ID == Dig_Switch_Channels[k])
                {
                    bit_val = 1 << k;
                    if (k < 2)
                        b_set = !b_set;

                    break;
                }

            //set or clear the bit in the old values
            var set_byte = 0;
            if (b_set) // Set bit : 1
                set_byte = get_byte | bit_val;
            else // Set bit : 0
                set_byte = get_byte - (get_byte & bit_val);

            //write new configuration
            _connection.WriteString($"SOUR:DIG:DATA:BYTE {set_byte}, (@{CTRL_DIG_OUT})\n");
        }

        private static double[] GetDataFromString(string dataString)
        {
            var split = dataString.Split(',');
            var results = new double[split.Length];
            for (var i = 0; i < split.Length; i++)
                results[i] = double.Parse(split[i]);
            return results;
        }

        
    }
}