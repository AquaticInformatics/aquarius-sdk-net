namespace Aquarius.Helpers
{
    public interface IProgressReporter
    {
        void Started();
        void Progress(int currentCount, int totalCount);
        void Completed();
    }
}
