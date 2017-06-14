namespace CryostatControlServer.HostService
{
    public class TimerPackage
    {

        public TimerPackage(string key, IDataGetCallback callback, int waitTime)
        {
            this.Key = key;
            this.Callback = callback;
            this.WaitTime = waitTime;
        }

        public string Key { get; set; }

        public IDataGetCallback Callback { get; set; }

        public int WaitTime { get; set; }
    }
}