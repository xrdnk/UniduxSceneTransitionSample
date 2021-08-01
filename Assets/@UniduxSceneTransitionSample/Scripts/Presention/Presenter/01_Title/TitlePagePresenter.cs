using System;
using Cysharp.Threading.Tasks;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Transitioner;
using Denity.UniduxSceneTransitionSample.View;
using UniRx;
using UnityEngine;
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
        readonly SceneTransitioner _transitioner;
        readonly TitleView _view;
        readonly CompositeDisposable _disposable;

        [Inject]
        public TitlePagePresenter(SceneTransitioner transitioner, TitleView view)
        {
            _transitioner = transitioner;
            _view = view;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _view.ButtonEnterMainPage
                .BindToOnClick(_transitioner.TransitionTriggerProperty, _ =>
                {
                    Debug.Log("Transitioning... ");
                    _view.ButtonShowLicence.interactable = false;
                    return _transitioner.EnterMainPage()
                        .ToObservable()
                        .ForEachAsync(_ => Debug.Log("Transition Done."));
                });
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}