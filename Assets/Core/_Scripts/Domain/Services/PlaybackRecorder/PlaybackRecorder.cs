using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public sealed class PlaybackRecorder : BaseDisposable, IPlaybackRecorder
    {
        private readonly PlaybackData _playbackData;

        Vector3 _currentTransform;

        private bool _isRecording = false;

        public PlaybackRecorder(PlaybackData playbackData)
        {
            _playbackData = playbackData;
        }
        public void StartRecording(Transform transform)
        {
            if (_isRecording) return;

            _isRecording = true;
            _playbackData.Clear();

            Observable.EveryUpdate()
              .Where(_ => transform != null)
              .TakeWhile(_ => _isRecording)
              .Subscribe(_ =>
              {
                  _currentTransform = transform.position;

                  _playbackData.frames.Add(new PlaybackData.FrameData
                  {
                      position = new Vector3(_currentTransform.x,
                      _currentTransform.y - 0.8607845f, _currentTransform.z),
                      rotation = transform.rotation
                  });
              })
              .AddTo(_compositeDisposable);
        }

        public void StopRecording()
        {
            _isRecording = false;
        }
    }
}