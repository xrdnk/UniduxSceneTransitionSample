using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Unidux;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Context
{
    /// <summary>
    /// BaseSceneのコンテキストクラス(エントリーポイント)
    /// 初期化順序，メインループ，処理の流れはここで記述する
    /// IInitializable実装するクラスはContextだけにし，
    /// Presenter, Domainクラスの初期化はメソッド呼び出しとして，Contextを通して呼ぶ
    /// </summary>
    public class BaseSceneContext : IInitializable
    {
        readonly PageWatcher _pageWatcher;
        readonly SceneWatcher _sceneWatcher;
        readonly BaseSceneDispatcher _dispatcher;

        [Inject]
        public BaseSceneContext
        (
            PageWatcher pageWatcher,
            SceneWatcher sceneWatcher,
            BaseSceneDispatcher dispatcher
        )
        {
            _pageWatcher = pageWatcher;
            _sceneWatcher = sceneWatcher;
            _dispatcher = dispatcher;
        }

        public void Initialize()
        {
            // Watcher の初期化
            _pageWatcher.Initialize();
            _sceneWatcher.Initialize();

            // Dispatcher の初期化
            _dispatcher.Originate();
        }
    }
}