using Denity.UniduxSceneTransitionSample.Context;
using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Presenter;
using Denity.UniduxSceneTransitionSample.View;
using UnityEngine;
using Zenject;

public class ResultPageInstaller : MonoInstaller
{
    [SerializeField] ResultPageView _view;

    public override void InstallBindings()
    {
        // Dispatcher
        Container.BindInterfacesAndSelfTo<ResultPageDispatcher>().AsSingle();

        // View
        Container.BindInstance(_view);

        // Presenter
        Container.BindInterfacesAndSelfTo<ResultPagePresenter>().AsSingle();

        // Context
        Container.BindInterfacesAndSelfTo<ResultPageContext>().AsSingle();
    }
}