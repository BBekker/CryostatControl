// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModusViewModel.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using CryostatControlClient.Communication;
    using CryostatControlClient.Models;

    using CryostatControlServer;

    /// <summary>
    /// The modus viewmodel
    /// </summary>
    /// <seealso cref="CryostatControlClient.ViewModels.AbstractViewModel" />
    public class ModusViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The start button command
        /// </summary>
        private ICommand startButtonCommand;

        /// <summary>
        /// The cancel button command
        /// </summary>
        private ICommand cancelButtonCommand;

        /// <summary>
        /// The manual button command
        /// </summary>
        private ICommand manualButtonCommand;

        /// <summary>
        /// The stop button command
        /// </summary>
        private ICommand stopButtonCommand;

        /// <summary>
        /// The radio button command
        /// </summary>
        private ICommand radioButtonCommand;

        /// <summary>
        /// The modus model
        /// </summary>
        private ModusModel modusModel;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModusViewModel"/> class.
        /// </summary>
        public ModusViewModel()
        {
            this.modusModel = new ModusModel();

            this.StartButtonCommand = new RelayCommand(this.OnClickStart, param => true);
            this.RadioButtonCommand = new RelayCommand(this.OnChangeRadio, param => true);
            this.cancelButtonCommand = new RelayCommand(this.OnClickCancel, param => true);
            this.manualButtonCommand = new RelayCommand(this.OnClickManual, param => true);
            this.stopButtonCommand = new RelayCommand(this.onClickStop, param => true);
            this.ToggleTime();
        }

        #endregion Constructor

        #region Properties

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
                return this.DisplayColor((ColorState)Convert.ToInt32(this.ServerConnection));
            }
        }

        /// <summary>
        /// Gets the planned modus.
        /// </summary>
        /// <value>
        /// The planned modus.
        /// </value>
        public string PlannedModus
        {
            get
            {
                switch (this.modusModel.Modus)
                {
                    case (int)Controlstate.CooldownStart: return "Cool down";
                    case (int)Controlstate.WarmupStart: return "Warm up";
                    case (int)Controlstate.RecycleStart: return "Recycle";
                    default: return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the planned time.
        /// </summary>
        /// <value>
        /// The planned time.
        /// </value>
        public DateTime PlannedTime
        {
            get
            {
                return this.modusModel.PlannedTime;
            }

            set
            {
                this.modusModel.PlannedTime = value;
                this.RaisePropertyChanged("PlannedTime");
                this.RaisePropertyChanged("PlannedTimeConverted");
            }
        }

        /// <summary>
        /// Gets the planned time converted.
        /// </summary>
        /// <value>
        /// The planned time converted.
        /// </value>
        public string PlannedTimeConverted
        {
            get
            {
                return DateTime.Now.Subtract(this.PlannedTime).ToString(@"dd\ \d\a\y\s\ hh\:mm\:ss");
            }
        }

        /// <summary>
        /// Gets the show countdown.
        /// </summary>
        /// <value>
        /// The show countdown.
        /// </value>
        public Visibility ShowCountdown
        {
            get
            {
                if (string.IsNullOrEmpty(this.PlannedModus))
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [start mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [start mode]; otherwise, <c>false</c>.
        /// </value>
        public bool StartMode
        {
            get
            {
                return this.Modus == (int)Controlstate.Standby;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [cancel mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [cancel mode]; otherwise, <c>false</c>.
        /// </value>
        public bool CancelMode
        {
            get
            {
                return this.Modus != (int)Controlstate.Standby && this.Modus != (int)Controlstate.Setup;
            }
        }

        /// <summary>
        /// Gets or sets the selected time.
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedTime
        {
            get
            {
                return this.modusModel.SelectedTime;
            }

            set
            {
                this.modusModel.SelectedTime = value;
                this.RaisePropertyChanged("SelectedTime");
            }
        }

        /// <summary>
        /// Gets or sets the selected date.
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedDate
        {
            get
            {
                return this.modusModel.SelectedDate;
            }

            set
            {
                this.modusModel.SelectedDate = value;
                this.RaisePropertyChanged("SelectedDate");
            }
        }

        /// <summary>
        /// Gets or sets the show date time.
        /// </summary>
        /// <value>
        /// The show date time.
        /// </value>
        public string ShowDateTime
        {
            get
            {
                return this.modusModel.ShowDateTime;
            }

            set
            {
                this.modusModel.ShowDateTime = value;
                this.RaisePropertyChanged("ShowDateTime");
            }
        }

        /// <summary>
        /// Gets or sets the modus.
        /// </summary>
        /// <value>
        /// The modus.
        /// </value>
        public int Modus
        {
            get
            {
                return this.modusModel.Modus;
            }

            set
            {
                this.modusModel.Modus = value;
                this.RaisePropertyChanged("Modus");
                this.RaisePropertyChanged("StartMode");
                this.RaisePropertyChanged("CancelMode");
                this.RaisePropertyChanged("ModusConverted");
                this.RaisePropertyChanged("ShowCountdown");
            }
        }

        /// <summary>
        /// Gets the modus converted.
        /// </summary>
        /// <value>
        /// The modus converted.
        /// </value>
        public string ModusConverted
        {
            get
            {
                return this.ConvertModusNumberToString(this.modusModel.Modus);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the server is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if server connected; otherwise, <c>false</c>.
        /// </value>
        public bool ServerConnection
        {
            get
            {
                return this.modusModel.ServerConnection;
            }

            set
            {
                this.modusModel.ServerConnection = value;
                this.RaisePropertyChanged("Server");
                this.RaisePropertyChanged("ServerConverted");
                this.RaisePropertyChanged("ConnectionStateColor");
            }
        }

        /// <summary>
        /// Gets the server connection converted.
        /// </summary>
        /// <value>
        /// The server converted.
        /// </value>
        public string ServerConverted
        {
            get
            {
                if (this.ServerConnection)
                {
                    return "Connected";
                }

                return "Disconnected";
            }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time
        {
            get
            {
                return this.modusModel.Time;
            }

            set
            {
                this.modusModel.Time = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected combo.
        /// </summary>
        /// <value>
        /// The index of the selected combo.
        /// </value>
        public int SelectedComboIndex
        {
            get
            {
                return this.modusModel.SelectedComboIndex;
            }

            set
            {
                this.modusModel.SelectedComboIndex = value;
            }
        }

        #endregion Properties

        #region Commands

        /// <summary>
        /// Gets or sets the start button command.
        /// </summary>
        /// <value>
        /// The hi button command.
        /// </value>
        public ICommand StartButtonCommand
        {
            get
            {
                return this.startButtonCommand;
            }

            set
            {
                this.startButtonCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the cancel button command.
        /// </summary>
        /// <value>
        /// The cancel button command.
        /// </value>
        public ICommand CancelButtonCommand
        {
            get
            {
                return this.cancelButtonCommand;
            }

            set
            {
                this.cancelButtonCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the manual mode button command.
        /// </summary>
        /// <value>
        /// The cancel button command.
        /// </value>
        public ICommand ManualButtonCommand
        {
            get
            {
                return this.manualButtonCommand;
            }

            set
            {
                this.manualButtonCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the stop button command.
        /// </summary>
        /// <value>
        /// The stop button command.
        /// </value>
        public ICommand StopButtonCommand
        {
            get
            {
                return this.stopButtonCommand;
            }

            set
            {
                this.stopButtonCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the radio button command.
        /// </summary>
        /// <value>
        /// The radio button command.
        /// </value>
        public ICommand RadioButtonCommand
        {
            get
            {
                return this.radioButtonCommand;
            }

            set
            {
                this.radioButtonCommand = value;
            }
        }

        #endregion Commands

        #region Methods

        /// <summary>
        /// Convert operating state number to string.
        /// </summary>
        /// <param name="modusNumber">The modus number.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public string ConvertModusNumberToString(double modusNumber)
        {
            return ((Controlstate)modusNumber).ToString();
        }

        /// <summary>
        /// Handles radio change.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnChangeRadio(object obj)
        {
            this.Time = obj.ToString();
            this.ToggleTime();
        }

        /// <summary>
        /// Handles start click.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickStart(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { this.StartControlProcess(); }));
        }

        /// <summary>
        /// Handles cancel click.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickCancel(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { ServerCheck.CommandClient.Cancel(); }));        
        }

        /// <summary>
        /// Handles manual click.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickManual(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { ServerCheck.CommandClient.Manual(); }));       
        }

        public void onClickStop(object obj)
        {

        }

        /// <summary>
        /// Task method to start the control process.
        /// </summary>
        private void StartControlProcess()
        {
            if (ServerCheck.CommandClient.State == CommunicationState.Opened)
            {
                int radio = this.SelectedComboIndex;
                string postpone = this.Time;
                DateTime startTime = DateTime.Now;

                if (postpone == "Scheduled")
                {
                    startTime = this.SelectedDate;
                    TimeSpan time = this.SelectedTime.TimeOfDay;
                    startTime = startTime.Date.Add(time);
                }

                switch (radio)
                {
                    case (int)ModusEnumerator.Cooldown:
                        ServerCheck.CommandClient.CooldownTime(startTime);
                        break;

                    case (int)ModusEnumerator.Recycle:
                        ServerCheck.CommandClient.RecycleTime(startTime);
                        break;

                    case (int)ModusEnumerator.Warmup:
                        ServerCheck.CommandClient.WarmupTime(startTime);
                        break;
                }
            }
        }

        /// <summary>
        /// Toggles the time.
        /// </summary>
        private void ToggleTime()
        {
            if (this.Time == "Now")
            {
                this.ShowDateTime = "Hidden";
            }
            else
            {
                this.ShowDateTime = "Visible";
            }
        }

        #endregion Methods
    }
}