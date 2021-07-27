using Denity.UniduxSceneTransitionSample.Answer.PageData;
using Denity.UniduxSceneTransitionSample.Answer.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Dispatcher
{
    public class TitlePageDispatcher
    {
        /// <summary>
        /// ゲーム画面に遷移する
        /// </summary>
        public void EnterMainPage()
        {
            // 次画面に移行．ここではMainPageDataの初期化も行いたいので，新たにMainPageDataのインスタンスを作成 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData()));
        }
    }
}