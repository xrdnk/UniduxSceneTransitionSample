using System;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Unidux;
using MessagePipe;
using Unidux.SceneTransition;
using UniRx;
using Zenject;

namespace Denity.UniduxSceneTransitionSample.Transitioner
{
    public class SceneTransitioner : IPeriod
    {
        readonly ISubscriber<TransitionSignal> _transitionSubscriber;
        readonly CompositeDisposable _disposable;

        [Inject]
        public SceneTransitioner(ISubscriber<TransitionSignal> transitionSubscriber)
        {
            _transitionSubscriber = transitionSubscriber;
            _disposable = new CompositeDisposable();
        }

        public void Originate()
        {
            _transitionSubscriber
                .Subscribe(TransitPage)
                .AddTo(_disposable);
        }

        void TransitPage(TransitionSignal signal)
        {
            switch (signal.TransitionType)
            {
                case TransitionType.Push:
                    PushPage(signal.TransitionPageName, signal.PageData);
                    break;
                case TransitionType.Pop:
                    PopPage();
                    break;
                case TransitionType.Replace:
                    ReplacePage(signal.TransitionPageName, signal.PageData);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void PushPage(PageName pageName, IPageData pageData = null)
        {
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(pageName, pageData));
        }

        void PopPage()
        {
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Pop());
        }

        void ReplacePage(PageName pageName, IPageData pageData = null)
        {
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Replace(pageName, pageData));
        }

        public void Terminate()
        {
            _disposable?.Dispose();
        }
    }
}