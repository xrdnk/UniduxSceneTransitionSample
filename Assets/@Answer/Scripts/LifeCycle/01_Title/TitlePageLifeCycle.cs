using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.Presenter;
using Denity.UniduxSceneTransitionSample.Answer.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Answer.LifeCycle
{
    public class TitlePageLifeCycle : MonoInstaller
    {
        [SerializeField] TitlePageView _view;

        public override void InstallBindings()
        {
            // Register
            Container.BindInterfacesAndSelfTo<TitlePageDispatcher>().AsSingle();
            Container.BindInstance(_view);
            Container.BindInterfacesAndSelfTo<TitlePagePresenter>().AsSingle();
        }

        TitlePagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _presenter = Container.Resolve<TitlePagePresenter>();

            // Originate
            _presenter.Originate();
        }

        void OnDestroy()
        {
            // Terminate
            _presenter.Terminate();
        }
    }
}