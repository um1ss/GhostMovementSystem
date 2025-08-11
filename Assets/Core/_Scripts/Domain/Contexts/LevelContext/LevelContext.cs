using DenisKim.Core.Infrastructure.States;
using R3;
using UnityEngine;

namespace DenisKim.Core.Domain.Contexts
{
    public sealed class LevelContext : BaseDisposable, ILevelContext
    {
        readonly ReactiveProperty<ILevelState> _levelState;
        public ReadOnlyReactiveProperty<ILevelState> Level { get; }

        public LevelContext()
        {
            _levelState = new ReactiveProperty<ILevelState>();

            Level = _levelState.ToReadOnlyReactiveProperty()
                .AddTo(_compositeDisposable);
        }

        public void TransitionTo(ILevelState state)
        {
            _levelState.Value = state;
            _levelState.Value.SetContext(this);
            Debug.Log($"Context: Transition to {_levelState.Value.GetType().Name}.");
        }
    }
}
