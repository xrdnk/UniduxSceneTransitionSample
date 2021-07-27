using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class BaseSceneDispatcher
    {
        /// <summary>
        /// タイトル画面に遷移する
        /// </summary>
        public void EnterTitlePage()
        {
            // 一旦ステートのクリーンのためにResetでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            // 最初のタイトル画面を起動 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }
    }
}