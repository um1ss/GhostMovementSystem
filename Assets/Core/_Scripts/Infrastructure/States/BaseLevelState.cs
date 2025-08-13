using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain.Contexts;
using DenisKim.Core.Domain.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure.States
{
    public abstract class BaseLevelState : ILevelState
    {
        protected readonly IPlaybackRecorder _recorder;
        protected ILevelContext _context;

        protected AsyncOperationHandle<GameObject> _handlePlayer;
        protected GameObject _instancePlayer;

        protected BaseLevelState(IPlaybackRecorder playbackRecorder)
        {
            _recorder = playbackRecorder;
        }

        public void SetContext(ILevelContext context)
        {
            _context = context;
        }

        public virtual async UniTask StartLevel()
        {
            if (!_handlePlayer.IsValid())
                _handlePlayer = Addressables.LoadAssetAsync<GameObject>("Ash_Body");
            await _handlePlayer.ToUniTask();
            if(_handlePlayer.Status==AsyncOperationStatus.Succeeded)
                _instancePlayer = GameObject.Instantiate(_handlePlayer.Result);
        }

        public virtual void StopLevel()
        {
            GameObject.Destroy(_instancePlayer);
            Addressables.Release(_handlePlayer);
        }
    }
}
