using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure.States
{
    public sealed class GhostLevel : BaseLevelState
    {
        readonly IGhostPlayerService _ghostService;

        AsyncOperationHandle<GameObject> _handleGhost;
        GameObject _instanceGhost;

        public GhostLevel(IPlaybackRecorder playbackRecorder,
            IGhostPlayerService ghostPlayerService) : base(playbackRecorder)
        {
            _ghostService = ghostPlayerService;
        }

        public override async UniTask StartLevel()
        {
            await base.StartLevel();
            if (!_handleGhost.IsValid())
                _handleGhost = Addressables.LoadAssetAsync<GameObject>("Ash_BodyGhost");
            await _handleGhost.ToUniTask();
            if (_handleGhost.Status == AsyncOperationStatus.Succeeded)
                _instanceGhost = GameObject.Instantiate(_handleGhost.Result);
            _ghostService.StartPlayRecording(_instanceGhost.transform);
        }

        public override void StopLevel()
        {
            base.StopLevel();
            _ghostService.StopPlayRecording();
            GameObject.Destroy(_instanceGhost);
            Addressables.Release(_handleGhost);
        }
    }
}
