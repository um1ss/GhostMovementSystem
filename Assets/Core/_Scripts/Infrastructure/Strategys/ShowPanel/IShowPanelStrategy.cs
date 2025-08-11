using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure.Strategys
{
    public interface IShowPanelStrategy
    {
        void UnloadPanel(PanelType panel,
                Dictionary<PanelType, (GameObject instance,
                AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> loadedPanels,
                ref PanelType currentActivePanel);
    }
}
