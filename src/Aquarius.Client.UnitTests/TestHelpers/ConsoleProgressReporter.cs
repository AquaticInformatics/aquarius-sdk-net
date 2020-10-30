using System;
using Aquarius.Helpers;

namespace Aquarius.Client.UnitTests.TestHelpers
{
    public class ConsoleProgressReporter : IProgressReporter
    {
        private void WriteLine(string message)
        {
            Console.WriteLine($"PROGRESS: {message}");
        }

        public void Started()
        {
            WriteLine("Started.");
        }

        public void Progress(int currentCount, int totalCount)
        {
            WriteLine($"{currentCount} of {totalCount}");
        }

        public void Completed()
        {
            WriteLine("Completed.");
        }
    }
}
