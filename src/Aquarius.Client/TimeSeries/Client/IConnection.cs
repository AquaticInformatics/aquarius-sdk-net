namespace Aquarius.TimeSeries.Client
{
    public interface IConnection
    {
        string Token();
        void ReAuthenticate();
        void ReAuthenticate(string token);
        void Close();
        void IncrementConnectionCount();
    }
}
