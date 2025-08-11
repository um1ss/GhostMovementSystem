using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure.Strategys
{
    public sealed class ShowPersistentPanelStrategy : IShowPanelStrategy
    {
        public void UnloadPanel(PanelType panel,
                Dictionary<PanelType, (GameObject instance, AsyncOperationHandle<GameObject> handle,
                    LifetimeScope lifetimeScope)> loadedPanels,
                ref PanelType currentActivePanel)
        {
            if (currentActivePanel != PanelType.None)
                loadedPanels[currentActivePanel].instance.SetActive(false);
            currentActivePanel = panel;
            loadedPanels[currentActivePanel].instance.SetActive(true);
        }
    }
}
