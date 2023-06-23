namespace Aquarius.TimeSeries.Client
{
    public interface IConnection
    {
        string Token();
        void ReAuthenticate();
        void Close();
        void IncrementConnectionCount();
    }
}