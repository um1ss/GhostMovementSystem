using DenisKim.Core.Application.ViewModels;
using TMPro;
using UnityEngine;
using VContainer;
using R3;
using UnityEngine.UI;

namespace DenisKim.Core.Presentantion.Views
{
    public sealed class GameplayPanelView : BaseDisposableMB
    {
        [SerializeField] TextMeshProUGUI _levelStatus;
        [SerializeField] Button _playButton;

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
        }
    }
}
