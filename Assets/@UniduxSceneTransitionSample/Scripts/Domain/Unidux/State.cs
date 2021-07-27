using System;
using Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Unidux
{
    /// <summary>
    /// ステートエンティティ
    /// <remarks>状態を持つ項目を設定する</remarks>
    /// </summary>
    [Serializable]
    public class State : StateBase
    {
        public SceneState<SceneName> Scene { get; set; } = new SceneState<SceneName>();
        public PageState<PageName> Page { get; set; } = new PageState<PageName>();
    }
}