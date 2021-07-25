using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class BaseSceneDispatcher
    {
        public void Originate()
        {
            SceneTransition.Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            SceneTransition.Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }
    }
}