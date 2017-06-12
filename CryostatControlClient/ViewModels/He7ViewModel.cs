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
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using CryostatControlClient.Models;

    using LiveCharts.Wpf;

    /// <summary>
    /// The he 7 view model.
    /// </summary>
    public class He7ViewModel : AbstractViewModel
    {
        #region Fields 

        /// <summary>
        /// The he 7 model.
        /// </summary>
        private He7Model he7Model;

        /// <summary>
        /// The update button command
        /// </summary>
        private ICommand updateCommand;

        /// <summary>
        /// The two k plate visibility command
        /// </summary>
        private ICommand twoKPlateVisibilityCommand;

        /// <summary>
        /// The four k plate visibility command
        /// </summary>
        private ICommand fourKPlateVisibilityCommand;

        /// <summary>
        /// The he3 head visibility command
        /// </summary>
        private ICommand he3HeadVisibilityCommand;

        /// <summary>
        /// The he3 switch visibility command
        /// </summary>
        private ICommand he3SwitchVisibilityCommand;

        /// <summary>
        /// The he3 pump visibility command
        /// </summary>
        private ICommand he3PumpVisibilityCommand;

        /// <summary>
        /// The he4 head visibility command
        /// </summary>
        private ICommand he4HeadVisibilityCommand;

        /// <summary>
        /// The he4 switch visibility command
        /// </summary>
        private ICommand he4SwitchVisibilityCommand;

        /// <summary>
        /// The he4 pump visibility command
        /// </summary>
        private ICommand he4PumpVisibilityCommand;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="He7ViewModel"/> class.
        /// </summary>
        public He7ViewModel()
        {
            this.he7Model = new He7Model();

            this.updateCommand = new RelayCommand(this.OnClickUpdate, param => true);

            this.twoKPlateVisibilityCommand = new RelayCommand(this.OnTwoKPlateVisibility, param => true);
            this.fourKPlateVisibilityCommand = new RelayCommand(this.OnFourKPlateVisibility, param => true);
            this.he3HeadVisibilityCommand = new RelayCommand(this.OnHe3HeadVisibility, param => true);
            this.he3SwitchVisibilityCommand = new RelayCommand(this.OnHe3SwitchVisibility, param => true);
            this.he3PumpVisibilityCommand = new RelayCommand(this.OnHe3PumpVisibility, param => true);
            this.he4HeadVisibilityCommand = new RelayCommand(this.OnHe4HeadVisibility, param => true);
            this.he4SwitchVisibilityCommand = new RelayCommand(this.OnHe4SwitchVisibility, param => true);
            this.he4PumpVisibilityCommand = new RelayCommand(this.OnHe4PumpVisibility, param => true);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the two k plate visibility command.
        /// </summary>
        /// <value>
        /// The two k plate visibility command.
        /// </value>
        public ICommand TwoKPlateVisibilityCommand
        {
            get
            {
                return this.twoKPlateVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the four k plate visibility command.
        /// </summary>
        /// <value>
        /// The four k plate visibility command.
        /// </value>
        public ICommand FourKPlateVisibilityCommand
        {
            get
            {
                return this.fourKPlateVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he3 head visibility command.
        /// </summary>
        /// <value>
        /// The he3 head visibility command.
        /// </value>
        public ICommand He3HeadVisibilityCommand
        {
            get
            {
                return this.he3HeadVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he3 pump visibility command.
        /// </summary>
        /// <value>
        /// The he3 pump visibility command.
        /// </value>
        public ICommand He3PumpVisibilityCommand
        {
            get
            {
                return this.he3PumpVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he3 switch visibility command.
        /// </summary>
        /// <value>
        /// The he3 switch visibility command.
        /// </value>
        public ICommand He3SwitchVisibilityCommand
        {
            get
            {
                return this.he3SwitchVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he4 head visibility command.
        /// </summary>
        /// <value>
        /// The he4 head visibility command.
        /// </value>
        public ICommand He4HeadVisibilityCommand
        {
            get
            {
                return this.he4HeadVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he4 switch visibility command.
        /// </summary>
        /// <value>
        /// The he4 switch visibility command.
        /// </value>
        public ICommand He4SwitchVisibilityCommand
        {
            get
            {
                return this.he4SwitchVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the he4 pump visibility command.
        /// </summary>
        /// <value>
        /// The he4 pump visibility command.
        /// </value>
        public ICommand He4PumpVisibilityCommand
        {
            get
            {
                return this.he4PumpVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets or sets the two k plate visibility.
        /// </summary>
        /// <value>
        /// The two k plate visibility.
        /// </value>
        public Visibility TwoKPlateVisibility
        {
            get
            {
                return this.he7Model.TwoKPlateVisibility;
            }

            set
            {
                this.he7Model.TwoKPlateVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the four k plate visibility.
        /// </summary>
        /// <value>
        /// The four k plate visibility.
        /// </value>
        public Visibility FourKPlateVisibility
        {
            get
            {
                return this.he7Model.FourKPlateVisibility;
            }

            set
            {
                this.he7Model.FourKPlateVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he3 head visibility.
        /// </summary>
        /// <value>
        /// The he3 head visibility.
        /// </value>
        public Visibility He3HeadVisibility
        {
            get
            {
                return this.he7Model.He3HeadVisibility;
            }

            set
            {
                this.he7Model.He3HeadVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch visibility.
        /// </summary>
        /// <value>
        /// The he3 switch visibility.
        /// </value>
        public Visibility He3SwitchVisibility
        {
            get
            {
                return this.he7Model.He3SwitchVisibility;
            }

            set
            {
                this.he7Model.He3SwitchVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he3 pump visibility.
        /// </summary>
        /// <value>
        /// The he3 pump visibility.
        /// </value>
        public Visibility He3PumpVisibility
        {
            get
            {
                return this.he7Model.He3PumpVisibility;
            }

            set
            {
                this.he7Model.He3PumpVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he4 head visibility.
        /// </summary>
        /// <value>
        /// The he4 head visibility.
        /// </value>
        public Visibility He4HeadVisibility
        {
            get
            {
                return this.he7Model.He4HeadVisibility;
            }

            set
            {
                this.he7Model.He4HeadVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch visibility.
        /// </summary>
        /// <value>
        /// The he4 switch visibility.
        /// </value>
        public Visibility He4SwitchVisibility
        {
            get
            {
                return this.he7Model.He4SwitchVisibility;
            }

            set
            {
                this.he7Model.He4SwitchVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he4 pump visibility.
        /// </summary>
        /// <value>
        /// The he4 pump visibility.
        /// </value>
        public Visibility He4PumpVisibility
        {
            get
            {
                return this.he7Model.He4PumpVisibility;
            }

            set
            {
                this.he7Model.He4PumpVisibility = value;
            }
        }

        /// <summary>
        /// Gets the he4 head line series.
        /// </summary>
        /// <value>
        /// The he4 head line series.
        /// </value>
        public LineSeries He4HeadLineSeriesBottom
        {
            get
            {
                return this.he7Model.He4HeadLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he3 head line series.
        /// </summary>
        /// <value>
        /// The he3 head line series.
        /// </value>
        public LineSeries He3HeadLineSeriesBottom
        {
            get
            {
                return this.he7Model.He3HeadLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he4 switch line series.
        /// </summary>
        /// <value>
        /// The he4 switch line series.
        /// </value>
        public LineSeries He4SwitchLineSeries
        {
            get
            {
                return this.he7Model.He4SwitchLineSeries;
            }
        }

        /// <summary>
        /// Gets the he4 pump line series.
        /// </summary>
        /// <value>
        /// The he4 pump line series.
        /// </value>
        public LineSeries He4PumpLineSeries
        {
            get
            {
                return this.he7Model.He4PumpLineSeries;
            }
        }

        /// <summary>
        /// Gets the he4 head line series.
        /// </summary>
        /// <value>
        /// The he4 head line series.
        /// </value>
        public LineSeries He4HeadLineSeries
        {
            get
            {
                return this.he7Model.He4HeadLineSeries;
            }
        }

        /// <summary>
        /// Gets the he3 switch line series.
        /// </summary>
        /// <value>
        /// The he3 switch line series.
        /// </value>
        public LineSeries He3SwitchLineSeries
        {
            get
            {
                return this.he7Model.He3SwitchLineSeries;
            }
        }

        /// <summary>
        /// Gets the he3 pump line series.
        /// </summary>
        /// <value>
        /// The he3 pump line series.
        /// </value>
        public LineSeries He3PumpLineSeries
        {
            get
            {
                return this.he7Model.He3PumpLineSeries;
            }
        }

        /// <summary>
        /// Gets the he3 head line series.
        /// </summary>
        /// <value>
        /// The he3 head line series.
        /// </value>
        public LineSeries He3HeadLineSeries
        {
            get
            {
                return this.he7Model.He3HeadLineSeries;
            }
        }

        /// <summary>
        /// Gets the two k plat line series.
        /// </summary>
        /// <value>
        /// The two k plat line series.
        /// </value>
        public LineSeries TwoKPlatLineSeries
        {
            get
            {
                return this.he7Model.TwoKPlateLineSeries;
            }
        }

        /// <summary>
        /// Gets the four k plate line series.
        /// </summary>
        /// <value>
        /// The four k plate line series.
        /// </value>
        public LineSeries FourKPlateLineSeries
        {
            get
            {
                return this.he7Model.FourKPlateLineSeries;
            }
        }

        /// <summary>
        /// Gets the color of the connection state.
        /// </summary>
        /// <value>
        /// The color of the connection state.
        /// </value>
        public SolidColorBrush ConnectionStateColor
        {
            get
            {
                return this.DisplayColor((ColorState)this.ConnectionState);
            }
        }

        /// <summary>
        /// Gets or sets the update button command.
        /// </summary>
        /// <value>
        /// The hi button command.
        /// </value>
        public ICommand UpdateButtonCommand
        {
            get
            {
                return this.updateCommand;
            }

            set
            {
                this.updateCommand = value;
            }
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
                this.RaisePropertyChanged("ConnectionStateColor");
            }
        }

        /// <summary>
        /// Gets a value indicating whether [update enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [update enable]; otherwise, <c>false</c>.
        /// </value>
        public bool UpdateEnable
        {
            get
            {
                if (this.ConnectionState == 1)
                {
                    return true;
                }

                return false;
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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Called when [two k plate visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnTwoKPlateVisibility(object obj)
        {
            if (this.TwoKPlateVisibility == Visibility.Hidden)
            {
                this.TwoKPlateVisibility = Visibility.Visible;
            }
            else
            {
                this.TwoKPlateVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [four k plate visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnFourKPlateVisibility(object obj)
        {
            if (this.FourKPlateVisibility == Visibility.Hidden)
            {
                this.FourKPlateVisibility = Visibility.Visible;
            }
            else
            {
                this.FourKPlateVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he3 head visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe3HeadVisibility(object obj)
        {
            if (this.He3HeadVisibility == Visibility.Hidden)
            {
                this.He3HeadVisibility = Visibility.Visible;
            }
            else
            {
                this.He3HeadVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he3 switch visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe3SwitchVisibility(object obj)
        {
            if (this.He3SwitchVisibility == Visibility.Hidden)
            {
                this.He3SwitchVisibility = Visibility.Visible;
            }
            else
            {
                this.He3SwitchVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he3 pump visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe3PumpVisibility(object obj)
        {
            if (this.He3PumpVisibility == Visibility.Hidden)
            {
                this.He3PumpVisibility = Visibility.Visible;
            }
            else
            {
                this.He3PumpVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he4 head visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe4HeadVisibility(object obj)
        {
            if (this.He4HeadVisibility == Visibility.Hidden)
            {
                this.He4HeadVisibility = Visibility.Visible;
            }
            else
            {
                this.He4HeadVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he4 switch visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe4SwitchVisibility(object obj)
        {
            if (this.He4SwitchVisibility == Visibility.Hidden)
            {
                this.He4SwitchVisibility = Visibility.Visible;
            }
            else
            {
                this.He4SwitchVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [he4 pump visibility].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHe4PumpVisibility(object obj)
        {
            if (this.He4PumpVisibility == Visibility.Hidden)
            {
                this.He4PumpVisibility = Visibility.Visible;
            }
            else
            {
                this.He4PumpVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnClickUpdate(object obj)
        {
            this.RaisePropertyChanged("UpdateHe7Pressed");
        }

        #endregion Methods
    }
}
