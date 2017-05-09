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

using CryostatControlServer.Streams;

namespace CryostatControlServer
{
    internal class Agilent34972A
    {
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

        static int[] Dig_Switch_Channels = new int[]{ SENS_HE3HEAD_T, SENS_HE4HEAD_T, PUMP_HE3, PUMP_HE4 };

        private const int TCP_PORT = 5025;
        private const int TCP_TIMEOUT = 5000;

        #endregion Constant values

        private ManagedStream connection = new ManagedStream();

        public void init(string ip_address)
        {
            connection.ConnectTCP(ip_address, TCP_PORT);

            //-------- INITIALIZE AGILENT CONTROLLER

            connection.WriteString("FORM:READ:CHAN ON\n");
            CheckState();

            LoadCalibration();
        }

        private void CheckState()
        {
            connection.WriteString("*OPC?\n");

            //H7Logger reads something back?
            int res = int.Parse(connection.ReadString());
            if (res < 1)
                throw new System.Exception("invalid agilent state");
        }

        public double[] GetVoltages(int[] sens_IDs, int n_sensors)
        {
            int[] n_chan = new int[n_sensors];
            double[] rVolt = new double[n_sensors];
            double[] Values = new double[2 * n_sensors];
            double[] readVolt = new double[n_sensors];

            string cmd_str = "ROUT:SCAN (@";

            for (int k = 0; k < (n_sensors - 1); k++)
            {
                cmd_str += $"{sens_IDs[k]},";
            }

            cmd_str += $"{sens_IDs[n_sensors - 1]})\n";
            cmd_str += "READ?\n";
            connection.WriteString(cmd_str);

            string res = connection.ReadString();
            Values = GetDataFromString(res);

            for (int k = 0; k < n_sensors; k++)
            {
                rVolt[k] = (Values[(2 * k)]);
                n_chan[k] = (int)(Values[(2 * k) + 1]);
            }

            //Order temperature in order of sens_IDs
            for (int k = 0; k < n_sensors; k++)
            {
                for (int i = 0; i < n_sensors; i++)
                {
                    if (sens_IDs[i] == n_chan[k])
                    {
                        readVolt[i] = rVolt[k];
                    }
                }
            }

            // Write ABOR command to return
            connection.WriteString("ABOR\n");
            CheckState();

            return readVolt;
        }

        public void LoadCalibration()
        {
        }

        public void SetHeaterVoltage(int heat_ID, double setVoltage)
        {
            connection.WriteString(string.Format("SOUR:VOLT {0:F3}, (@{1})\n", setVoltage, heat_ID));
        }



        public void SetDigitalOutput(int switch_ID, bool b_set)
        {

            // Get Switch Information
            connection.WriteString($"SOUR:DIG:DATA:BYTE? (@{CTRL_DIG_OUT})\n");
            string res_string = connection.ReadString();
            int get_byte = int.Parse(res_string); //TODO: Catch error
            // 
            int bit_val = 1;
            for (int k = 0; k < Dig_Switch_Channels.Length; k++)
            {
                if (switch_ID == Dig_Switch_Channels[k])
                {
                    bit_val = 1 << k;
                    if (k < 2)
                        b_set = !b_set;

                    break;
                }
            }

            int set_byte = 0;
            if (b_set)  // Set bit : 1
                set_byte = (get_byte | bit_val);
            else            // Set bit : 0
                set_byte = get_byte - (get_byte & bit_val);

            connection.WriteString($"SOUR:DIG:DATA:BYTE {set_byte}, (@{CTRL_DIG_OUT})\n");
        }

        private double[] GetDataFromString(string dataString)
        {
            string[] split = dataString.Split(',');
            double[] results = new double[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                results[i] = double.Parse(split[i]);
            }
            return results;
        }
    }
}