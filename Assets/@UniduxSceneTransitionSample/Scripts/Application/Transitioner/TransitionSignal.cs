using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Transitioner
{
    public class TransitionSignal
    {
        public PageName TransitionPageName { get; }
        public TransitionType TransitionType { get; }
        public IPageData PageData { get; }

        public TransitionSignal
        (
            PageName transitionPageName,
            TransitionType transitionType,
            IPageData pageData = null
        )
        {
            TransitionPageName = transitionPageName;
            TransitionType = transitionType;
            PageData = pageData;
        }
    }
}