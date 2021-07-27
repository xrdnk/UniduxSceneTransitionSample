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
        [SerializeField] Button _buttonReturnTitle;
        [SerializeField] TMP_Text _textResult;

        readonly Subject<Unit> _returnTitleSubject = new Subject<Unit>();
        public IObservable<Unit> OnReturnTitleTriggerAsObservable() => _returnTitleSubject;

        protected override void Awake()
        {
            _buttonReturnTitle
                .OnClickAsObservable()
                .Subscribe(_ => _returnTitleSubject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void DisplayResult(double damageDone)
        {
            _textResult.text = $"Your DamageDone is {damageDone}";
        }
    }
}