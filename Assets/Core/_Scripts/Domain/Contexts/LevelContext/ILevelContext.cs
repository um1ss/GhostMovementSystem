using DenisKim.Core.Infrastructure.States;
using R3;

namespace DenisKim.Core.Domain.Contexts
{
    public interface ILevelContext
    {
        ReadOnlyReactiveProperty<ILevelState> Level { get; }
        void TransitionTo(ILevelState state);
    }
}
