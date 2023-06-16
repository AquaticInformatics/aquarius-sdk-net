namespace Aquarius.TimeSeries.Client
{
    public interface IAuthenticator
    {
        string Login(string username, string password);
        void Login(string accessToken);
        void Logout();
    }
}
