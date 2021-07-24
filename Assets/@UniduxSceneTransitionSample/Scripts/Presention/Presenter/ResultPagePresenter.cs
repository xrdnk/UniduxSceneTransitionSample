using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    public class ResultPagePresenter : MonoBehaviour
    {
        [SerializeField] ResultPageDispatcher _dispatcher;
        [SerializeField] ResultPageView _view;

        void Start()
        {
            _dispatcher.DamageDoneProperty
                .Subscribe(_view.DisplayResult)
                .AddTo(this);

            _view.OnReturnTitleTriggerAsObservable()
                .Subscribe(_ => _dispatcher.ReturnTitle())
                .AddTo(this);
        }
    }
}