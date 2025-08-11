using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Infrastructure.States;
using UnityEngine;
using VContainer;

namespace DenisKim.Core
{
    public class test : MonoBehaviour
    {
        [Inject]
        GhostLevel ghostLevel;
        [Inject]
        SingleLevel single;

        [Inject]
        ILevelContext levelContext;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                levelContext.TransitionTo(single);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                levelContext.TransitionTo(ghostLevel);
            }
        }
    }
}
