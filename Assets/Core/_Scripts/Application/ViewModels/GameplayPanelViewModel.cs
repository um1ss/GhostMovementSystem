using DenisKim.Core.Domain;
using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Infrastructure.States;
using R3;

namespace DenisKim.Core.Application.ViewModels
{
    public sealed class GameplayPanelViewModel : BaseDisposable
    {
        readonly ILevelContext _levelContext;
        readonly ILevelState _singleLevel;
        readonly ILevelState _ghostLevel;

        public ReadOnlyReactiveProperty<string> Level { get; }

        public ReactiveCommand<Unit> OnStartLevel { get; }
        public ReactiveCommand<Unit> OnSetSingleLevel { get; }
        public ReactiveCommand<Unit> OnSetGhostLevel { get; }

        public GameplayPanelViewModel(ILevelContext levelContext,
            SingleLevel singleLevel,
            GhostLevel ghostLevel)
        {
            _levelContext = levelContext;
            _singleLevel = singleLevel;
            _ghostLevel = ghostLevel;

            OnStartLevel = new();
            OnSetSingleLevel = new();
            OnSetGhostLevel = new();

            Level = _levelContext.Level.Select(value => value.GetType().Name.ToString())
                .ToReadOnlyReactiveProperty().AddTo(_compositeDisposable);

            OnStartLevel.Subscribe(async _ => await _levelContext.StartLevel())
                .AddTo(_compositeDisposable);

            OnSetSingleLevel.Subscribe(_ => _levelContext.TransitionTo(_singleLevel))
                .AddTo(_compositeDisposable);

            OnSetGhostLevel.Subscribe(_ => _levelContext.TransitionTo(_ghostLevel))
                .AddTo(_compositeDisposable);
        }
    }
}
