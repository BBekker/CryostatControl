using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CryostatControlClient.Models
{
    public class CompressorModel : AbstractModel
    {
        private int operatingState;
        private int compressorRunning;
        private int warningState;
        private int alarmState;
        private int coolantInTemp;
        private int coolantOutTemp;
        private int oilTemp;
        private int heliumTemp;
        private int lowPressure;
        private int lowPressureAverage;
        private int highPressure;
        private int highPressureAverage;
        private int deltaPressureAverage;
        private int motorCurrent;
        private int hoursOfOperation;
        private int pressureScale;
        private int tempScale;
        private int panelSerialNumber;
        private int modelMajorMinorNumbers;
        private Boolean powerOn;

        public int OperatingState { get => operatingState; set { operatingState = value; OnPropertyChanged("OperatingState"); } }
        public int CompressorRunning { get => compressorRunning; set { compressorRunning = value; OnPropertyChanged("CompressorRunning"); }}
        public int WarningState { get => warningState; set { warningState = value; OnPropertyChanged("WarningState"); }}
        public int AlarmState { get => alarmState; set { alarmState = value; OnPropertyChanged("AlarmState"); }}
        public int CoolantInTemp { get => coolantInTemp; set { coolantInTemp = value; OnPropertyChanged("CoolantInTemp"); }}
        public int CoolantOutTemp { get => coolantOutTemp; set { coolantOutTemp = value; OnPropertyChanged("CoolantOutTemp"); }}
        public int OilTemp { get => oilTemp; set { oilTemp = value; OnPropertyChanged("OilTemp"); } }
        public int HeliumTemp { get => heliumTemp; set { heliumTemp = value; OnPropertyChanged("HeliumTemp"); }}
        public int LowPressure { get => lowPressure; set { lowPressure = value; OnPropertyChanged("LowPressure"); }}
        public int LowPressureAverage { get => lowPressureAverage; set { lowPressureAverage = value; OnPropertyChanged("LowPressureAverage"); } }
        public int HighPressure { get => highPressure; set { highPressure = value; OnPropertyChanged("HighPressure"); } }
        public int HighPressureAverage { get => highPressureAverage; set { highPressureAverage = value; OnPropertyChanged("HighPressureAverage"); }}
        public int DeltaPressureAverage { get => deltaPressureAverage; set { deltaPressureAverage = value; OnPropertyChanged("DeltaPressureAverage"); } }
        public int MotorCurrent { get => motorCurrent; set { motorCurrent = value; OnPropertyChanged("MotorCurrent"); }}
        public int HoursOfOperation { get => hoursOfOperation; set { hoursOfOperation = value; OnPropertyChanged("HoursOfOperation"); }}
        public int PressureScale { get => pressureScale; set { pressureScale = value; OnPropertyChanged("PressureScale"); }}
        public int TempScale { get => tempScale; set { tempScale = value; OnPropertyChanged("TempScale"); }}
        public int PanelSerialNumber { get => panelSerialNumber; set { panelSerialNumber = value; OnPropertyChanged("PanelSerialNumber"); }}
        public int ModelMajorMinorNumbers { get => modelMajorMinorNumbers; set { modelMajorMinorNumbers = value; OnPropertyChanged("ModelMajorMinorNumbers"); }}
        public bool PowerOn { get => powerOn; set { powerOn = value; OnPropertyChanged("PowerOn"); }}

        
    }


}
