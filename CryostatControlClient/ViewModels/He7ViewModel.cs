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
        /// Gets or sets the four k plate temporary.
        /// </summary>
        /// <value>
        /// The four k plate temporary.
        /// </value>
        public int FourKPlateTemp
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
        /// Gets or sets the he3 head temporary.
        /// </summary>
        /// <value>
        /// The he3 head temporary.
        /// </value>
        public int He3HeadTemp
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
        /// Gets or sets the he3 pump temporary.
        /// </summary>
        /// <value>
        /// The he3 pump temporary.
        /// </value>
        public int He3PumpTemp
        {
            get
            {
                return this.he7Model.He3PumpTemp;
            }

            set
            {
                this.he7Model.He3HeadTemp = value;
                this.RaisePropertyChanged("He3PumpTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he3 pump volt.
        /// </summary>
        /// <value>
        /// The he3 pump volt.
        /// </value>
        public int He3PumpVolt
        {
            get
            {
                return this.he7Model.He3PumpVolt;
            }

            set
            {
                this.he7Model.He3PumpVolt = value;
                this.RaisePropertyChanged("He3PumpVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch temporary.
        /// </summary>
        /// <value>
        /// The he3 switch temporary.
        /// </value>
        public int He3SwitchTemp
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
        /// Gets or sets the he3 switch volt.
        /// </summary>
        /// <value>
        /// The he3 switch volt.
        /// </value>
        public int He3SwitchVolt
        {
            get
            {
                return this.he7Model.He3SwitchVolt;
            }

            set
            {
                this.he7Model.He3SwitchVolt = value;
                this.RaisePropertyChanged("He3SwitchVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he4 head temporary.
        /// </summary>
        /// <value>
        /// The he4 head temporary.
        /// </value>
        public int He4HeadTemp
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
        /// Gets or sets the he4 pump temporary.
        /// </summary>
        /// <value>
        /// The he4 pump temporary.
        /// </value>
        public int He4PumpTemp
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
        /// Gets or sets the he4 pump volt.
        /// </summary>
        /// <value>
        /// The he4 pump volt.
        /// </value>
        public int He4PumpVolt
        {
            get
            {
                return this.he7Model.He4PumpVolt;
            }

            set
            {
                this.he7Model.He3PumpVolt = value;
                this.RaisePropertyChanged("He4PumpVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch temporary.
        /// </summary>
        /// <value>
        /// The he4 switch temporary.
        /// </value>
        public int He4SwitchTemp
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
        /// Gets or sets the he4 switch volt.
        /// </summary>
        /// <value>
        /// The he4 switch volt.
        /// </value>
        public int He4SwitchVolt
        {
            get
            {
                return this.he7Model.He4SwitchVolt;
            }

            set
            {
                this.he7Model.He4SwitchVolt = value;
                this.RaisePropertyChanged("He4SwitchVolt");
            }
        }

        /// <summary>
        /// Gets or sets the two k plate temporary.
        /// </summary>
        /// <value>
        /// The two k plate temporary.
        /// </value>
        public int TwoKPlateTemp
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
    }
}
