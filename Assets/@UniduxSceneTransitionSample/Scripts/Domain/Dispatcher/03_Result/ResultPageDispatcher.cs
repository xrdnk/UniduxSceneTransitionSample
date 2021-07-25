using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class ResultPageDispatcher
    {
        ResultPageData _pageData;

        public IReadOnlyReactiveProperty<double> DamageDoneProperty => _damageDoneRp;
        DoubleReactiveProperty _damageDoneRp;

        public void Originate()
        {
            _pageData = SceneTransition.Unidux.State.Page.GetData<ResultPageData>();
            _damageDoneRp = new DoubleReactiveProperty(_pageData.DamageDone);
        }

        public void ReturnTitle()
        {
            // これまでの情報を破棄してタイトル画面に戻る → Replace
            var action = PageDuck<PageName, SceneName>.ActionCreator.Replace(PageName.Title);
            SceneTransition.Unidux.Dispatch(action);
        }
    }
}