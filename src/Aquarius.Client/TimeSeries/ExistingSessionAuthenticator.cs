using System;
using Aquarius.TimeSeries.Client;

namespace Aquarius.TimeSeries
{
    public class ExistingSessionAuthenticator : IAuthenticator
    {
        private string SessionToken { get; }

        public static IAuthenticator Create(string existingSessionToken)
        {
            return new ExistingSessionAuthenticator(existingSessionToken);
        }

        private ExistingSessionAuthenticator(string existingSessionToken)
        {
            SessionToken = existingSessionToken;
        }

        public string Login(string username, string password)
        {
            return SessionToken;
        }

        public void Login(string accessToken)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
        }
    }
}
