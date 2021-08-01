using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denity.UniduxSceneTransitionSample.View
{
    /// <summary>
    /// タイトル画面のView
    /// ViewはMonoBehaviourを持つ
    /// </summary>
    public class TitleView : UIViewBase
    {
        [SerializeField] Button _buttonEnterMainPage;
        [SerializeField] Button _buttonShowLicence;

        public Button ButtonEnterMainPage => _buttonEnterMainPage;
        public Button ButtonShowLicence => _buttonShowLicence;

        readonly Subject<Unit> _showLicence = new Subject<Unit>();
        public IObservable<Unit> OnShowLicenceAsObservable() => _showLicence;

        protected override void Awake()
        {
            _buttonShowLicence
                .OnClickAsObservable()
                .Subscribe(_ => _showLicence.OnNext(Unit.Default))
                .AddTo(this);
        }
    }
}