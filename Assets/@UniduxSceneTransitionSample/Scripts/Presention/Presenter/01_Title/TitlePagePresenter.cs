using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Presenter
{
    /// <summary>
    /// タイトル画面のPresenter
    /// 純粋にViewからDomain，DomainからViewの処理の橋渡し役
    /// ここでの処理は初期化順等を伴わないものとする
    /// </summary>
    public class TitlePagePresenter : IPresenter
    {
        readonly TitlePageTransitioner _transitioner;
        readonly TitleView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public TitlePagePresenter(TitlePageTransitioner transitioner, TitleView view)
        {
            _transitioner = transitioner;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _view.OnGameStartAsObservable()
                .Subscribe(_ => _transitioner.EnterMainPage())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}