namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IDataGetCallback))]
    public interface IDataGet
    {
        #region Methods

        [OperationContract(IsOneWay = true)]
        void SubscribeForData(int interval);

        #endregion Methods
    }
}