using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.ResultService;
using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.Unidux;
using Denity.UniduxSceneTransitionSample.View;
using MessagePipe;
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
        readonly ResultPageView _view;
        readonly IPublisher<TransitionSignal> _transitionPublisher;
        readonly CompositeDisposable _disposable;

        public ResultPagePresenter(ResultPageService service, IPublisher<TransitionSignal> transitionPublisher, ResultPageView view)
        {
            _service = service;
            _view = view;
            _transitionPublisher = transitionPublisher;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _service.DamageDoneProperty
                .Subscribe(_view.DisplayResult)
                .AddTo(_disposable);

            _view.OnGoToTitleTriggerAsObservable()
                .Subscribe(_ => _transitionPublisher.Publish(new TransitionSignal(PageName.Title, TransitionType.Replace)))
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _service?.Terminate();
            _disposable?.Dispose();
        }
    }
}