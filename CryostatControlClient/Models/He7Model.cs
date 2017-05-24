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

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Geared;
    using LiveCharts.Wpf;

    /// <summary>
    /// Model for the He7-cooler.
    /// </summary>
    public class He7Model : AbstractModel
    {
        #region Fields

        /// <summary>
        /// The two k plate line series
        /// </summary>
        private GLineSeries twoKPlateLineSeriesBottom;

        /// <summary>
        /// The four k plate line series
        /// </summary>
        private GLineSeries fourKPlateLineSeriesBottom;

        /// <summary>
        /// The he3 head line series
        /// </summary>
        private GLineSeries he3HeadLineSeriesBottom;

        /// <summary>
        /// The he3 pump line series
        /// </summary>
        private GLineSeries he3PumpLineSeriesBottom;

        /// <summary>
        /// The he3 switch line series
        /// </summary>
        private GLineSeries he3SwitchLineSeriesBottom;

        /// <summary>
        /// The he4 head line series
        /// </summary>
        private GLineSeries he4HeadLineSeriesBottom;

        /// <summary>
        /// The he4 pump line series
        /// </summary>
        private GLineSeries he4PumpLineSeriesBottom;

        /// <summary>
        /// The he4 switch line series
        /// </summary>
        private GLineSeries he4SwitchLineSeriesBottom;

        /// <summary>
        /// The two k plate line series
        /// </summary>
        private GLineSeries twoKPlateLineSeries;

        /// <summary>
        /// The four k plate line series
        /// </summary>
        private GLineSeries fourKPlateLineSeries;

        /// <summary>
        /// The he3 head line series
        /// </summary>
        private GLineSeries he3HeadLineSeries;

        /// <summary>
        /// The he3 pump line series
        /// </summary>
        private GLineSeries he3PumpLineSeries;

        /// <summary>
        /// The he3 switch line series
        /// </summary>
        private GLineSeries he3SwitchLineSeries;

        /// <summary>
        /// The he4 head line series
        /// </summary>
        private GLineSeries he4HeadLineSeries;

        /// <summary>
        /// The he4 pump line series
        /// </summary>
        private GLineSeries he4PumpLineSeries;

        /// <summary>
        /// The he4 switch line series
        /// </summary>
        private GLineSeries he4SwitchLineSeries;

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
            this.twoKPlateLineSeries = new GLineSeries { Title = "He7 - 2K Plate", Values = new GearedValues<DateTimePoint>() };
            this.fourKPlateLineSeries = new GLineSeries { Title = "He7 - 4K Plate", Values = new GearedValues<DateTimePoint>() };

            this.he3HeadLineSeries = new GLineSeries { Title = "He7 - He3 Head", Values = new GearedValues<DateTimePoint>() };
            this.he3PumpLineSeries = new GLineSeries { Title = "He7 - He3 Pump", Values = new GearedValues<DateTimePoint>() };
            this.he3SwitchLineSeries = new GLineSeries { Title = "He7 - He3 Switch", Values = new GearedValues<DateTimePoint>() };

            this.he4HeadLineSeries = new GLineSeries { Title = "He7 - He4 Head", Values = new GearedValues<DateTimePoint>() };
            this.he4PumpLineSeries = new GLineSeries { Title = "He7 - He4 Pump", Values = new GearedValues<DateTimePoint>() };
            this.he4SwitchLineSeries = new GLineSeries { Title = "He7 - He4 Switch", Values = new GearedValues<DateTimePoint>() };

            this.twoKPlateLineSeriesBottom = new GLineSeries { Title = "He7 - 2K Plate", Values = new GearedValues<DateTimePoint>() };
            this.fourKPlateLineSeriesBottom = new GLineSeries { Title = "He7 - 4K Plate", Values = new GearedValues<DateTimePoint>() };

            this.he3HeadLineSeriesBottom = new GLineSeries { Title = "He7 - He3 Head", Values = new GearedValues<DateTimePoint>() };
            this.he3PumpLineSeriesBottom = new GLineSeries { Title = "He7 - He3 Pump", Values = new GearedValues<DateTimePoint>() };
            this.he3SwitchLineSeriesBottom = new GLineSeries { Title = "He7 - He3 Switch", Values = new GearedValues<DateTimePoint>() };

            this.he4HeadLineSeriesBottom = new GLineSeries { Title = "He7 - He4 Head", Values = new GearedValues<DateTimePoint>() };
            this.he4PumpLineSeriesBottom = new GLineSeries { Title = "He7 - He4 Pump", Values = new GearedValues<DateTimePoint>() };
            this.he4SwitchLineSeriesBottom = new GLineSeries { Title = "He7 - He4 Switch", Values = new GearedValues<DateTimePoint>() };
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the he4 switch line series.
        /// </summary>
        /// <value>
        /// The he4 switch line series.
        /// </value>
        public GLineSeries He4SwitchLineSeriesBottom
        {
            get
            {
                return this.he4SwitchLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he4 pump line series.
        /// </summary>
        /// <value>
        /// The he4 pump line series.
        /// </value>
        public GLineSeries He4PumpLineSeriesBottom
        {
            get
            {
                return this.he4PumpLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he4 head line series.
        /// </summary>
        /// <value>
        /// The he4 head line series.
        /// </value>
        public GLineSeries He4HeadLineSeriesBottom
        {
            get
            {
                return this.he4HeadLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he3 switch line series.
        /// </summary>
        /// <value>
        /// The he3 switch line series.
        /// </value>
        public GLineSeries He3SwitchLineSeriesBottom
        {
            get
            {
                return this.he3SwitchLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he3 pump line series.
        /// </summary>
        /// <value>
        /// The he3 pump line series.
        /// </value>
        public GLineSeries He3PumpLineSeriesBottom
        {
            get
            {
                return this.he3PumpLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he3 head line series.
        /// </summary>
        /// <value>
        /// The he3 head line series.
        /// </value>
        public GLineSeries He3HeadLineSeriesBottom
        {
            get
            {
                return this.he3HeadLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the two k plat line series.
        /// </summary>
        /// <value>
        /// The two k plat line series.
        /// </value>
        public GLineSeries TwoKPlateLineSeriesBottom
        {
            get
            {
                return this.twoKPlateLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the four k plate line series.
        /// </summary>
        /// <value>
        /// The four k plate line series.
        /// </value>
        public GLineSeries FourKPlateLineSeriesBottom
        {
            get
            {
                return this.fourKPlateLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the he4 switch line series.
        /// </summary>
        /// <value>
        /// The he4 switch line series.
        /// </value>
        public GLineSeries He4SwitchLineSeries
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
        public GLineSeries He4PumpLineSeries
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
        public GLineSeries He4HeadLineSeries
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
        public GLineSeries He3SwitchLineSeries
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
        public GLineSeries He3PumpLineSeries
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
        public GLineSeries He3HeadLineSeries
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
        public GLineSeries TwoKPlateLineSeries
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
        public GLineSeries FourKPlateLineSeries
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
                this.AddToGraph(this.fourKPlateLineSeries, value);
                this.AddToGraph(this.fourKPlateLineSeriesBottom, value);
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
                this.AddToGraph(this.he3HeadLineSeries, value);
                this.AddToGraph(this.he3HeadLineSeriesBottom, value);
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
                this.AddToGraph(this.he3PumpLineSeries, value);
                this.AddToGraph(this.he3PumpLineSeriesBottom, value);
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
                this.AddToGraph(this.he3SwitchLineSeries, value);
                this.AddToGraph(this.he3SwitchLineSeriesBottom, value);
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
                this.AddToGraph(this.he4HeadLineSeries, value);
                this.AddToGraph(this.he4HeadLineSeriesBottom, value);
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
                this.AddToGraph(this.he4PumpLineSeries, value);
                this.AddToGraph(this.he4PumpLineSeriesBottom, value);
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
                this.AddToGraph(this.he4SwitchLineSeries, value);
                this.AddToGraph(this.he4SwitchLineSeriesBottom, value);
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
                this.AddToGraph(this.twoKPlateLineSeries, value);
                this.AddToGraph(this.twoKPlateLineSeriesBottom, value);
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