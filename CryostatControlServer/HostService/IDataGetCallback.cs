namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    public interface IDataGetCallback
    {
        #region Methods

        [OperationContract(IsOneWay = true)]
        void SendData(float[] data);

        #endregion Methods
    }
}