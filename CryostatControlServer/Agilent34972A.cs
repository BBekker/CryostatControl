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
        private const int SENS_HE4PUMP_T = 106;

        private const int SENS_HE3PUMP_T = 101;
        private const int SENS_HE4SWITCH_T = 102;
        private const int SENS_HE3SWITCH_T = 103;
        private const int SENS_4KPLATE_T = 105;
        private const int SENS_2KPLATE_T = 104;
        private const int SENS_HE4HEAD_T = 108;
        private const int SENS_HE3HEAD_T = 107;

        // Heater sensors
        private const int SENS_HE3PUMP = 110;

        private const int SENS_HE3SWITCH = 112;
        private const int SENS_HE4PUMP = 109;
        private const int SENS_HE4SWITCH = 111;

        // Digital Channel
        private const int CTRL_DIG_OUT = 201;

        // Heaters
        private const int PUMP_HE3 = 204;

        private const int SWITCH_HE3 = 305;
        private const int PUMP_HE4 = 205;
        private const int SWITCH_HE4 = 304;

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

        private double[] GetVoltages(int[] sens_IDs, int n_sensors)
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
            connection.WriteString(string.Format("SOUR:VOLT {0,3f}, (@{1})\n", setVoltage, heat_ID));
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