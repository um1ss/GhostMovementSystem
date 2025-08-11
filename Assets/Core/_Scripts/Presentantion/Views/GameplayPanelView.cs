using DenisKim.Core.Application.ViewModels;
using TMPro;
using UnityEngine;
using VContainer;
using R3;

namespace DenisKim.Core.Presentantion.Views
{
    public sealed class GameplayPanelView : BaseDisposableMB
    {
        [SerializeField] TextMeshProUGUI _levelStatus;

        [Inject]
        readonly GameplayPanelViewModel _viewModel;

        private void Start()
        {
            _viewModel.Level.Subscribe(text =>
            {
                Debug.Log($"View получил новое состо€ние: {text}"); // ƒобавл€ем лог здесь
                _levelStatus.text = text;
            }).AddTo(_compositeDisposable);
            //_viewModel.Level.Subscribe(text => _levelStatus.text = text)
            //    .AddTo(_compositeDisposable);
        }
    }
}
