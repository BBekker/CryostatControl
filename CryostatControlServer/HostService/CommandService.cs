namespace CryostatControlServer.HostService
{
    using System;

    public class CommandService : ICommandService
    {
        #region Methods

        public string SayHello(string name)
        {
            Console.WriteLine("hello called");
            return "hello " + name;
        }

        #endregion Methods
    }
}