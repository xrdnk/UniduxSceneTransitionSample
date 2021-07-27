using System;
using Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Unidux
{
    [Serializable]
    public class State : StateBase
    {
        public SceneState<SceneName> Scene { get; set; } = new SceneState<SceneName>();
        public PageState<PageName> Page { get; set; } = new PageState<PageName>();
    }
}