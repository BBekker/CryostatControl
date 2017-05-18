// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7ViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the He7ViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using CryostatControlClient.Models;

    /// <summary>
    /// The he 7 view model.
    /// </summary>
    public class He7ViewModel : AbstractViewModel
    {
        /// <summary>
        /// The he 7 model.
        /// </summary>
        private He7Model he7Model;

        /// <summary>
        /// Initializes a new instance of the <see cref="He7ViewModel"/> class.
        /// </summary>
        public He7ViewModel()
        {
            this.he7Model = new He7Model();
        }

        /// <summary>
        /// Gets or sets the four k plate temperature.
        /// </summary>
        /// <value>
        /// The four k plate temperature.
        /// </value>
        public double FourKPlateTemp
        {
            get
            {
                return this.he7Model.FourKPlateTemp;
            }

            set
            {
                this.he7Model.FourKPlateTemp = value;
                this.RaisePropertyChanged("FourKPlateTemp");
            }
        }

        /// <summary>
        /// Gets or sets the four k plate max 1.
        /// </summary>
        public double FourKPlateMax1
        {
            get
            {
                return this.he7Model.FourKPlateMax1;
            }

            set
            {
                this.he7Model.FourKPlateMax1 = value;
                this.RaisePropertyChanged("FourKPlateMax1");
            }
        }

        /// <summary>
        /// Gets or sets the four k plate max 2.
        /// </summary>
        public double FourKPlateMax2
        {
            get
            {
                return this.he7Model.FourKPlateMax2;
            }

            set
            {
                this.he7Model.FourKPlateMax2 = value;
                this.RaisePropertyChanged("FourKPlateMax2");
            }
        }

        /// <summary>
        /// Gets or sets the he3 head temperature.
        /// </summary>
        /// <value>
        /// The he3 head temperature.
        /// </value>
        public double He3HeadTemp
        {
            get
            {
                return this.he7Model.He3HeadTemp;
            }

            set
            {
                this.he7Model.He3HeadTemp = value;
                this.RaisePropertyChanged("He3HeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 head max.
        /// </summary>
        public double He3HeadMax
        {
            get
            {
                return this.he7Model.He3HeadMax;
            }

            set
            {
                this.he7Model.He3HeadMax = value;
                this.RaisePropertyChanged("He3HeadMax");
            }
        }

        /// <summary>
        /// Gets or sets the he3 pump temperature.
        /// </summary>
        /// <value>
        /// The he3 pump temperature.
        /// </value>
        public double He3PumpTemp
        {
            get
            {
                return this.he7Model.He3PumpTemp;
            }

            set
            {
                this.he7Model.He3PumpTemp = value;
                this.RaisePropertyChanged("He3PumpTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump actual volt.
        /// </summary>
        public double He3PumpActualVolt
        {
            get
            {
                return this.he7Model.He3PumpActualVolt;
            }

            set
            {
                this.he7Model.He3PumpActualVolt = value;
                this.RaisePropertyChanged("He3PumpActualVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump new volt.
        /// </summary>
        public double He3PumpNewVolt
        {
            get
            {
                return this.he7Model.He3PumpNewVolt;
            }

            set
            {
                this.he7Model.He3PumpNewVolt = value;
                this.RaisePropertyChanged("He3PumpNewVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump max.
        /// </summary>
        public double He3PumpMax
        {
            get
            {
                return this.he7Model.He3PumpMax;
            }

            set
            {
                this.he7Model.He3PumpMax = value;
                this.RaisePropertyChanged("He3PumpMax");
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch temperature.
        /// </summary>
        /// <value>
        /// The he3 switch temperature.
        /// </value>
        public double He3SwitchTemp
        {
            get
            {
                return this.he7Model.He3SwitchTemp;
            }

            set
            {
                this.he7Model.He3SwitchTemp = value;
                this.RaisePropertyChanged("He3SwitchTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch actual volt.
        /// </summary>
        public double He3SwitchActualVolt
        {
            get
            {
                return this.he7Model.He3SwitchActualVolt;
            }

            set
            {
                this.he7Model.He3SwitchActualVolt = value;
                this.RaisePropertyChanged("He3SwitchActualVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch new volt.
        /// </summary>
        public double He3SwitchNewVolt
        {
            get
            {
                return this.he7Model.He3SwitchNewVolt;
            }

            set
            {
                this.he7Model.He3SwitchNewVolt = value;
                this.RaisePropertyChanged("He3SwitchNewVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch max 1.
        /// </summary>
        public double He3SwitchMax1
        {
            get
            {
                return this.he7Model.He3SwitchMax1;
            }

            set
            {
                this.he7Model.He3SwitchMax1 = value;
                this.RaisePropertyChanged("He3SwitchMax1");
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch max 2.
        /// </summary>
        public double He3SwitchMax2
        {
            get
            {
                return this.he7Model.He3SwitchMax2;
            }

            set
            {
                this.he7Model.He3SwitchMax2 = value;
                this.RaisePropertyChanged("He3SwitchMax2");
            }
        }

        /// <summary>
        /// Gets or sets the he4 head temperature.
        /// </summary>
        /// <value>
        /// The he4 head temperature.
        /// </value>
        public double He4HeadTemp
        {
            get
            {
                return this.he7Model.He4HeadTemp;
            }

            set
            {
                this.he7Model.He4HeadTemp = value;
                this.RaisePropertyChanged("He4HeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 head max.
        /// </summary>
        public double He4HeadMax
        {
            get
            {
                return this.he7Model.He4HeadMax;
            }

            set
            {
                this.he7Model.He4HeadMax = value;
                this.RaisePropertyChanged("He4HeadMax");
            }
        }

        /// <summary>
        /// Gets or sets the he4 pump temperature.
        /// </summary>
        /// <value>
        /// The he4 pump temperature.
        /// </value>
        public double He4PumpTemp
        {
            get
            {
                return this.he7Model.He4PumpTemp;
            }

            set
            {
                this.he7Model.He4PumpTemp = value;
                this.RaisePropertyChanged("He4PumpTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump actual volt.
        /// </summary>
        public double He4PumpActualVolt
        {
            get
            {
                return this.he7Model.He4PumpActualVolt;
            }

            set
            {
                this.he7Model.He4PumpActualVolt = value;
                this.RaisePropertyChanged("He4PumpActualVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump new volt.
        /// </summary>
        public double He4PumpNewVolt
        {
            get
            {
                return this.he7Model.He4PumpNewVolt;
            }

            set
            {
                this.he7Model.He4PumpNewVolt = value;
                this.RaisePropertyChanged("He4PumpNewVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump max.
        /// </summary>
        public double He4PumpMax
        {
            get
            {
                return this.he7Model.He4PumpMax;
            }

            set
            {
                this.he7Model.He4PumpMax = value;
                this.RaisePropertyChanged("He4PumpMax");
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch temperature.
        /// </summary>
        /// <value>
        /// The he4 switch temperature.
        /// </value>
        public double He4SwitchTemp
        {
            get
            {
                return this.he7Model.He4SwitchTemp;
            }

            set
            {
                this.he7Model.He4SwitchTemp = value;
                this.RaisePropertyChanged("He4SwitchTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch actual volt.
        /// </summary>
        public double He4SwitchActualVolt
        {
            get
            {
                return this.he7Model.He4SwitchActualVolt;
            }

            set
            {
                this.he7Model.He4SwitchActualVolt = value;
                this.RaisePropertyChanged("He4SwitchActualVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch new volt.
        /// </summary>
        public double He4SwitchNewVolt
        {
            get
            {
                return this.he7Model.He4SwitchNewVolt;
            }

            set
            {
                this.he7Model.He4SwitchNewVolt = value;
                this.RaisePropertyChanged("He4SwitchNewVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch max 1.
        /// </summary>
        public double He4SwitchMax1
        {
            get
            {
                return this.he7Model.He4SwitchMax1;
            }

            set
            {
                this.he7Model.He4SwitchMax1 = value;
                this.RaisePropertyChanged("He4SwitchMax1");
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch max 2.
        /// </summary>
        public double He4SwitchMax2
        {
            get
            {
                return this.he7Model.He4SwitchMax2;
            }

            set
            {
                this.he7Model.He4SwitchMax2 = value;
                this.RaisePropertyChanged("He4SwitchMax2");
            }
        }

        /// <summary>
        /// Gets or sets the two k plate temperature.
        /// </summary>
        /// <value>
        /// The two k plate temperature.
        /// </value>
        public double TwoKPlateTemp
        {
            get
            {
                return this.he7Model.TwoKPlateTemp;
            }

            set
            {
                this.he7Model.TwoKPlateTemp = value;
                this.RaisePropertyChanged("TwoKPlateTemp");
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        public double ConnectionState
        {
            get
            {
                return this.he7Model.ConnectionState;
            }

            set
            {
                this.he7Model.ConnectionState = value;
                this.RaisePropertyChanged("ConnectionState");
                this.RaisePropertyChanged("ConnectionStateConverted");
            }
        }

        /// <summary>
        /// Gets the connection state converted.
        /// </summary>
        public string ConnectionStateConverted
        {
            get
            {
                return this.ConvertConnectionStateNumberToString(this.he7Model.ConnectionState);
            }
        }
    }
}
