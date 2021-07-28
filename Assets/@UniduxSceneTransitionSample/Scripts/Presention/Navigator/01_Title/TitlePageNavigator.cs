using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Navigator
{
    public class TitlePageNavigator : IPeriod
    {
        readonly TitleView _titleView;
        readonly LicenceView _licenceView;
        readonly CompositeDisposable _disposable;

        [Inject]
        public TitlePageNavigator(TitleView titleView, LicenceView licenceView)
        {
            _titleView = titleView;
            _licenceView = licenceView;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _licenceView.Hide();

            _titleView.OnShowLicenceAsObservable()
                .Subscribe(_ => _licenceView.Show())
                .AddTo(_disposable);

            _licenceView.OnHideLicenceAsObservable()
                .Subscribe(_ => _licenceView.Hide())
                .AddTo(_disposable);
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}