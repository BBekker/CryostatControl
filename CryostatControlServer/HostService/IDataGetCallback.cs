namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    public interface IDataGetCallback
    {
        #region Methods

        [OperationContract(IsOneWay = true)]
        void SendBlueForsData(float[] data);

        [OperationContract(IsOneWay = true)]
        void SendCompressorData(float[] data);

        [OperationContract(IsOneWay = true)]
        void SendHelium7Data(float[] data);

        #endregion Methods
    }
}