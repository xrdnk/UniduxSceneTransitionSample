using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.ResultService;
using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// リザルト画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class ResultPagePresenter : IPeriod
    {
        readonly ResultPageService _service;
        readonly SceneTransitioner _transitioner;
        readonly ResultPageView _view;
        readonly CompositeDisposable _disposable;

        public ResultPagePresenter(ResultPageService service, SceneTransitioner transitioner, ResultPageView view)
        {
            _service = service;
            _transitioner = transitioner;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _service.DamageDoneProperty
                .Subscribe(_view.DisplayResult)
                .AddTo(_disposable);

            _view.OnGoToTitleTriggerAsObservable()
                .Subscribe(_ => _transitioner.GoToTitlePage())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _service?.Terminate();
            _disposable?.Dispose();
        }
    }
}