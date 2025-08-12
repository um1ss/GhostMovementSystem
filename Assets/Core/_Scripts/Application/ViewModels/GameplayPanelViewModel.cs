using DenisKim.Core.Domain;
using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Domain.Services;
using R3;

namespace DenisKim.Core.Application.ViewModels
{
    public sealed class GameplayPanelViewModel : BaseDisposable
    {
        readonly ILevelContext _levelContext;

        public ReadOnlyReactiveProperty<string> Level { get; }

        public ReactiveCommand<Unit> OnStartLevel { get; }

        public GameplayPanelViewModel(ILevelContext levelContext)
        {
            _levelContext = levelContext;

            OnStartLevel = new();

            Level = _levelContext.Level.Select(value => value.GetType().Name.ToString())
                .ToReadOnlyReactiveProperty().AddTo(_compositeDisposable);

            OnStartLevel.Subscribe(async _ => await _levelContext.StartLevel())
                .AddTo(_compositeDisposable);
        }
    }
}
