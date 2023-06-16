using Aquarius.Helpers;
using Aquarius.TimeSeries.Client.EndPoints;
using Aquarius.TimeSeries.Client.Helpers;
using ServiceStack;

namespace Aquarius.TimeSeries.Client
{
    public class AccessTokenAuthenticator : IAuthenticator
    {
        internal IServiceClient Client { get; set; }

        public static IAuthenticator Create(string hostname)
        {
            return new AccessTokenAuthenticator(hostname);
        }

        private AccessTokenAuthenticator(string hostname)
        {
            Client = new SdkServiceClient(PublishV2.ResolveEndpoint(hostname));
        }
        
        public string Login(string username, string password)
        {
            throw new System.NotImplementedException("Access token authenticator does not use credentials-based login.");
        }

        public void Login(string accessToken)
        {
            ClientHelper.Login(Client, accessToken);
        }

        public void Logout()
        {
            ClientHelper.Logout(Client);
        }
    }
}