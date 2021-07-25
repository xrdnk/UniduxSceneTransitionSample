using Denity.UniduxSceneTransitionSample.Context;
using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Presenter;
using Denity.UniduxSceneTransitionSample.View;
using UnityEngine;
using Zenject;

public class MainPageInstaller : MonoInstaller
{
    [SerializeField] MainPageView _view;

    public override void InstallBindings()
    {
        // Dispatcher
        Container.BindInterfacesAndSelfTo<MainPageDispatcher>().AsSingle();

        // View
        Container.BindInstance(_view);

        // Presenter
        Container.BindInterfacesAndSelfTo<MainPagePresenter>().AsSingle();

        // Context(エントリーポイント)
        Container.BindInterfacesAndSelfTo<MainPageContext>().AsSingle();
    }
}