using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Services;
using DenisKim.Core.Infrastructure.States;
using DenisKim.Core.Infrastructure.Strategys;
using DenisKim.Core.LifetimeScopes.Panels;
using R3;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Domain.Contexts
{
    public sealed class LevelContext : BaseDisposable, ILevelContext
    {
        readonly LifetimeScope _parentLifetimeScope;
        readonly IPanelService _panelService;
        readonly IShowPanelStrategy _showPersistentPanelStrategy;

        readonly ReactiveProperty<ILevelState> _levelState;
        public ReadOnlyReactiveProperty<ILevelState> Level { get; }

        AsyncOperationHandle<GameObject> _handleEnviroment;
        GameObject _prefabEnviroment;
        GameObject _instanceEnviroment;

        public LevelContext(LifetimeScope lifetimeScope,
            IPanelService panelService,
            ShowPersistentPanelStrategy showPersistentPanelStrategy)
        {
            _parentLifetimeScope = lifetimeScope;
            _panelService = panelService;
            _showPersistentPanelStrategy = showPersistentPanelStrategy;

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

        public async UniTask StartLevel()
        {
            await _panelService.ShowPanel(_showPersistentPanelStrategy, PanelType.PlayerHUD,
                "PlayerHUD", new PlayerHUDLifetimeScope());
            if (_prefabEnviroment == null)
            {
                _handleEnviroment = Addressables.LoadAssetAsync<GameObject>("Environment");
                _prefabEnviroment = await _handleEnviroment.ToUniTask();
            }
            _instanceEnviroment = _parentLifetimeScope.Container.Instantiate(_prefabEnviroment);
            await _levelState.Value.StartLevel();
        }

        public async UniTask StopLevel()
        {
            GameObject.Destroy(_instanceEnviroment);
            _handleEnviroment.Release();
            await _panelService.ShowPanel(_showPersistentPanelStrategy, PanelType.Gameplay,
                "GameplayPanel", new GameplayPanelLifetimeScope());
            _levelState.Value.StopLevel();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
