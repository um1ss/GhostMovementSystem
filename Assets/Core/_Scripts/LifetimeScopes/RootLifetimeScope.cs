using DenisKim.Core.Domain.Services;
using DenisKim.Core.EntryPoints;
using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DenisKim.Core.LifetimeScopes
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] EventSystem _eventSystem;
        [SerializeField] Camera _camera;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_eventSystem, Lifetime.Singleton)
                .DontDestroyOnLoad();
            builder.RegisterComponentInNewPrefab(_canvas, Lifetime.Singleton)
                .DontDestroyOnLoad();
            builder.RegisterComponentInNewPrefab(_camera, Lifetime.Singleton)
                .DontDestroyOnLoad();

            builder.RegisterEntryPoint<BootstrapSceneEntryPoint>();
        }
    }
}
