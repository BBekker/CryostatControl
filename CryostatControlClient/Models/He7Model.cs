// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7Model.cs" company="SRON">
// SRON 2017.
// </copyright>
// <summary>
//   Model for He7-cooler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System;
    using System.Windows;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// Model for the He7-cooler.
    /// </summary>
    public class He7Model : AbstractModel
    {
        #region Fields

        /// <summary>
        /// The he3 head line series
        /// </summary>
        private LineSeries he3HeadLineSeriesBottom;

        /// <summary>
        /// The he4 head line series
        /// </summary>
        private LineSeries he4HeadLineSeriesBottom;

        /// <summary>
        /// The two k plate line series
        /// </summary>
        private LineSeries twoKPlateLineSeries;

        /// <summary>
        /// The four k plate line series
        /// </summary>
        private LineSeries fourKPlateLineSeries;

        /// <summary>
        /// The he3 head line series
        /// </summary>
        private LineSeries he3HeadLineSeries;

        /// <summary>
        /// The he3 pump line series
        /// </summary>
        private LineSeries he3PumpLineSeries;

        /// <summary>
        /// The he3 switch line series
        /// </summary>
        private LineSeries he3SwitchLineSeries;

        /// <summary>
        /// The he4 head line series
        /// </summary>
        private LineSeries he4HeadLineSeries;

        /// <summary>
        /// The he4 pump line series
        /// </summary>
        private LineSeries he4PumpLineSeries;

        /// <summary>
        /// The he4 switch line series
        /// </summary>
        private LineSeries he4SwitchLineSeries;

        /// <summary>
        /// The he3 head temporary list
        /// </summary>
        private double[] he3HeadTemporaryList;

        /// <summary>
        /// The he3 head temporary list
        /// </summary>
        private double[] he3HeadTemporaryListBottom;

        /// <summary>
        /// The he3 pump temporary list
        /// </summary>
        private double[] he3PumpTemporaryList;

        /// <summary>
        /// The he3 switch temporary list
        /// </summary>
        private double[] he3SwitchTemporaryList;

        /// <summary>
        /// The he4 head temporary list
        /// </summary>
        private double[] he4HeadTemporaryList;

        /// <summary>
        /// The he4 head temporary list
        /// </summary>
        private double[] he4HeadTemporaryListBottom;

        /// <summary>
        /// The he4 pump temporary list
        /// </summary>
        private double[] he4PumpTemporaryList;

        /// <summary>
        /// The he4 switch temporary list
        /// </summary>
        private double[] he4SwitchTemporaryList;

        /// <summary>
        /// The two k plate temporary list
        /// </summary>
        private double[] twoKPlateTemporaryList;

        /// <summary>
        /// The four k plate temporary list
        /// </summary>
        private double[] fourKPlateTemporaryList;

        /// <summary>
        /// The four k plate temperature
        /// </summary>
        private double fourKPlateTemp;

        /// <summary>
        /// The four k plate max 1.
        /// </summary>
        private double fourKPlateMax1;

        /// <summary>
        /// The four k plate max 2.
        /// </summary>
        private double fourKPlateMax2;

        /// <summary>
        /// The he3 head temperature
        /// </summary>
        private double he3HeadTemp;

        /// <summary>
        /// The he 3 head max.
        /// </summary>
        private double he3HeadMax;

        /// <summary>
        /// The he3 pump temperature
        /// </summary>
        private double he3PumpTemp;

        /// <summary>
        /// The he3 pump volt
        /// </summary>
        private double he3PumpActualVolt;

        /// <summary>
        /// The he 3 pump new volt.
        /// </summary>
        private double he3PumpNewVolt;

        /// <summary>
        /// The he 3 pump max.
        /// </summary>
        private double he3PumpMax;

        /// <summary>
        /// The he3 switch temperature
        /// </summary>
        private double he3SwitchTemp;

        /// <summary>
        /// The he3 switch actual volt
        /// </summary>
        private double he3SwitchActualVolt;

        /// <summary>
        /// The he 3 switch new volt.
        /// </summary>
        private double he3SwitchNewVolt;

        /// <summary>
        /// The he 3 switch max 1.
        /// </summary>
        private double he3SwitchMax1;

        /// <summary>
        /// The he 3 switch max 2.
        /// </summary>
        private double he3SwitchMax2;

        /// <summary>
        /// The he4 head temperature
        /// </summary>
        private double he4HeadTemp;

        /// <summary>
        /// The he 4 head max.
        /// </summary>
        private double he4HeadMax;

        /// <summary>
        /// The he4 pump temperature
        /// </summary>
        private double he4PumpTemp;

        /// <summary>
        /// The he4 pump actual volt
        /// </summary>
        private double he4PumpActualVolt;

        /// <summary>
        /// The he 4 pump new volt.
        /// </summary>
        private double he4PumpNewVolt;

        /// <summary>
        /// The he 4 pump max.
        /// </summary>
        private double he4PumpMax;

        /// <summary>
        /// The he4 switch temperature
        /// </summary>
        private double he4SwitchTemp;

        /// <summary>
        /// The he4 switch actual volt
        /// </summary>
        private double he4SwitchActualVolt;

        /// <summary>
        /// The he4 switch new volt
        /// </summary>
        private double he4SwitchNewVolt;

        /// <summary>
        /// The he 4 switch max 1.
        /// </summary>
        private double he4SwitchMax1;

        /// <summary>
        /// The he 4 switch max 2.
        /// </summary>
        private double he4SwitchMax2;

        /// <summary>
        /// The two k plate temperature
        /// </summary>
        private double twoKPlateTemp;

        /// <summary>
        /// The connection state.
        /// </summary>
        private double connectionState;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="He7Model"/> class.
        /// </summary>
        public He7Model()
        {
            this.twoKPlateTemporaryList = new double[this.TemporaryListSize];
            this.fourKPlateTemporaryList = new double[this.TemporaryListSize];

            this.he3HeadTemporaryList = new double[this.TemporaryListSize];
            this.he3HeadTemporaryListBottom = new double[this.TemporaryListSize];
            this.he3SwitchTemporaryList = new double[this.TemporaryListSize];
            this.he3PumpTemporaryList = new double[this.TemporaryListSize];

            this.he4HeadTemporaryList = new double[this.TemporaryListSize];
            this.he4HeadTemporaryListBottom = new double[this.TemporaryListSize];
            this.he4SwitchTemporaryList = new double[this.TemporaryListSize];
            this.he4PumpTemporaryList = new double[this.TemporaryListSize];

            this.twoKPlateLineSeries = new LineSeries { Title = "He7 - 2K Plate", Values = new ChartValues<DateTimePoint>() };
            this.fourKPlateLineSeries = new LineSeries { Title = "He7 - 4K Plate", Values = new ChartValues<DateTimePoint>() };

            this.he3HeadLineSeries = new LineSeries { Title = "He7 - He3 Head", Values = new ChartValues<DateTimePoint>() };
            this.he3PumpLineSeries = new LineSeries { Title = "He7 - He3 Pump", Values = new ChartValues<DateTimePoint>() };
            this.he3SwitchLineSeries = new LineSeries { Title = "He7 - He3 Switch", Values = new ChartValues<DateTimePoint>() };

            this.he4HeadLineSeries = new LineSeries { Title = "He7 - He4 Head", Values = new ChartValues<DateTimePoint>() };
            this.he4PumpLineSeries = new LineSeries { Title = "He7 - He4 Pump", Values = new ChartValues<DateTimePoint>() };
            this.he4SwitchLineSeries = new LineSeries { Title = "He7 - He4 Switch", Values = new ChartValues<DateTimePoint>() };

            this.he3HeadLineSeriesBottom = new LineSeries { Title = "He7 - He3 Head", Values = new ChartValues<DateTimePoint>() };
            this.he4HeadLineSeriesBottom = new LineSeries { Title = "He7 - He4 Head", Values = new ChartValues<DateTimePoint>() };
        }

        #endregion Constructor

        #region Properties

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
                return this.twoKPlateLineSeries.Visibility;
            }

            set
            {
                this.twoKPlateLineSeries.Visibility = value;
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
                return this.fourKPlateLineSeries.Visibility;
            }

            set
            {
                this.fourKPlateLineSeries.Visibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the he3 head plate visibility.
        /// </summary>
        /// <value>
        /// The he3 head plate visibility.
        /// </value>
        public Visibility He3HeadVisibility
        {
            get
            {
                return this.he3HeadLineSeries.Visibility;
            }

            set
            {
                this.he3HeadLineSeries.Visibility = value;
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
                return this.he3SwitchLineSeries.Visibility;
            }

            set
            {
                this.he3SwitchLineSeries.Visibility = value;
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
                return this.he3PumpLineSeries.Visibility;
            }

            set
            {
                this.he3PumpLineSeries.Visibility = value;
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
                return this.he4HeadLineSeries.Visibility;
            }

            set
            {
                this.he4HeadLineSeries.Visibility = value;
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
                return this.he4SwitchLineSeries.Visibility;
            }

            set
            {
                this.he4SwitchLineSeries.Visibility = value;
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
                return this.he4PumpLineSeries.Visibility;
            }

            set
            {
                this.he4PumpLineSeries.Visibility = value;
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
                return this.he4HeadLineSeriesBottom;
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
                return this.he3HeadLineSeriesBottom;
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
                return this.he4SwitchLineSeries;
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
                return this.he4PumpLineSeries;
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
                return this.he4HeadLineSeries;
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
                return this.he3SwitchLineSeries;
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
                return this.he3PumpLineSeries;
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
                return this.he3HeadLineSeries;
            }
        }

        /// <summary>
        /// Gets the two k plat line series.
        /// </summary>
        /// <value>
        /// The two k plat line series.
        /// </value>
        public LineSeries TwoKPlateLineSeries
        {
            get
            {
                return this.twoKPlateLineSeries;
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
                return this.fourKPlateLineSeries;
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
                return this.fourKPlateTemp;
            }

            set
            {
                this.fourKPlateTemp = value;
                this.fourKPlateTemporaryList = this.AddToGraph(this.fourKPlateTemporaryList, this.fourKPlateLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the four k plate max 1.
        /// </summary>
        public double FourKPlateMax1
        {
            get
            {
                return this.fourKPlateMax1;
            }

            set
            {
                this.fourKPlateMax1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the four k plate max 2.
        /// </summary>
        public double FourKPlateMax2
        {
            get
            {
                return this.fourKPlateMax2;
            }

            set
            {
                this.fourKPlateMax2 = value;
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
                return this.he3HeadTemp;
            }

            set
            {
                this.he3HeadTemp = value;
                this.he3HeadTemporaryList = this.AddToGraph(this.he3HeadTemporaryList, this.he3HeadLineSeries, value);
                this.he3HeadTemporaryListBottom = this.AddToGraph(this.he3HeadTemporaryListBottom, this.he3HeadLineSeriesBottom, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 3 head max.
        /// </summary>
        public double He3HeadMax
        {
            get
            {
                return this.he3HeadMax;
            }

            set
            {
                this.he3HeadMax = value;
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
                return this.he3PumpTemp;
            }

            set
            {
                this.he3PumpTemp = value;
                this.he3PumpTemporaryList = this.AddToGraph(this.he3PumpTemporaryList, this.he3PumpLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump actual volt.
        /// </summary>
        public double He3PumpActualVolt
        {
            get
            {
                return this.he3PumpActualVolt;
            }

            set
            {
                this.he3PumpActualVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump new volt.
        /// </summary>
        public double He3PumpNewVolt
        {
            get
            {
                return this.he3PumpNewVolt;
            }

            set
            {
                this.he3PumpNewVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump max.
        /// </summary>
        public double He3PumpMax
        {
            get
            {
                return this.he3PumpMax;
            }

            set
            {
                this.he3PumpMax = value;
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
                return this.he3SwitchTemp;
            }

            set
            {
                this.he3SwitchTemp = value;
                this.he3SwitchTemporaryList = this.AddToGraph(this.he3SwitchTemporaryList, this.he3SwitchLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch actual volt.
        /// </summary>
        public double He3SwitchActualVolt
        {
            get
            {
                return this.he3SwitchActualVolt;
            }

            set
            {
                this.he3SwitchActualVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch new volt.
        /// </summary>
        public double He3SwitchNewVolt
        {
            get
            {
                return this.he3SwitchNewVolt;
            }

            set
            {
                this.he3SwitchNewVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch max 1.
        /// </summary>
        public double He3SwitchMax1
        {
            get
            {
                return this.he3SwitchMax1;
            }

            set
            {
                this.he3SwitchMax1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch max 2.
        /// </summary>
        public double He3SwitchMax2
        {
            get
            {
                return this.he3SwitchMax2;
            }

            set
            {
                this.he3SwitchMax2 = value;
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
                return this.he4HeadTemp;
            }

            set
            {
                this.he4HeadTemp = value;
                this.he4HeadTemporaryList = this.AddToGraph(this.he4HeadTemporaryList, this.he4HeadLineSeries, value);
                this.he4HeadTemporaryListBottom = this.AddToGraph(this.he4HeadTemporaryListBottom, this.he4HeadLineSeriesBottom, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 4 head max.
        /// </summary>
        public double He4HeadMax
        {
            get
            {
                return this.he4HeadMax;
            }

            set
            {
                this.he4HeadMax = value;
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
                return this.he4PumpTemp;
            }

            set
            {
                this.he4PumpTemp = value;
                this.he4PumpTemporaryList = this.AddToGraph(this.he4PumpTemporaryList, this.he4PumpLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump actual volt.
        /// </summary>
        public double He4PumpActualVolt
        {
            get
            {
                return this.he4PumpActualVolt;
            }

            set
            {
                this.he4PumpActualVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump new volt.
        /// </summary>
        public double He4PumpNewVolt
        {
            get
            {
                return this.he4PumpNewVolt;
            }

            set
            {
                this.he4PumpNewVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump max.
        /// </summary>
        public double He4PumpMax
        {
            get
            {
                return this.he4PumpMax;
            }

            set
            {
                this.he4PumpMax = value;
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
                return this.he4SwitchTemp;
            }

            set
            {
                this.he4SwitchTemp = value;
                this.he4SwitchTemporaryList = this.AddToGraph(this.he4SwitchTemporaryList, this.he4SwitchLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch actual volt.
        /// </summary>
        public double He4SwitchActualVolt
        {
            get
            {
                return this.he4SwitchActualVolt;
            }

            set
            {
                this.he4SwitchActualVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch new volt.
        /// </summary>
        public double He4SwitchNewVolt
        {
            get
            {
                return this.he4SwitchNewVolt;
            }

            set
            {
                this.he4SwitchNewVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch max 1.
        /// </summary>
        public double He4SwitchMax1
        {
            get
            {
                return this.he4SwitchMax1;
            }

            set
            {
                this.he4SwitchMax1 = value;
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch max 2.
        /// </summary>
        public double He4SwitchMax2
        {
            get
            {
                return this.he4SwitchMax2;
            }

            set
            {
                this.he4SwitchMax2 = value;
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
                return this.twoKPlateTemp;
            }

            set
            {
                this.twoKPlateTemp = value;
                this.twoKPlateTemporaryList = this.AddToGraph(this.twoKPlateTemporaryList, this.twoKPlateLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        public double ConnectionState
        {
            get
            {
                return this.connectionState;
            }

            set
            {
                this.connectionState = value;
            }
        }

        #endregion Properties
    }
}