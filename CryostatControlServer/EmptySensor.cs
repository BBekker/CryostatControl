namespace CryostatControlServer
{
    public class EmptySensor : ISensor
    {
        #region Properties

        public int Interval
        {
            get
            {
                return int.MinValue;
            }

            set
            {
                //do nothing
            }
        }

        public double Value
        {
            get
            {
                return double.MinValue;
            }
        }

        #endregion Properties
    }
}