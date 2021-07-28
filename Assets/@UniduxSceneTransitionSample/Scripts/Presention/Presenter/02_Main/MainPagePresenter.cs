using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Transitioner;
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
    public class MainPagePresenter : IPeriod
    {
        readonly MainPageService _service;
        readonly MainPageTransitioner _transitioner;
        readonly MainPageView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public MainPagePresenter(MainPageService service, MainPageTransitioner transitioner, MainPageView view)
        {
            _service = service;
            _transitioner = transitioner;
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
                .Subscribe(_ => _transitioner.EnterResultPage())
                .AddTo(_disposable);

            _view.OnReturnTitleAsObservable()
                .Subscribe(_ => _transitioner.ReturnTitlePage())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _service?.Terminate();
            _disposable?.Dispose();
        }
    }
}