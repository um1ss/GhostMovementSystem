using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure.Strategys;
using UnityEngine;
using VContainer.Unity;

namespace DenisKim.Core.Domain.Services
{
    public interface IPanelService
    {
        UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, PanelType panel,
            string address,
            IInstaller installer);

        void HidePanel();
    }
}
