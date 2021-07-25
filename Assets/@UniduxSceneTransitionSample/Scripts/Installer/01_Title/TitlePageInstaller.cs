using Denity.UniduxSceneTransitionSample.Context;
using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Presenter;
using Denity.UniduxSceneTransitionSample.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Installer
{
    public class TitlePageInstaller : MonoInstaller
    {
        [SerializeField] TitlePageView _view;

        public override void InstallBindings()
        {
            // Dispatcher
            Container.Bind<TitlePageDispatcher>().AsSingle();

            // View
            Container.BindInstance(_view);

            // Presenter
            Container.BindInterfacesAndSelfTo<TitlePagePresenter>().AsSingle();

            // Context(エントリーポイント)
            Container.BindInterfacesAndSelfTo<TitlePageContext>().AsSingle();
        }
    }
}