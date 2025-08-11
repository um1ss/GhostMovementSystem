using R3;
using System;

namespace DenisKim.Core.Domain
{
    public abstract class BaseDisposable : IDisposable
    {
        protected readonly CompositeDisposable _compositeDisposable;

        protected BaseDisposable()
        {
            _compositeDisposable = new();
        }

        public virtual void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
