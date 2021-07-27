using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denity.UniduxSceneTransitionSample.View
{
    /// <summary>
    /// リザルト画面のView
    /// ViewはMonoBehaviourを持つ
    /// </summary>
    public class ResultPageView : UIViewBase
    {
        [SerializeField] Button _buttonGoToTitle;
        [SerializeField] TMP_Text _textResult;

        readonly Subject<Unit> _goToTitleSubject = new Subject<Unit>();
        public IObservable<Unit> OnGoToTitleTriggerAsObservable() => _goToTitleSubject;

        protected override void Awake()
        {
            _buttonGoToTitle
                .OnClickAsObservable()
                .Subscribe(_ => _goToTitleSubject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void DisplayResult(double damageDone)
        {
            _textResult.text = $"Your DamageDone is {damageDone}";
        }
    }
}