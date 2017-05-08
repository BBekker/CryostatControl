
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CryostatControlServer.Streams;


namespace CryostatControlServer
{
    class Agilent34972A
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

        #endregion
        

        ManagedStream connection = new ManagedStream();


        public void init(string ip_address)
        {
            connection.ConnectTCP(ip_address, TCP_PORT);
            

            //-------- INITIALIZE AGILENT CONTROLLER

            connection.WriteString("FORM:READ:CHAN ON\n");
            CheckState();

            LoadCalibration();
        }

        void CheckState()
        {
            connection.WriteString("*OPC?\n");

            //H7Logger reads something back?
            int res = int.Parse(connection.ReadString());
            if (res < 1)
                throw new System.Exception("invalid agilent state");
        }



        public void LoadCalibration()
        {
            
        }

        double[] GetDataFromString(string dataString)
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
