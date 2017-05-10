using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlClient.Models
{
    public class He7Model : AbstractModel
    {
        private int he4PumpTemp;
        private int he4PumpVolt;
        private int he3PumpTemp;
        private int he3PumpVolt;
        private int he4SwitchTemp;
        private int he4SwitchVolt;
        private int he3SwitchTemp;
        private int he3SwitchVolt;
        private int twoKPlateTemp;
        private int fourKPlateTemp;
        private int he4HeadTemp;
        private int he3HeadTemp;

        public int He4PumpTemp { get => he4PumpTemp; set { he4PumpTemp = value; OnPropertyChanged("He4PumpTemp"); } }
        public int He4PumpVolt { get => he4PumpVolt; set { he4PumpVolt = value; OnPropertyChanged("He4PumpVolt"); } }
        public int He3PumpTemp { get => he3PumpTemp; set { he3PumpTemp = value; OnPropertyChanged("He3PumpTemp"); } }
        public int He3PumpVolt { get => he3PumpVolt; set { he3PumpVolt = value; OnPropertyChanged("He3PumpVolt"); } }
        public int He4SwitchTemp { get => he4SwitchTemp; set { he4SwitchTemp = value; OnPropertyChanged("He4SwitchTemp"); } }
        public int He4SwitchVolt { get => he4SwitchVolt; set { he4SwitchVolt = value; OnPropertyChanged("He4SwitchVolt"); } }
        public int He3SwitchTemp { get => he3SwitchTemp; set { he3SwitchTemp = value; OnPropertyChanged("He3SwitchTemp"); } }
        public int He3SwitchVolt { get => he3SwitchVolt; set { he3SwitchVolt = value; OnPropertyChanged("He3SwitchVolt"); } }
        public int TwoKPlateTemp { get => twoKPlateTemp; set { twoKPlateTemp = value; OnPropertyChanged("TwoKPlateTemp"); } }
        public int FourKPlateTemp { get => fourKPlateTemp; set { fourKPlateTemp = value; OnPropertyChanged("FourKPlateTemp"); } }
        public int He4HeadTemp { get => he4HeadTemp; set { he4HeadTemp = value; OnPropertyChanged("He4HeadTemp"); } }
        public int He3HeadTemp { get => he3HeadTemp; set { he3HeadTemp = value; OnPropertyChanged("He3HeadTemp"); } }
    }
}
