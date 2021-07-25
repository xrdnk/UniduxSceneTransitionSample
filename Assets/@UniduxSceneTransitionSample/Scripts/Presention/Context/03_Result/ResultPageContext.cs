using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Presenter;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Context
{
    /// <summary>
    /// リザルト画面のコンテキストクラス(エントリーポイント)
    /// 初期化順序，メインループ，処理の流れはここで記述する
    /// IInitializable実装するクラスはContextだけにし，
    /// Presenter, Domainクラスの初期化はメソッド呼び出しとして，Contextを通して呼ぶ
    /// </summary>
    public class ResultPageContext : IInitializable
    {
        readonly ResultPageDispatcher _dispatcher;
        readonly ResultPagePresenter _presenter;

        [Inject]
        public ResultPageContext(ResultPageDispatcher dispatcher, ResultPagePresenter presenter)
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