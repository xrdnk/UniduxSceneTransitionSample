using Denity.UniduxSceneTransitionSample.MainService.PageData;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.Unidux;
using Denity.UniduxSceneTransitionSample.View;
using MessagePipe;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// タイトル画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class TitlePagePresenter : IPeriod
    {
        readonly IPublisher<TransitionSignal> _transitionPublisher;
        readonly TitleView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public TitlePagePresenter(IPublisher<TransitionSignal> transitionPublisher, TitleView view)
        {
            _transitionPublisher = transitionPublisher;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _view.OnEnterPageAsObservable()
                .Subscribe(_ => _transitionPublisher.Publish(new TransitionSignal(PageName.Main, TransitionType.Push, new MainPageData())))
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}