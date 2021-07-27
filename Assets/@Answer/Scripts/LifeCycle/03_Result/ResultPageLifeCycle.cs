using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.Presenter;
using Denity.UniduxSceneTransitionSample.Answer.Service;
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
            Container.BindInterfacesAndSelfTo<ResultPageService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResultPageDispatcher>().AsSingle();
            Container.BindInstance(_view);
            Container.Bind<UIViewBase>().FromInstance(_view);
            Container.BindInterfacesAndSelfTo<ResultPagePresenter>().AsSingle();
        }

        ResultPageService _service;
        ResultPagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _service = Container.Resolve<ResultPageService>();
            _presenter = Container.Resolve<ResultPagePresenter>();

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