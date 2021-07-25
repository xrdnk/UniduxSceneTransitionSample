using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Presenter;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Context
{
    /// <summary>
    /// ゲーム画面のコンテキストクラス(エントリーポイント)
    /// 初期化順序，メインループ，処理の流れはここで記述する
    /// IInitializable実装するクラスはContextだけにし，
    /// Presenter, Domainクラスの初期化はメソッド呼び出しとして，Contextを通して呼ぶ
    /// </summary>
    public class MainPageContext : IInitializable
    {
        readonly MainPageDispatcher _dispatcher;
        readonly MainPagePresenter _presenter;

        [Inject]
        public MainPageContext(MainPageDispatcher dispatcher, MainPagePresenter presenter)
        {
            _dispatcher = dispatcher;
            _presenter = presenter;
        }

        public void Initialize()
        {
            // Dispatcher の初期化
            _dispatcher.Originate();

            // Presenter の初期化
            _presenter.Originate();
        }
    }
}