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
    public class He7Model : AbstractModel
    {
        /// <summary>
        /// The four k plate temporary
        /// </summary>
        private int fourKPlateTemp;

        /// <summary>
        /// The he3 head temporary
        /// </summary>
        private int he3HeadTemp;

        /// <summary>
        /// The he3 pump temporary
        /// </summary>
        private int he3PumpTemp;

        /// <summary>
        /// The he3 pump volt
        /// </summary>
        private int he3PumpVolt;

        /// <summary>
        /// The he3 switch temporary
        /// </summary>
        private int he3SwitchTemp;

        /// <summary>
        /// The he3 switch volt
        /// </summary>
        private int he3SwitchVolt;

        /// <summary>
        /// The he4 head temporary
        /// </summary>
        private int he4HeadTemp;

        /// <summary>
        /// The he4 pump temporary
        /// </summary>
        private int he4PumpTemp;

        /// <summary>
        /// The he4 pump volt
        /// </summary>
        private int he4PumpVolt;

        /// <summary>
        /// The he4 switch temporary
        /// </summary>
        private int he4SwitchTemp;

        /// <summary>
        /// The he4 switch volt
        /// </summary>
        private int he4SwitchVolt;

        /// <summary>
        /// The two k plate temporary
        /// </summary>
        private int twoKPlateTemp;

        /// <summary>
        /// Gets or sets the four k plate temporary.
        /// </summary>
        /// <value>
        /// The four k plate temporary.
        /// </value>
        public int FourKPlateTemp
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
        /// Gets or sets the he3 head temporary.
        /// </summary>
        /// <value>
        /// The he3 head temporary.
        /// </value>
        public int He3HeadTemp
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
        /// Gets or sets the he3 pump temporary.
        /// </summary>
        /// <value>
        /// The he3 pump temporary.
        /// </value>
        public int He3PumpTemp
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
        /// Gets or sets the he3 pump volt.
        /// </summary>
        /// <value>
        /// The he3 pump volt.
        /// </value>
        public int He3PumpVolt
        {
            get
            {
                return this.he3PumpVolt;
            }

            set
            {
                this.he3PumpVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch temporary.
        /// </summary>
        /// <value>
        /// The he3 switch temporary.
        /// </value>
        public int He3SwitchTemp
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
        /// Gets or sets the he3 switch volt.
        /// </summary>
        /// <value>
        /// The he3 switch volt.
        /// </value>
        public int He3SwitchVolt
        {
            get
            {
                return this.he3SwitchVolt;
            }

            set
            {
                this.he3SwitchVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he4 head temporary.
        /// </summary>
        /// <value>
        /// The he4 head temporary.
        /// </value>
        public int He4HeadTemp
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
        /// Gets or sets the he4 pump temporary.
        /// </summary>
        /// <value>
        /// The he4 pump temporary.
        /// </value>
        public int He4PumpTemp
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
        /// Gets or sets the he4 pump volt.
        /// </summary>
        /// <value>
        /// The he4 pump volt.
        /// </value>
        public int He4PumpVolt
        {
            get
            {
                return this.he4PumpVolt;
            }

            set
            {
                this.he4PumpVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch temporary.
        /// </summary>
        /// <value>
        /// The he4 switch temporary.
        /// </value>
        public int He4SwitchTemp
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
        /// Gets or sets the he4 switch volt.
        /// </summary>
        /// <value>
        /// The he4 switch volt.
        /// </value>
        public int He4SwitchVolt
        {
            get
            {
                return this.he4SwitchVolt;
            }

            set
            {
                this.he4SwitchVolt = value;
            }
        }

        /// <summary>
        /// Gets or sets the two k plate temporary.
        /// </summary>
        /// <value>
        /// The two k plate temporary.
        /// </value>
        public int TwoKPlateTemp
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
    }
}