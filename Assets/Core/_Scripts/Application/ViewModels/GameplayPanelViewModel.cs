using DenisKim.Core.Domain;
using DenisKim.Core.Domain.Contexts;
using R3;

namespace DenisKim.Core.Application.ViewModels
{
    public sealed class GameplayPanelViewModel : BaseDisposable
    {
        readonly ILevelContext _levelContext;

        public ReadOnlyReactiveProperty<string> Level;

        public GameplayPanelViewModel(ILevelContext levelContext)
        {
            _levelContext = levelContext;

            Level = _levelContext.Level.Select(value => value.GetType().Name.ToString())
                .ToReadOnlyReactiveProperty().AddTo(_compositeDisposable);
        }
    }
}
