using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

namespace DenisKim.Core.Domain.Services
{
    public sealed class PlaybackRecorder : BaseDisposable, IPlaybackRecorder
    {
        private readonly PlaybackData _playbackData;

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
                  var newPosition = transform.position;

                  newPosition.y -= 0.8607845f;

                  _playbackData.frames.Add(new PlaybackData.FrameData
                  {
                      position = newPosition,
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