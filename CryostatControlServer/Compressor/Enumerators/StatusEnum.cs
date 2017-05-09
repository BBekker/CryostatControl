using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Compressor
{
    public enum StatusEnum
    {
        Idling = 0,
        Starting = 2,
        Running = 3,
        Stopping = 5,
        ErrorLockout = 6,
        Error = 7,
        HeliumCoolDown = 8,
        ErrorPowerRelated = 9,
        ErrorRecovery = 16
    }
}