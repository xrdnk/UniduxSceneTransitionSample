using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class ResultPageDispatcher : MonoBehaviour
    {
        ResultPageData _pageData;

        public IReadOnlyReactiveProperty<double> DamageDoneProperty => _damageDoneRp;
        DoubleReactiveProperty _damageDoneRp;

        void Awake()
        {
            _pageData = SceneTransition.Unidux.State.Page.GetData<ResultPageData>();
            _damageDoneRp = new DoubleReactiveProperty(_pageData.DamageDone);
        }

        public void ReturnTitle()
        {
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title);
            SceneTransition.Unidux.Dispatch(action);
        }
    }
}