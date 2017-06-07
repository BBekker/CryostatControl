// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PasswordValidator.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the PasswordValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.IdentityModel.Selectors;
    using System.ServiceModel;

    using Properties;

    /// <summary>
    /// The password validator.
    /// </summary>
    public class PasswordValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// The user name.
        /// </summary>
        private string userName = "cooler";

        /// <summary>
        /// Validate the username and password against the password token
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown when an argument is null
        /// </exception>
        /// <exception cref="FaultException">
        /// Thrown when the username and password are invalid
        /// </exception>
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == this.userName && password  == Settings.Default.PasswordToken))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
