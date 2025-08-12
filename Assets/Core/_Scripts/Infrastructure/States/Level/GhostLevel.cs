using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure.States
{
    public sealed class GhostLevel : BaseLevelState
    {
        readonly IGhostPlayerService _playerService;

        AsyncOperationHandle<GameObject> _handle;
        GameObject _prefab;
        GameObject _instance;

        public GhostLevel(IPlaybackRecorder playbackRecorder,
            IGhostPlayerService ghostPlayerService) : base(playbackRecorder)
        {
            _playerService = ghostPlayerService;
        }

        public override async UniTask StartLevel()
        {
            await base.StartLevel();
            if (_prefab == null)
            {
                _handle = Addressables.LoadAssetAsync<GameObject>("Ash_BodyGhost");
                _prefab = await _handle.ToUniTask();
            }
            _instance = GameObject.Instantiate(_prefab);
            _playerService.StartRecording(_instance.transform);
        }

        public override void StopLevel()
        {
            base.StopLevel();
            GameObject.Destroy(_instance);
        }
    }
}
