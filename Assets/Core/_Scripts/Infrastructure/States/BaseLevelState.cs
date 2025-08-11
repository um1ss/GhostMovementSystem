using DenisKim.Core.Domain.Contexts;

namespace DenisKim.Core.Infrastructure.States
{
    public abstract class BaseLevelState : ILevelState
    {
        protected ILevelContext _context;

        public void SetContext(ILevelContext context)
        {
            _context = context;
        }

        public abstract void StartLevel();
    }
}
