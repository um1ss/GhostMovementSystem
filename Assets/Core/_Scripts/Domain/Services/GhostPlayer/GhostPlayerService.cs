using R3;
using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public sealed class GhostPlayerService : BaseDisposable, IGhostPlayerService
    {
        private readonly PlaybackData _playbackData;

        private bool _isPlaying = false;
        private int _currentFrameIndex = 0;

        public GhostPlayerService(PlaybackData playbackData)
        {
            _playbackData = playbackData;
        }
        public void StartPlayRecording(Transform transform)
        {
            if (_isPlaying) return;

            _isPlaying = true;
            _currentFrameIndex = 0;

            Observable.EveryUpdate()
                .Where(_ => transform != null && _isPlaying)
                .TakeWhile(_ => _currentFrameIndex < _playbackData.frames.Count)
                .Subscribe(_ =>
                {
                    var frame = _playbackData.frames[_currentFrameIndex];
                    transform.SetPositionAndRotation(frame.position, frame.rotation);

                    _currentFrameIndex++;
                })
                .AddTo(_compositeDisposable);
        }

        public void StopPlayRecording()
        {
            _isPlaying = false;
        }
    }
}