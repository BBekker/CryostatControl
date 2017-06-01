namespace CryostatControlServer.HostService
{
    using System;
    using System.IdentityModel.Selectors;
    using System.ServiceModel;

    class PasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            try
            {
                if (userName == "test" && password == "test123")
                {
                    Console.WriteLine("Authentic User");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong inside the authentication {0}", ex.Message);
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
