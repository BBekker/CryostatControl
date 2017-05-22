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
    using System.Collections.ObjectModel;
    using System.Windows.Input;

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
        /// The start button command
        /// </summary>
        private ICommand cancelButtonCommand;

        /// <summary>
        /// The radio button command
        /// </summary>
        private ICommand radioButtonCommand;

        /// <summary>
        /// The modus model
        /// </summary>
        private ModusModel modusModel;

        #endregion

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
        }

        #endregion

        #region Properties

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
                this.startButtonCommand = value;
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

        #endregion

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

        #endregion Methods
    }
}
