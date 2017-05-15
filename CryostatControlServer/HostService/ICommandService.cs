namespace CryostatControlServer.HostService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICommandService
    {
        #region Methods

        [OperationContract]
        string SayHello(string name);

        #endregion Methods
    }
}