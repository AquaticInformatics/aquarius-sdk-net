using System;

namespace Aquarius.TimeSeries.Client
{
    public class ScopeAction : IDisposable
    {
        private readonly Action _actionOnDispose;

        public ScopeAction(Action actionOnDispose)
        {
            _actionOnDispose = actionOnDispose;
        }

        public void Dispose()
        {
            _actionOnDispose?.Invoke();
        }
    }
}
