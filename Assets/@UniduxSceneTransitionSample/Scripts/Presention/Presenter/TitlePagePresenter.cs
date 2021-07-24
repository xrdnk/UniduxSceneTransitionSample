using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    public class TitlePagePresenter : MonoBehaviour
    {
        [SerializeField] TitlePageDispatcher _dispatcher;
        [SerializeField] TitlePageView _view;

        void Start()
        {
            _view.OnGameStartAsObservable()
                .Subscribe(_ => _dispatcher.EnterGame())
                .AddTo(this);
        }
    }
}