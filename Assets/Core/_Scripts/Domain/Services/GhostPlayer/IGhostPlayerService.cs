using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public interface IGhostPlayerService
    {
        public void StartPlayRecording(Transform transform);
        public void StopPlayRecording();
    }
}