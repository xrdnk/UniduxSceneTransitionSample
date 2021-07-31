using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Transitioner
{
    public class TitlePageTransitioner
    {
        /// <summary>
        /// ゲーム画面に遷移する
        /// 次に遷移する場合はEnterXXXXPageと書く
        /// </summary>
        public void EnterMainPage()
        {
            // 次画面に移行．ここではMainPageDataの初期化も行いたいので，新たにMainPageDataのインスタンスを作成 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData()));
        }
    }
}