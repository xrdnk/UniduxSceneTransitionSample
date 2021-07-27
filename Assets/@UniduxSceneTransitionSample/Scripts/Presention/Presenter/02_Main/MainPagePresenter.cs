using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Service;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// ゲーム画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class MainPagePresenter : IPresenter
    {
        readonly MainPageService _service;
        readonly MainPageDispatcher _dispatcher;
        readonly MainPageView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public MainPagePresenter(MainPageService service, MainPageDispatcher dispatcher, MainPageView view)
        {
            _service = service;
            _dispatcher = dispatcher;
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

            _view.OnLoadResultAsObservable()
                .Subscribe(_ => _dispatcher.EnterResultPage())
                .AddTo(_disposable);

            _view.OnReturnTitleAsObservable()
                .Subscribe(_ => _dispatcher.ReturnTitlePage())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _service?.Terminate();
            _disposable?.Dispose();
        }
    }
}