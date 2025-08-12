using Ashsvp;
using DenisKim.Core.Domain.Contexts;
using UnityEngine;
using VContainer;

[RequireComponent(typeof(Collider))]
public sealed class FinishTrigger : MonoBehaviour
{
    [Inject]
    readonly ILevelContext _levelContext;

    private void Awake()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<SimcadeVehicleController>())
        {
            _levelContext.StopLevel();
        }
    }
}