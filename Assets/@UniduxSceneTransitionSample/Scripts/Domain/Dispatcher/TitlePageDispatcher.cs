using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class TitlePageDispatcher : MonoBehaviour
    {
        public void EnterGame()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData());
            SceneTransition.Unidux.Dispatch(action);
        }
    }
}