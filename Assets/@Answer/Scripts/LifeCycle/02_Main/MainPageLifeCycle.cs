using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.Presenter;
using Denity.UniduxSceneTransitionSample.Answer.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Answer.LifeCycle
{
    public class MainPageLifeCycle : MonoInstaller
    {
        [SerializeField] MainPageView _view;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainPageDispatcher>().AsSingle();
            Container.BindInstance(_view);
            Container.BindInterfacesAndSelfTo<MainPagePresenter>().AsSingle();
        }

        MainPageDispatcher _dispatcher;
        MainPagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _dispatcher = Container.Resolve<MainPageDispatcher>();
            _presenter = Container.Resolve<MainPagePresenter>();

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