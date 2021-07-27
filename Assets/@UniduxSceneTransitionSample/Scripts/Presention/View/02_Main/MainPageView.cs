using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denity.UniduxSceneTransitionSample.View
{
    /// <summary>
    /// ゲーム画面のView
    /// ViewはMonoBehaviourを持つ
    /// </summary>
    public class MainPageView : UIViewBase
    {
        [SerializeField] Button _buttonAttackGod;
        [SerializeField] Button _buttonEnterResultPage;
        [SerializeField] Button _buttonReturnTitlePage;
        [SerializeField] TMP_Text _textGodHp;

        readonly Subject<Unit> _attackedSubject = new Subject<Unit>();
        public IObservable<Unit> OnAttackedAsObservable() => _attackedSubject;

        readonly Subject<Unit> _enterResultSubject = new Subject<Unit>();
        public IObservable<Unit> OnEnterResultAsObservable() => _enterResultSubject;

        readonly Subject<Unit> _returnTitleSubject = new Subject<Unit>();
        public IObservable<Unit> OnReturnTitleAsObservable() => _returnTitleSubject;

        protected override void Awake()
        {
            _buttonAttackGod
                .OnClickAsObservable()
                .Subscribe(_ => _attackedSubject.OnNext(Unit.Default))
                .AddTo(this);

            _buttonEnterResultPage
                .OnClickAsObservable()
                .Subscribe(_ => _enterResultSubject.OnNext(Unit.Default))
                .AddTo(this);

            _buttonReturnTitlePage
                .OnClickAsObservable()
                .Subscribe(_ => _returnTitleSubject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void DisplayGodHp(double godHp)
        {
            _textGodHp.text = $"GOD HP: {godHp}";
        }
    }
}