using System;
using Denity.UniduxSceneTransitionSample.Answer.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Dispatcher
{
    public class BaseSceneDispatcher : IDispatcher
    {
        public void Originate()
        {
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }

        public void Terminate()
        {
        }
    }
}