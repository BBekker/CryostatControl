using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Compressor
{
    public enum ErrorEnum
    {
        NoErrors = 0,
        CoolantInHigh = -1,
        CoolantInLow = -2,
        CoolantOutHigh = -4,
        CoolantOutLow = -8,
        OilHigh = -16,
        OilLow = -32,
        HeliumHigh = -64,
        HeliumLow = -128,
        LowPressureHigh = -256,
        LowPressureLow = -512,
        HighPressureHigh = -1024,
        HighPressureLow = -2048,
        DeltaPressureHigh = -4096,
        DeltaPressureLow = -8192,
        MotorCurrentLow = -16384,
        ThreePhaseError = -32768,
        PowerSupplyError = -65536,
        StaticPressureHigh = -131072,
        StaticPressureLow = -262144
    }
}