using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Unidux;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.LifeCycle
{
    public class UniduxBaseLifeCycle : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Register
            Container.BindInterfacesAndSelfTo<SceneWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<PageWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<BaseSceneDispatcher>().AsSingle();
        }

        PageWatcher _pageWatcher;
        SceneWatcher _sceneWatcher;
        BaseSceneDispatcher _dispatcher;

        void Awake()
        {
            // Resolve
            _pageWatcher = Container.Resolve<PageWatcher>();
            _sceneWatcher = Container.Resolve<SceneWatcher>();
            _dispatcher = Container.Resolve<BaseSceneDispatcher>();

            // Originate
            _pageWatcher.Originate();
            _sceneWatcher.Originate();
            _dispatcher.EnterTitlePage();
        }

        void OnDestroy()
        {
            // Terminate
            _pageWatcher.Terminate();
            _sceneWatcher.Terminate();
        }
    }
}