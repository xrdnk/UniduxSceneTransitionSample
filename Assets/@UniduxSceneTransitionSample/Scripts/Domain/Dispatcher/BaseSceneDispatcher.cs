using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class BaseSceneDispatcher : MonoBehaviour
    {
        void Awake()
        {
            SceneTransition.Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            SceneTransition.Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }
    }
}