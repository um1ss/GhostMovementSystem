using R3;
using UnityEngine;

namespace DenisKim.Core.Presentantion
{
    public abstract class BaseDisposableMB : MonoBehaviour
    {
        protected CompositeDisposable _compositeDisposable;

        protected virtual void Awake()
        {
            _compositeDisposable = new();
        }

        protected virtual void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }
    }
}
