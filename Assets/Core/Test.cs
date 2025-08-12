using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Infrastructure.States;
using UnityEngine;
using VContainer;

namespace DenisKim.Core.Test
{
    public sealed class Test : MonoBehaviour
    {
        [Inject]
        readonly GhostLevel ghostLevel;
        [Inject]
        readonly SingleLevel single;

        [Inject]
        readonly ILevelContext levelContext;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                levelContext.TransitionTo(single);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                levelContext.TransitionTo(ghostLevel);
            }
        }
    }
}
