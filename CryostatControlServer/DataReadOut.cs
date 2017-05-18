namespace CryostatControlServer
{
    using System;
    using CryostatControlServer.HostService.Enumerators;

    public class DataReadOut
    {
        #region Fields

        private ISensor[] sensors;
        private Compressor.Compressor compressor;

        #endregion Fields

        #region Methods

        public DataReadOut(
            Compressor.Compressor compressor,
            ISensor[] sensors)
        {
            this.compressor = compressor;
            this.sensors = sensors;
        }

        public double[] fillData()
        {
            double[] data = new double[(int)DataEnumerator.DataLenght];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = double.MinValue;
            }
            ////this.FillDataWithSensor(data);
            ////this.FillCompressorData(data);
            this.FillWithMockData(data);
            return data;
        }

        private void FillDataWithSensor(double[] data)
        {
            for (int i = 0; i < (int)DataEnumerator.SensorAmount; i++)
            {
                data[i] = this.sensors[i].Value;
            }
        }

        private void FillCompressorData(double[] data)
        {
            try
            {
                data[(int)DataEnumerator.ComError] = (double)this.compressor.ReadErrorState();
                data[(int)DataEnumerator.ComWarning] = (double)this.compressor.ReadWarningState();
                data[(int)DataEnumerator.ComHoursOfOperation] = (double)this.compressor.ReadHoursOfOperation();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the compressor");

                //todo handle exception
            }
        }

        private void FillWithMockData(double[] data)
        {
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = random.NextDouble();
            }
        }

        #endregion Methods
    }
}