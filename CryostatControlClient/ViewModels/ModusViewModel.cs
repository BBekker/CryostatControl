// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModusViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Windows.Media;

    using CryostatControlClient.Models;

    using CryostatControlServer;

    /// <summary>
    /// For trying out
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
                return this.ConnectionColor(Convert.ToInt32(this.ServerConnection));
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
        /// Gets the server converted.
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
        /// Gets or sets the hi button command.
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
        /// Gets or sets the manual button command.
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
        /// Changes time of command.
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
            this.RaisePropertyChanged("StartPressed");
        }

        /// <summary>
        /// Handles cancel click.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickCancel(object obj)
        {
            this.RaisePropertyChanged("CancelPressed");
        }

        /// <summary>
        /// Called when [click manual].
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickManual(object obj)
        {
            this.RaisePropertyChanged("ManualPressed");
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