using Denity.UniduxSceneTransitionSample.Answer.PageData;
using Denity.UniduxSceneTransitionSample.Answer.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Dispatcher
{
    public class TitlePageDispatcher : IDispatcher
    {
        public void Originate()
        {
        }

        public void EnterGame()
        {
            // 次画面に移行．ここではMainPageDataの初期化も行いたいので，新たにMainPageDataのインスタンスを作成 → Push
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData());
            UniduxCore.Dispatch(action);
        }

        public void Terminate()
        {

        }
    }
}