//-----------------------------------------------------------------------
// <copyright file="AbstractModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;
    using System.Linq;

    using LiveCharts.Defaults;
    using LiveCharts.Geared;
    using LiveCharts.Wpf;

    /// <summary>
    /// The abstract model
    /// </summary>
    public abstract class AbstractModel
    {
        #region Fields

        /// <summary>
        /// The size of the temporary lists. If these lists are full a new point is added to the graph. The bigger this number the less frequent a point gets added to the graph.
        /// </summary>
        private int temporaryListSize;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractModel"/> class.
        /// </summary>
        protected AbstractModel()
        {
            this.temporaryListSize = 31;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the update interval.
        /// </summary>
        /// <value>
        /// The update interval.
        /// </value>
        protected int TemporaryListSize
        {
            get
            {
                return this.temporaryListSize;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds to graph.
        /// </summary>
        /// <param name="temporaryList">The temporary list.</param>
        /// <param name="lineSeries">The line series.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The temporary list updated.
        /// </returns>
        public double[] AddToGraph(double[] temporaryList, GLineSeries lineSeries, double value)
        {
            temporaryList[(int)temporaryList[this.temporaryListSize - 1]] = value;

            temporaryList[this.temporaryListSize - 1]++;

            if (lineSeries.Values.Count < 1)
            {
                lineSeries.Values.Add(new DateTimePoint(DateTime.Now, Math.Round(value, 3)));
            }

            if (temporaryList[this.temporaryListSize - 1] >= this.temporaryListSize - 2)
            {
                lineSeries.Values.Add(new DateTimePoint(DateTime.Now, Math.Round(temporaryList.Average() - 1, 3)));
                if (lineSeries.Values.Count > 3000)
                {
                    lineSeries.Values.RemoveAt(0);
                }

                temporaryList = new double[this.temporaryListSize];

                temporaryList[this.temporaryListSize - 1] = 0;
            }

            return temporaryList;
        }

        #endregion Methods
    }
}
