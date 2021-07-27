using System;
using Denity.UniduxSceneTransitionSample.Answer.PageData;
using Denity.UniduxSceneTransitionSample.Answer.Unidux;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Answer.Dispatcher
{
    public class ResultPageDispatcher : IDispatcher
    {
        ResultPageData _pageData;

        public IReadOnlyReactiveProperty<double> DamageDoneProperty => _damageDoneRp;
        DoubleReactiveProperty _damageDoneRp;

        public void Originate()
        {
            _pageData = UniduxCore.State.Page.GetData<ResultPageData>();
            _damageDoneRp = new DoubleReactiveProperty(_pageData.DamageDone);
        }

        public void Terminate()
        {
            _damageDoneRp?.Dispose();
        }

        public void ReturnTitle()
        {
            // これまでの情報を破棄してタイトル画面に戻る → Replace
            var action = PageDuck<PageName, SceneName>.ActionCreator.Replace(PageName.Title);
            UniduxCore.Dispatch(action);
        }
    }
}