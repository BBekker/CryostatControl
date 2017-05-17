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

        /// <summary>
        /// Initializes a new instance of the <see cref="TestViewModel"/> class.
        /// </summary>
        public TestViewModel()
        {
            this.time = "Now";

            this.StartButtonCommand = new RelayCommand(this.ShowMessage, param => true);
            this.RadioButtonCommand = new RelayCommand(this.SetTime, param => true);
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
                Console.WriteLine("Changing Tabs {0}", this.selectedTabIndex);
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
                this.RaisePropertyChanged("SelectedComboIndex");
            }
        }

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

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void SetTime(object obj)
        {
            this.time = obj.ToString();
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        public void ShowMessage(object obj)
        {
            Console.WriteLine("Start - {0} - {1}", this.selectedComboIndex, this.time);
        }

        /// <summary>
        /// Tabs the message.
        /// </summary>
        public void TabMessage(object obj)
        {
            Console.WriteLine("Changing Tab");
        }
    }
}
