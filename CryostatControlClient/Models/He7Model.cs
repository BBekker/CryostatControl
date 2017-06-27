// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7Model.cs" company="SRON">
// Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System;
    using System.Windows;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Geared;
    using LiveCharts.Wpf;
    using System.Windows.Media;

    /// <summary>
    /// Model for the He7-cooler.
    /// </summary>
    public class He7Model : AbstractModel
    {
        #region Fields

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
        /// The he3 head temperature
        /// </summary>
        private double he3HeadTemp;

        /// <summary>
        /// The he3 pump temperature
        /// </summary>
        private double he3PumpTemp;

        /// <summary>
        /// The he3 switch temperature
        /// </summary>
        private double he3SwitchTemp;

        /// <summary>
        /// The he4 head temperature
        /// </summary>
        private double he4HeadTemp;

        /// <summary>
        /// The he4 pump temperature
        /// </summary>
        private double he4PumpTemp;

        /// <summary>
        /// The he4 switch temperature
        /// </summary>
        private double he4SwitchTemp;

        /// <summary>
        /// The two k plate temperature
        /// </summary>
        private double twoKPlateTemp;

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

            this.TwoKPlateLineSeries = new GLineSeries { Title = "He7 - 2K Plate", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent};
            this.FourKPlateLineSeries = new GLineSeries { Title = "He7 - 4K Plate", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };

            this.He3HeadLineSeries = new GLineSeries { Title = "He7 - He3 Head", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
            this.He3PumpLineSeries = new GLineSeries { Title = "He7 - He3 Pump", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
            this.He3SwitchLineSeries = new GLineSeries { Title = "He7 - He3 Switch", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };

            this.He4HeadLineSeries = new GLineSeries { Title = "He7 - He4 Head", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
            this.He4PumpLineSeries = new GLineSeries { Title = "He7 - He4 Pump", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
            this.He4SwitchLineSeries = new GLineSeries { Title = "He7 - He4 Switch", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };

            this.He3HeadLineSeriesBottom = new GLineSeries { Title = "He7 - He3 Head", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
            this.He4HeadLineSeriesBottom = new GLineSeries { Title = "He7 - He4 Head", Values = new GearedValues<DateTimePoint>(), Fill = Brushes.Transparent };
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
                return this.TwoKPlateLineSeries.Visibility;
            }

            set
            {
                this.TwoKPlateLineSeries.Visibility = value;
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
                return this.FourKPlateLineSeries.Visibility;
            }

            set
            {
                this.FourKPlateLineSeries.Visibility = value;
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
                return this.He3HeadLineSeries.Visibility;
            }

            set
            {
                this.He3HeadLineSeries.Visibility = value;
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
                return this.He3SwitchLineSeries.Visibility;
            }

            set
            {
                this.He3SwitchLineSeries.Visibility = value;
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
                return this.He3PumpLineSeries.Visibility;
            }

            set
            {
                this.He3PumpLineSeries.Visibility = value;
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
                return this.He4HeadLineSeries.Visibility;
            }

            set
            {
                this.He4HeadLineSeries.Visibility = value;
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
                return this.He4SwitchLineSeries.Visibility;
            }

            set
            {
                this.He4SwitchLineSeries.Visibility = value;
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
                return this.He4PumpLineSeries.Visibility;
            }

            set
            {
                this.He4PumpLineSeries.Visibility = value;
            }
        }

        /// <summary>
        /// Gets the he4 head line series.
        /// </summary>
        /// <value>
        /// The he4 head line series.
        /// </value>
        public GLineSeries He4HeadLineSeriesBottom { get; }

        /// <summary>
        /// Gets the he3 head line series.
        /// </summary>
        /// <value>
        /// The he3 head line series.
        /// </value>
        public GLineSeries He3HeadLineSeriesBottom { get; }

        /// <summary>
        /// Gets the he4 switch line series.
        /// </summary>
        /// <value>
        /// The he4 switch line series.
        /// </value>
        public GLineSeries He4SwitchLineSeries { get; }

        /// <summary>
        /// Gets the he4 pump line series.
        /// </summary>
        /// <value>
        /// The he4 pump line series.
        /// </value>
        public GLineSeries He4PumpLineSeries { get; }

        /// <summary>
        /// Gets the he4 head line series.
        /// </summary>
        /// <value>
        /// The he4 head line series.
        /// </value>
        public GLineSeries He4HeadLineSeries { get; }

        /// <summary>
        /// Gets the he3 switch line series.
        /// </summary>
        /// <value>
        /// The he3 switch line series.
        /// </value>
        public GLineSeries He3SwitchLineSeries { get; }

        /// <summary>
        /// Gets the he3 pump line series.
        /// </summary>
        /// <value>
        /// The he3 pump line series.
        /// </value>
        public GLineSeries He3PumpLineSeries { get; }

        /// <summary>
        /// Gets the he3 head line series.
        /// </summary>
        /// <value>
        /// The he3 head line series.
        /// </value>
        public GLineSeries He3HeadLineSeries { get; }

        /// <summary>
        /// Gets the two k plat line series.
        /// </summary>
        /// <value>
        /// The two k plat line series.
        /// </value>
        public GLineSeries TwoKPlateLineSeries { get; }

        /// <summary>
        /// Gets the four k plate line series.
        /// </summary>
        /// <value>
        /// The four k plate line series.
        /// </value>
        public GLineSeries FourKPlateLineSeries { get; }

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
                this.fourKPlateTemporaryList = this.AddToGraph(this.fourKPlateTemporaryList, this.FourKPlateLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the four k plate max 1.
        /// </summary>
        /// <value>
        /// The four k plate max 1.
        /// </value>
        public double FourKPlateMax1 { get; set; }

        /// <summary>
        /// Gets or sets the four k plate max 2.
        /// </summary>
        /// <value>
        /// The four k plate max 2.
        /// </value>
        public double FourKPlateMax2 { get; set; }

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
                this.he3HeadTemporaryList = this.AddToGraph(this.he3HeadTemporaryList, this.He3HeadLineSeries, value);
                this.he3HeadTemporaryListBottom = this.AddToGraph(this.he3HeadTemporaryListBottom, this.He3HeadLineSeriesBottom, Math.Log(value, 10));
            }
        }

        /// <summary>
        /// Gets or sets the he3 head maximum.
        /// </summary>
        /// <value>
        /// The he3 head maximum.
        /// </value>
        public double He3HeadMax { get; set; }

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
                this.he3PumpTemporaryList = this.AddToGraph(this.he3PumpTemporaryList, this.He3PumpLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 3 pump actual volt.
        /// </summary>
        /// <value>
        /// The he3 pump actual volt.
        /// </value>
        public double He3PumpActualVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 3 pump new volt.
        /// </summary>
        /// <value>
        /// The he3 pump new volt.
        /// </value>
        public double He3PumpNewVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 3 pump max.
        /// </summary>
        /// <value>
        /// The he3 pump maximum.
        /// </value>
        public double He3PumpMax { get; set; }

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
                this.he3SwitchTemporaryList = this.AddToGraph(this.he3SwitchTemporaryList, this.He3SwitchLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 3 switch actual volt.
        /// </summary>
        /// <value>
        /// The he3 switch actual volt.
        /// </value>
        public double He3SwitchActualVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 3 switch new volt.
        /// </summary>
        /// <value>
        /// The he3 switch new volt.
        /// </value>
        public double He3SwitchNewVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 3 switch max 1.
        /// </summary>
        /// <value>
        /// The he3 switch max1.
        /// </value>
        public double He3SwitchMax1 { get; set; }

        /// <summary>
        /// Gets or sets the he 3 switch max 2.
        /// </summary>
        /// <value>
        /// The he3 switch max2.
        /// </value>
        public double He3SwitchMax2 { get; set; }

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
                this.he4HeadTemporaryList = this.AddToGraph(this.he4HeadTemporaryList, this.He4HeadLineSeries, value);
                this.he4HeadTemporaryListBottom = this.AddToGraph(this.he4HeadTemporaryListBottom, this.He4HeadLineSeriesBottom, Math.Log(value, 10));
            }
        }

        /// <summary>
        /// Gets or sets the he 4 head max.
        /// </summary>
        /// <value>
        /// The he4 head maximum.
        /// </value>
        public double He4HeadMax { get; set; }

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
                this.he4PumpTemporaryList = this.AddToGraph(this.he4PumpTemporaryList, this.He4PumpLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 4 pump actual volt.
        /// </summary>
        /// <value>
        /// The he4 pump actual volt.
        /// </value>
        public double He4PumpActualVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 4 pump new volt.
        /// </summary>
        /// <value>
        /// The he4 pump new volt.
        /// </value>
        public double He4PumpNewVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 4 pump max.
        /// </summary>
        /// <value>
        /// The he4 pump maximum.
        /// </value>
        public double He4PumpMax { get; set; }

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
                this.he4SwitchTemporaryList = this.AddToGraph(this.he4SwitchTemporaryList, this.He4SwitchLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the he 4 switch actual volt.
        /// </summary>
        /// <value>
        /// The he4 switch actual volt.
        /// </value>
        public double He4SwitchActualVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 4 switch new volt.
        /// </summary>
        /// <value>
        /// The he4 switch new volt.
        /// </value>
        public double He4SwitchNewVolt { get; set; }

        /// <summary>
        /// Gets or sets the he 4 switch max 1.
        /// </summary>
        /// <value>
        /// The he4 switch max1.
        /// </value>
        public double He4SwitchMax1 { get; set; }

        /// <summary>
        /// Gets or sets the he 4 switch max 2.
        /// </summary>
        /// <value>
        /// The he4 switch max2.
        /// </value>
        public double He4SwitchMax2 { get; set; }

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
                this.twoKPlateTemporaryList = this.AddToGraph(this.twoKPlateTemporaryList, this.TwoKPlateLineSeries, value);
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        /// <value>
        /// The state of the connection.
        /// </value>
        public double ConnectionState { get; set; }

        #endregion Properties
    }
}