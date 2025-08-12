using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure.States;
using R3;

namespace DenisKim.Core.Domain.Contexts
{
    public interface ILevelContext
    {
        ReadOnlyReactiveProperty<ILevelState> Level { get; }
        void TransitionTo(ILevelState state);

        UniTask StartLevel();

        UniTask StopLevel();
    }
}
