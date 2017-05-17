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
    /// <summary>
    /// Model for the He7-cooler.
    /// </summary>
    /// <seealso cref="CryostatControlClient.Models.AbstractModel" />
    public class He7Model
    {
        #region Fields

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

        #region Properties

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