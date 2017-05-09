using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Compressor
{
    public enum AnalogRegistersEnum
    {
        OperatingState = 1,
        EnergyState = 2,
        WarningState = 3,
        ErrorState = 5,
        CoolantInTemp = 7,
        CoolantOutTemp = 9,
        OilTemp = 11,
        HeliumTemp = 13,
        LowPressure = 15,
        LowPressureAvg = 17,
        HighPressure = 19,
        HighPressureAvg = 21,
        DeltaPressureAvg = 23,
        MotorCurrent = 25,
        HoursOfOperation = 27,
        PressureScale = 29,
        TempScale = 30,
        PanelSerialNumber = 31,
        Model = 32
    }

    public enum HoldingRegistersEnum
    {
        Control = 1
    }
}