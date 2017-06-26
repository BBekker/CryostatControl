//-----------------------------------------------------------------------
// <copyright file="ChartModel.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;
    using System.Windows.Input;

    using LiveCharts;
    using LiveCharts.Wpf;

    /// <summary>
    /// The chart model
    /// </summary>
    /// <seealso cref="CryostatControlClient.Models.AbstractModel" />
    public class ChartModel : AbstractModel
    {
        #region Fields

        /// <summary>
        /// The room temperature
        /// </summary>
        private const int RoomTemperature = 300;

        /// <summary>
        /// The coldest temperature
        /// </summary>
        private const int ColdestTemperature = 0;

        /// <summary>
        /// The x axis
        /// </summary>
        private Axis xAxis;

        /// <summary>
        /// The y axis
        /// </summary>
        private Axis yAxis;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartModel"/> class.
        /// </summary>
        public ChartModel()
        {
            this.ZoomingMode = ZoomingOptions.X;

            this.xAxis = new Axis();
            this.xAxis.Title = "Time";
            this.XAxisCollection = new AxesCollection();
            this.XAxisCollection.Add(this.xAxis);

            this.yAxis = new Axis();
            this.yAxis.Title = "Kelvin";
            this.YAxisCollection = new AxesCollection();
            this.YAxisCollection.Add(this.yAxis);

            this.xAxis.LabelFormatter = val => this.GetDateTime(val).ToString("HH:mm");
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the x axis maximum.
        /// </summary>
        /// <value>
        /// The x axis maximum.
        /// </value>
        public DateTime XMax
        {
            get
            {
                return this.GetDateTime(this.xAxis.MaxValue);
            }

            set
            {
                if (value == DateTime.Now)
                {
                    this.xAxis.MaxValue = double.NaN;
                }
                else
                {
                    this.xAxis.MaxValue = value.Ticks;
                }
            }
        }

        /// <summary>
        /// Gets or sets the x axis minimum.
        /// </summary>
        /// <value>
        /// The x axis minimum.
        /// </value>
        public DateTime XMin
        {
            get
            {
                return this.GetDateTime(this.xAxis.MinValue);
            }

            set
            {
                if (value == DateTime.Now)
                {
                    this.xAxis.MinValue = double.NaN;
                }
                else
                {
                    this.xAxis.MinValue = value.Ticks;
                }
            }
        }

        /// <summary>
        /// Gets or sets the y axis maximum.
        /// </summary>
        /// <value>
        /// The y axis maximum.
        /// </value>
        public double YMax
        {
            get
            {
                double temp = this.yAxis.MaxValue;
                if (double.IsNaN(temp))
                {
                    return RoomTemperature;
                }
                else
                {
                    return temp;
                }
            }

            set
            {
                this.yAxis.MaxValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the y axis maximum.
        /// </summary>
        /// <value>
        /// The y axis maximum.
        /// </value>
        public double YMin
        {
            get
            {
                double temp = this.yAxis.MinValue;
                if (double.IsNaN(temp))
                {
                    return ColdestTemperature;
                }
                else
                {
                    return temp;
                }
            }

            set
            {
                this.yAxis.MinValue = value;
            }
        }

        /// <summary>
        /// Gets the x axis collection.
        /// </summary>
        /// <value>
        /// The x axis collection.
        /// </value>
        public AxesCollection XAxisCollection { get; }

        /// <summary>
        /// Gets the y axis collection.
        /// </summary>
        /// <value>
        /// The y axis collection.
        /// </value>
        public AxesCollection YAxisCollection { get; }

        /// <summary>
        /// Gets or sets the zooming mode.
        /// </summary>
        /// <value>
        /// The zooming mode.
        /// </value>
        public ZoomingOptions ZoomingMode { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>Time in hours and minutes.</returns>
        public DateTime GetDateTime(double val)
        {
            try
            {
                return new DateTime((long)val);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                return DateTime.Now;
            }
        }

        #endregion Methods
    }
}