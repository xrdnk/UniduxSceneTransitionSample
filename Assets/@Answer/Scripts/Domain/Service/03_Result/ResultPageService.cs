using Denity.UniduxSceneTransitionSample.Answer.PageData;
using Denity.UniduxSceneTransitionSample.Answer.Unidux;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Answer.Service
{
    public class ResultPageService : IService
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