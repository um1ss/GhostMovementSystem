using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public interface IPlaybackRecorder
    {
        public void StartRecording(Transform transform);
        public void StopRecording();
    }
}
