using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.Presenter;
using Denity.UniduxSceneTransitionSample.Answer.Service;
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
            Container.BindInterfacesAndSelfTo<MainPageService>().AsSingle();
            Container.BindInstance(_view);
            Container.BindInterfacesAndSelfTo<MainPagePresenter>().AsSingle();
        }

        MainPageService _service;
        MainPagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _service = Container.Resolve<MainPageService>();
            _presenter = Container.Resolve<MainPagePresenter>();

            // Originate
            _service.Originate();
            _presenter.Originate();
        }

        void OnDestroy()
        {
            // Terminate
            _service.Terminate();
            _presenter.Terminate();
        }
    }
}