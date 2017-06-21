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

    /// <summary>
    /// The abstract model
    /// </summary>
    public abstract class AbstractModel
    {
        #region Fields

        /// <summary>
        /// The amount of data averaged in 1 point
        /// </summary>
        private const int DataPerPoint = 30;

        /// <summary>
        /// The maximum amount of chart values
        /// </summary>
        private const int MaxChartValues = 3000;

        #endregion Fields

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
                return DataPerPoint + 1;
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
            if (!double.IsNaN(value))
            {
                temporaryList[(int)temporaryList[DataPerPoint]] = value;
                temporaryList[DataPerPoint]++;
                if (lineSeries.Values.Count < 1)
                {
                    lineSeries.Values.Add(new DateTimePoint(DateTime.Now, Math.Round(value, 3)));

                    temporaryList = new double[this.TemporaryListSize];

                    temporaryList[DataPerPoint] = 0;
                }
                else if (temporaryList[DataPerPoint] > this.TemporaryListSize - 2)
                {
                    lineSeries.Values.Add(new DateTimePoint(DateTime.Now, Math.Round(temporaryList.Average() - 1, 3)));
                    if (lineSeries.Values.Count > MaxChartValues)
                    {
                        lineSeries.Values.RemoveAt(0);
                    }

                    temporaryList = new double[this.TemporaryListSize];
                    temporaryList[this.TemporaryListSize - 1] = 0;
                }
            }

            return temporaryList;
        }

        #endregion Methods
    }
}
