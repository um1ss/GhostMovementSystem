using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Domain.Services;
using DenisKim.Core.Infrastructure.States;
using DenisKim.Core.Infrastructure.Strategys;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.LifetimeScopes.Scene
{
    public class GameplaySceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ShowPersistentPanelStrategy>(Lifetime.Scoped);
            builder.Register<ShowOnDemandLoadingPanelStrategy>(Lifetime.Scoped);

            builder.Register<SingleLevel>(Lifetime.Scoped);
            builder.Register<GhostLevel>(Lifetime.Scoped);

            builder.Register<ILevelContext, LevelContext>(Lifetime.Scoped);
            builder.Register<IPanelService, PanelService>(Lifetime.Scoped);

            builder.RegisterEntryPoint<GameplaySceneEntryPoint>();
        }
    }
}
