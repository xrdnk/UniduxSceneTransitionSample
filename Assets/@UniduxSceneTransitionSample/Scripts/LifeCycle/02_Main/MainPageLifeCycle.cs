using Denity.UniduxSceneTransitionSample.MainService;
using Denity.UniduxSceneTransitionSample.Presenter;
using Denity.UniduxSceneTransitionSample.View;
using UnityEngine;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.LifeCycle
{
    /// <summary>
    /// ゲーム画面用のライフサイクルクラス
    /// <remarks>
    /// AwakeでRegisterしたTransitioner・Viewを除くクラスの初期化処理を行い，
    /// OnDestroyでRegisterしたTransitioner・Viewを除くクラスの終端処理を行う
    /// </remarks>
    /// </summary>
    public class MainPageLifeCycle : MonoInstaller
    {
        [SerializeField] MainPageView _view;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainPageService>().AsSingle();
            Container.BindInstance(_view);
            Container.Bind<UIViewBase>().FromInstance(_view);
            Container.BindInterfacesAndSelfTo<MainPagePresenter>().AsSingle();
        }

        MainPageService _service;
        MainPagePresenter _presenter;

        void Awake()
        {
            // Resolve
            _service = Container.Resolve<MainPageService>();
            _presenter = Container.Resolve<MainPagePresenter>();

            // Originate
            _service.Originate();
            _presenter.Originate();
        }

        void OnDestroy()
        {
            // Terminate
            _service.Terminate();
            _presenter.Terminate();
        }
    }
}