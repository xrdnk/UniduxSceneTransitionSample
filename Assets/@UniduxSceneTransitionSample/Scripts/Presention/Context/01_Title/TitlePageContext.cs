using Denity.UniduxSceneTransitionSample.Presenter;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Context
{
    /// <summary>
    /// タイトル画面のコンテキストクラス(エントリーポイント)
    /// 初期化順序，メインループ，処理の流れはここで記述する
    /// IInitializable実装するクラスはContextだけにし，
    /// Presenter, Domainクラスの初期化はメソッド呼び出しとして，Contextを通して呼ぶ
    /// </summary>
    public class TitlePageContext : IInitializable
    {
        readonly TitlePagePresenter _presenter;

        [Inject]
        public TitlePageContext(TitlePagePresenter presenter)
        {
            _presenter = presenter;
        }

        public void Initialize()
        {
            // Presenter の初期化
            _presenter.Originate();
        }
    }
}