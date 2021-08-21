using Denity.UniduxSceneTransitionSample.MainService;
using Denity.UniduxSceneTransitionSample.MainService.PageData;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.ResultService;
using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.Unidux;
using Denity.UniduxSceneTransitionSample.View;
using MessagePipe;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// ゲーム画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class MainPagePresenter : IPeriod
    {
        readonly MainPageService _service;
        readonly IPublisher<TransitionSignal> _transitionPublisher;
        readonly MainPageView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public MainPagePresenter(MainPageService service, IPublisher<TransitionSignal> transitionPublisher, MainPageView view)
        {
            _service = service;
            _transitionPublisher = transitionPublisher;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _view.OnAttackedAsObservable()
                .Subscribe(_ => _service.AttackGod())
                .AddTo(_disposable);

            _service.GodHpProperty
                .Subscribe(_view.DisplayGodHp)
                .AddTo(_disposable);

            _view.OnEnterResultAsObservable()
                .Subscribe(_ =>
                {
                    var mainPageData = UniduxCore.State.Page.GetData<MainPageData>();
                    var resultPageData = new ResultPageData(mainPageData.DamageDone);
                    _transitionPublisher.Publish(new TransitionSignal(PageName.Result, TransitionType.Push, resultPageData));
                })
                .AddTo(_disposable);

            _view.OnReturnTitleAsObservable()
                .Subscribe(_ => _transitionPublisher.Publish(new TransitionSignal(PageName.Title, TransitionType.Pop)))
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _service?.Terminate();
            _disposable?.Dispose();
        }
    }
}