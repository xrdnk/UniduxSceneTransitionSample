using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.Unidux;
using MessagePipe;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.LifeCycle
{
    /// <summary>
    /// UniduxServiceScene用のライフサイクルクラス
    /// <remarks>
    /// AwakeでRegisterしたTransitioner・Viewを除くクラスの初期化処理を行い，
    /// OnDestroyでRegisterしたTransitioner・Viewを除くクラスの終端処理を行う
    /// </remarks>
    /// </summary>
    public class UniduxBaseLifeCycle : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Register Signal
            var option = Container.BindMessagePipe();
            Container.BindMessageBroker<TransitionSignal>(option);

            // Register Domains
            Container.BindInterfacesAndSelfTo<SceneWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<PageWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneTransitioner>().AsSingle();
        }

        PageWatcher _pageWatcher;
        SceneWatcher _sceneWatcher;
        SceneTransitioner _transitioner;
        IPublisher<TransitionSignal> _transitionPublisher;

        void Awake()
        {
            // Resolve
            _pageWatcher = Container.Resolve<PageWatcher>();
            _sceneWatcher = Container.Resolve<SceneWatcher>();
            _transitioner = Container.Resolve<SceneTransitioner>();
            _transitionPublisher = Container.Resolve<IPublisher<TransitionSignal>>();

            // Originate
            _pageWatcher.Originate();
            _sceneWatcher.Originate();
            _transitioner.Originate();

            // At first, Transit to Title Page
            _transitionPublisher.Publish(new TransitionSignal(PageName.Title, TransitionType.Push));
        }

        void OnDestroy()
        {
            // Terminate
            _pageWatcher.Terminate();
            _sceneWatcher.Terminate();
            _transitioner.Terminate();
        }
    }
}