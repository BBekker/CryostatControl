using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Compressor
{
    public enum WarningsEnum
    {
        NoWarnings = 0,
        CoolantInRunningHigh = -1,
        CoolantInRunningLow = -2,
        CoolantOutRunningHigh = -4,
        CoolantOutRunningLow = -8,
        OilRunningHigh = -16,
        OilRunningLow = -32,
        HeliumRunningHigh = -64,
        HeliumRunningLow = -128,
        LowPressureRunningHigh = -256,
        LowPressureRunningLow = -512,
        HighPressureRunningHigh = -1024,
        HighPressureRunningLow = -2048,
        DeltaPressureRunningHigh = -4096,
        DeltaPressureRunningLow = -8192,
        StaticPressureRunningHigh = -131072,
        StaticPressureRunningLow = -262144,
        ColdHeadMotorStall = -524288
    }
}