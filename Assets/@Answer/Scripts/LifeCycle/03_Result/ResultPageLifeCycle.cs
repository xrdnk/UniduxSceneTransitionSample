using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.Presenter;
using Denity.UniduxSceneTransitionSample.Answer.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Answer.LifeCycle
{
    public class ResultPageLifeCycle : MonoInstaller
    {
        [SerializeField] ResultPageView _view;

        public override void InstallBindings()
        {
            // Register
            Container.BindInterfacesAndSelfTo<ResultPageDispatcher>().AsSingle();
            Container.BindInstance(_view);
            Container.BindInterfacesAndSelfTo<ResultPagePresenter>().AsSingle();
        }

        ResultPageDispatcher _dispatcher;
        ResultPagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _dispatcher = Container.Resolve<ResultPageDispatcher>();
            _presenter = Container.Resolve<ResultPagePresenter>();

            // Originate
            _dispatcher.Originate();
            _presenter.Originate();
        }

        void OnDestroy()
        {
            // Terminate
            _dispatcher.Terminate();
            _presenter.Terminate();
        }
    }
}