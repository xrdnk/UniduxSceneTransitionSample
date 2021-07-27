using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class BaseSceneDispatcher
    {
        public void Originate()
        {
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }
    }
}