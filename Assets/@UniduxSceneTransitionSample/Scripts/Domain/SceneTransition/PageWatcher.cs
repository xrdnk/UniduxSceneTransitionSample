﻿using System;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.SceneTransition
{
    /// <summary>
    /// ページの状態に変更が発生した際に監視するクラス
    /// </summary>
    public class PageWatcher : IDisposable
    {
        ISceneConfig<SceneName, PageName> _config = new SceneConfig();
        string _currentPageName;
        CompositeDisposable _disposable = new CompositeDisposable();

        public void Initialize()
        {
            Unidux.Subject
                // ページ状態が変更され，準備完了に移行している場合
                .Where(state => state.Page.IsStateChanged)
                .StartWith(Unidux.State)
                .Where(state => state.Page.IsReady)
                .Subscribe(UpdatePage)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        void UpdatePage(State state)
        {
            if (state.Scene.NeedsAdjust(_config.GetPageScenes(), _config.PageMap[state.Page.Current.Page]))
            {
                Unidux.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Adjust());
            }
        }
    }
}