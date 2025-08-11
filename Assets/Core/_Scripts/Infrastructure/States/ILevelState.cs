using DenisKim.Core.Domain.Contexts;

namespace DenisKim.Core.Infrastructure.States
{
    public interface ILevelState
    {
        public void SetContext(ILevelContext context);

        void StartLevel();
    }
}
