using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Denity.UniduxSceneTransitionSample.Answer.View
{
    /// <summary>
    /// タイトル画面のView
    /// ViewはMonoBehaviourを持つ
    /// </summary>
    public class TitlePageView : MonoBehaviour
    {
        [SerializeField] Button _buttonGameStart;

        readonly Subject<Unit> _gameStartSubject = new Subject<Unit>();
        public IObservable<Unit> OnGameStartAsObservable() => _gameStartSubject;

        void Awake()
        {
            _buttonGameStart
                .OnClickAsObservable()
                .Subscribe(_ => _gameStartSubject.OnNext(Unit.Default))
                .AddTo(this);
        }
    }
}