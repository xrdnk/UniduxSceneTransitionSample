using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    public class MainPagePresenter : MonoBehaviour
    {
        [SerializeField] MainPageDispatcher _dispatcher;
        [SerializeField] MainPageView _view;

        void Start()
        {
            _view.OnAttackedAsObservable()
                .Subscribe(_ => _dispatcher.AttackGod())
                .AddTo(this);

            _dispatcher.GodHpProperty
                .Subscribe(_view.DisplayGodHp)
                .AddTo(this);

            _view.OnLoadResultAsObservable()
                .Subscribe(_ => _dispatcher.LoadResultPage())
                .AddTo(this);
        }
    }
}