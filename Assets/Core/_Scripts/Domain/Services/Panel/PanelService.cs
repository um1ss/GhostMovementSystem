using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure.Strategys;
using DenisKim.Core.LifetimeScopes;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Domain.Services
{
    public sealed class PanelService : BaseDisposable, IPanelService
    {
        readonly LifetimeScope _parentLifetimeScope;

        readonly Canvas _canvas;

        readonly Dictionary<PanelType, (GameObject instance,
            AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> _loadedUIPanels;

        PanelType _currentActivePersistentPanel;
        PanelType _currentActiveOnDemandLoadingPanel;

        public PanelService(LifetimeScope lifetimeScope,
            Canvas canvas)
        {
            _canvas = canvas;
            _parentLifetimeScope = lifetimeScope;
            _loadedUIPanels = new Dictionary<PanelType,
                (GameObject, AsyncOperationHandle<GameObject>, LifetimeScope lifetimeScope)>();
        }

        async UniTask AddPanelDictionary(PanelType panel, string address, IInstaller installer)
        {
            var childLifetimeScope = _parentLifetimeScope.CreateChild(installer);
            var handle = Addressables.LoadAssetAsync<GameObject>(address);
            var instance = childLifetimeScope.Container.Instantiate(await handle.ToUniTask(),
                _canvas.transform, false);
            instance.SetActive(false);
            _loadedUIPanels.Add(panel,
                (instance, handle, childLifetimeScope));
        }

        public async UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, PanelType panel,
            string address,
            IInstaller installer)
        {
            if (!_loadedUIPanels.ContainsKey(panel))
                await AddPanelDictionary(panel, address, installer);
            if (showPanelStrategy is ShowPersistentPanelStrategy)
                showPanelStrategy.UnloadPanel(panel, _loadedUIPanels, ref _currentActivePersistentPanel);
            else
                showPanelStrategy.UnloadPanel(panel, _loadedUIPanels, ref _currentActiveOnDemandLoadingPanel);
        }

        public void HidePanel()
        {
            Addressables.Release(_loadedUIPanels[_currentActiveOnDemandLoadingPanel].handle);
            _loadedUIPanels[_currentActiveOnDemandLoadingPanel].lifetimeScope.Dispose();
            Object.Destroy(_loadedUIPanels[_currentActiveOnDemandLoadingPanel].instance);
            _loadedUIPanels.Remove(_currentActiveOnDemandLoadingPanel);
            _currentActiveOnDemandLoadingPanel = PanelType.None;
        }
    }
}
