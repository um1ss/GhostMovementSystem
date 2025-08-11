using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure.Strategys
{
    public sealed class ShowOnDemandLoadingPanelStrategy : IShowPanelStrategy
    {
        public void UnloadPanel(PanelType panel,
                Dictionary<PanelType, (GameObject instance, AsyncOperationHandle<GameObject> handle,
                    LifetimeScope lifetimeScope)> loadedPanels,
                ref PanelType currentActivePanel)
        {
            if (currentActivePanel != PanelType.None)
            {
                Addressables.Release(loadedPanels[currentActivePanel].handle);
                loadedPanels[currentActivePanel].lifetimeScope.Dispose();
                Object.Destroy(loadedPanels[currentActivePanel].instance);
                loadedPanels.Remove(currentActivePanel);
            }
            currentActivePanel = panel;
            loadedPanels[currentActivePanel].instance.SetActive(true);
        }
    }
}
