using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Domain.Services;
using DenisKim.Core.Infrastructure.States;
using DenisKim.Core.Infrastructure.Strategys;
using DenisKim.Core.LifetimeScopes.Panels;
using System.Threading;
using VContainer.Unity;

namespace DenisKim.Core.LifetimeScopes.Scene
{
    public class GameplaySceneEntryPoint : IAsyncStartable
    {
        readonly ILevelState _singleLevel;
        readonly ILevelState _ghostLevel;

        readonly ILevelContext _levelContext;

        readonly IShowPanelStrategy _showPanelStrategy;

        readonly IPanelService _panelService;

        public GameplaySceneEntryPoint(ILevelContext levelContext,
            SingleLevel singleLevel,
            GhostLevel ghostLevel,
            IPanelService panelService,
            ShowPersistentPanelStrategy showPersistentPanelStrategy)
        {
            _showPanelStrategy = showPersistentPanelStrategy;
            _panelService = panelService;
            _singleLevel = singleLevel;
            _ghostLevel = ghostLevel;
            _levelContext = levelContext;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            _levelContext.TransitionTo(_ghostLevel);
            await _panelService.ShowPanel(_showPanelStrategy,
                PanelType.Gameplay, "GameplayPanel", new GameplayPanelLifetmeScope());
        }
    }
}
