using Denity.UniduxSceneTransitionSample.Dispatcher;
using Denity.UniduxSceneTransitionSample.Service;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// リザルト画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class ResultPagePresenter : IPresenter
    {
        readonly ResultPageService _service;
        readonly ResultPageDispatcher _dispatcher;
        readonly ResultPageView _view;
        readonly CompositeDisposable _disposable;

        public ResultPagePresenter(ResultPageService service, ResultPageDispatcher dispatcher, ResultPageView view)
        {
            _service = service;
            _dispatcher = dispatcher;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _service.DamageDoneProperty
                .Subscribe(_view.DisplayResult)
                .AddTo(_disposable);

            _view.OnReturnTitleTriggerAsObservable()
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