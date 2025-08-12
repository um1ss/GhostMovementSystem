using DenisKim.Core.Application.ViewModels;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.LifetimeScopes.Panels
{
    public sealed class GameplayPanelLifetimeScope : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<GameplayPanelViewModel>(Lifetime.Singleton);
        }
    }
}
