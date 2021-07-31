using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.Navigator;
using Denity.UniduxSceneTransitionSample.Presenter;
using Denity.UniduxSceneTransitionSample.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.LifeCycle
{
    /// <summary>
    /// タイトル画面のライフサイクルクラス
    /// <remarks>
    /// AwakeでRegisterしたTransitioner・Viewを除くクラスの初期化処理を行い，
    /// OnDestroyでRegisterしたTransitioner・Viewを除くクラスの終端処理を行う
    /// </remarks>
    /// </summary>
    public class TitlePageLifeCycle : MonoInstaller
    {
        [SerializeField] TitleView _titleView;
        [SerializeField] LicenceView _licenceView;

        public override void InstallBindings()
        {
            // Register
            Container.BindInstance(_titleView);
            Container.Bind<UIViewBase>().FromInstance(_titleView);
            Container.BindInstance(_licenceView);
            Container.Bind<UIViewBase>().FromInstance(_licenceView);
            Container.BindInterfacesAndSelfTo<TitlePageNavigator>().AsSingle();
            Container.BindInterfacesAndSelfTo<TitlePagePresenter>().AsSingle();
        }

        TitlePageNavigator _navigator;
        TitlePagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _navigator = Container.Resolve<TitlePageNavigator>();
            _presenter = Container.Resolve<TitlePagePresenter>();

            // Originate
            _navigator.Originate();
            _presenter.Originate();
        }

        void OnDestroy()
        {
            // Terminate
            _navigator.Terminate();
            _presenter.Terminate();
        }
    }
}