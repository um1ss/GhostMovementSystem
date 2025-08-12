using DenisKim.Core.Application.ViewModels;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public class PlayerHUDLifetimeScope : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<PlayerHUDViewModel>(Lifetime.Scoped);
        }
    }
}
