using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Services;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace DenisKim.Core.EntryPoints
{
    public sealed class BootstrapSceneEntryPoint : IAsyncStartable
    {
        readonly LifetimeScope _rootLifetimeScope;

        public BootstrapSceneEntryPoint(LifetimeScope lifetimeScope, 
            EventSystem eventSystem,
            Canvas canvas,
            Camera camera)
        {
            _rootLifetimeScope = lifetimeScope;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            using (LifetimeScope.EnqueueParent(_rootLifetimeScope))
            {
                await SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            }
        }
    }
}
