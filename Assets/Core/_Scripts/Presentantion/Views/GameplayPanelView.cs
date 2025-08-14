using DenisKim.Core.Application.ViewModels;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentantion.Views
{
    public sealed class GameplayPanelView : BaseDisposableMB
    {
        [SerializeField] TextMeshProUGUI _levelStatus;
        [SerializeField] Button _playButton;
        [SerializeField] Button _setSingleLevel;
        [SerializeField] Button _setGhostLevel;

        [Inject]
        readonly GameplayPanelViewModel _viewModel;

        private void Start()
        {
            _viewModel.Level.Subscribe(text => _levelStatus.text = text)
                .AddTo(_compositeDisposable);

            _playButton.OnClickAsObservable().Subscribe(button =>
            {
                _viewModel.OnStartLevel.Execute(button);
            }).AddTo(_compositeDisposable);

            _setSingleLevel.OnClickAsObservable().Subscribe(button =>
            {
                _viewModel.OnSetSingleLevel.Execute(button);
            }).AddTo(_compositeDisposable);

            _setGhostLevel.OnClickAsObservable().Subscribe(button =>
            {
                _viewModel.OnSetGhostLevel.Execute(button);
            }).AddTo(_compositeDisposable);
        }
    }
}
