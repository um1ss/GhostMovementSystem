using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public interface IGhostPlayerService
    {
        public void StartRecording(Transform transform);
        public void StopRecording();
    }
}