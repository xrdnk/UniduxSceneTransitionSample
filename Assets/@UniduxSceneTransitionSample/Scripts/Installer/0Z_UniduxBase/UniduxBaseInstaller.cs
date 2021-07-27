using Denity.UniduxSceneTransitionSample.Context;
using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Unidux;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Installer
{
    public class UniduxBaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Watcher
            Container.BindInterfacesAndSelfTo<SceneWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<PageWatcher>().AsSingle();

            // Dispatcher
            Container.BindInterfacesAndSelfTo<BaseSceneDispatcher>().AsSingle();

            // Context (エントリーポイント)
            Container.BindInterfacesAndSelfTo<BaseSceneContext>().AsSingle();
        }
    }
}