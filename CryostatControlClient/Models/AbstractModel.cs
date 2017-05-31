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
    using LiveCharts.Wpf;

    /// <summary>
    /// The abstract model
    /// </summary>
    public abstract class AbstractModel
    {
        /// <summary>
        /// The size of the temporary lists. If these lists are full a new point is added to the graph. The bigger this number the less frequent a point gets added to the graph.
        /// </summary>
        protected int UpdateInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractModel"/> class.
        /// </summary>
        protected AbstractModel()
        {
            this.UpdateInterval = 31;
        }

        /// <summary>
        /// Adds to graph.
        /// </summary>
        /// <param name="temporaryList">The temporary list.</param>
        /// <param name="lineSeries">The line series.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The temporary list updated.
        /// </returns>
        public double[] AddToGraph(double[] temporaryList, LineSeries lineSeries, double value)
        {
            temporaryList[(int)temporaryList[this.UpdateInterval - 1]] = value;

            temporaryList[this.UpdateInterval - 1]++;

            if (temporaryList[this.UpdateInterval - 1] >= (this.UpdateInterval - 2))
            {
                lineSeries.Values.Add(new DateTimePoint(DateTime.Now, temporaryList.Average() - 1));
                if (lineSeries.Values.Count > 100)
                {
                    lineSeries.Values.RemoveAt(0);
                }

                temporaryList = new double[this.UpdateInterval];

                temporaryList[this.UpdateInterval - 1] = 0;
            }

            return temporaryList;
        }
    }
}
