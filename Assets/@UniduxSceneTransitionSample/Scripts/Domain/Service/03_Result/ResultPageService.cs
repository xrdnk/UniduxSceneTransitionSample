using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Unidux;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Service
{
    public class ResultPageService : IPeriod
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
    }
}