using Denity.UniduxSceneTransitionSample.Answer.Dispatcher;
using Denity.UniduxSceneTransitionSample.Answer.View;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Answer.Presenter
{
    /// <summary>
    /// タイトル画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class TitlePagePresenter : IPresenter
    {
        readonly TitlePageDispatcher _dispatcher;
        readonly TitlePageView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public TitlePagePresenter(TitlePageDispatcher dispatcher, TitlePageView view)
        {
            _dispatcher = dispatcher;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _view.OnGameStartAsObservable()
                .Subscribe(_ => _dispatcher.EnterMainPage())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}