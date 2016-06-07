using System;

namespace Aquarius.Client
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
            if (_actionOnDispose != null)
            {
                _actionOnDispose();
            }
        }
    }
}
