namespace CryostatControlServer.HostService
{
    public class TimerPackage
    {

        public TimerPackage(string ipAddress, IDataGetCallback callback)
        {
            this.IpAddress = ipAddress;
            this.Callback = callback;
        }

        public string IpAddress { get; set; }

        public IDataGetCallback Callback { get; set; }
    }
}