using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class TitlePageDispatcher
    {
        public void EnterGame()
        {
            // 次画面に移行．ここではMainPageDataの初期化も行いたいので，新たにMainPageDataのインスタンスを作成 → Push
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData());
            UniduxCore.Dispatch(action);
        }
    }
}