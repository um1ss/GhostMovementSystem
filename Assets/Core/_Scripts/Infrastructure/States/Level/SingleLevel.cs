using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Services;

namespace DenisKim.Core.Infrastructure.States
{
    public sealed class SingleLevel : BaseLevelState
    {
        public SingleLevel(IPlaybackRecorder playbackRecorder) : base(playbackRecorder)
        {
        }

        public override async UniTask StartLevel()
        {
            await base.StartLevel();
            _recorder.StartRecording(_instancePlayer.transform);
        }

        public override void StopLevel()
        {
            base.StopLevel();
            _recorder.StopRecording();
        }
    }
}
