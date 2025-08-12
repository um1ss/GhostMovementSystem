using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Domain.Services;
using DenisKim.Core.Infrastructure.States;
using DenisKim.Core.Infrastructure.Strategys;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace DenisKim.Core.LifetimeScopes.Scene
{
    public class GameplaySceneLifetimeScope : LifetimeScope
    {
        [SerializeField] PlaybackData PlaybackData;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(PlaybackData);

            builder.Register<ShowPersistentPanelStrategy>(Lifetime.Singleton);
            builder.Register<ShowOnDemandLoadingPanelStrategy>(Lifetime.Singleton);

            builder.Register<SingleLevel>(Lifetime.Singleton);
            builder.Register<GhostLevel>(Lifetime.Singleton);

            builder.Register<IGhostPlayerService, GhostPlayerService>(Lifetime.Singleton)
                .WithParameter(0.005f);
            builder.Register<IPlaybackRecorder, PlaybackRecorder>(Lifetime.Singleton);
            builder.Register<ILevelContext, LevelContext>(Lifetime.Singleton);
            builder.Register<IPanelService, PanelService>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameplaySceneEntryPoint>();
        }
    }
}
