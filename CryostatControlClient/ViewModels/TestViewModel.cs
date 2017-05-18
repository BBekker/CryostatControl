// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestViewModel.cs" company="SRON">
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

    /// <summary>
    /// For trying out
    /// </summary>
    /// <seealso cref="CryostatControlClient.ViewModels.AbstractViewModel" />
    public class TestViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The start button command
        /// </summary>
        private ICommand startButtonCommand;

        /// <summary>
        /// The radio button command
        /// </summary>
        private ICommand radioButtonCommand;

        /// <summary>
        /// The command
        /// </summary>
        private string time;

        /// <summary>
        /// The selected tab index
        /// </summary>
        private int selectedTabIndex;

        /// <summary>
        /// The selected tab index
        /// </summary>
        private int selectedComboIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TestViewModel"/> class.
        /// </summary>
        public TestViewModel()
        {
            this.time = "Now";
            He7ViewModel.PropertyChanged += this.PropertyChanged;

            this.StartButtonCommand = new RelayCommand(this.OnClickStart, param => true);
            this.RadioButtonCommand = new RelayCommand(this.OnChangeRadio, param => true);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time
        {
            get
            {
                return this.time;
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected tab.
        /// </summary>
        /// <value>
        /// The index of the selected tab.
        /// </value>
        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }
            set
            {
                this.selectedTabIndex = value;
                this.RaisePropertyChanged("SelectedTabIndex");
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
                return this.selectedComboIndex;
            }
            set
            {
                this.selectedComboIndex = value;
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
                this.RaisePropertyChanged("StartPressed");
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
        /// Shows the message.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnChangeRadio(object obj)
        {
            this.time = obj.ToString();
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void OnClickStart(object obj)
        {
            Console.WriteLine("Start - {0} - {1}", this.selectedComboIndex, this.time);
        }

        #endregion Methods
    }
}
