using System.Collections.Generic;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Unidux
{
    /// <summary>
    /// シーン設定を行うクラス
    /// </summary>
    public class SceneConfig : ISceneConfig<SceneName, PageName>
    {
        public IDictionary<SceneName, int> CategoryMap { get; } =
            new Dictionary<SceneName, int>
        {
            {SceneName.UniduxBaseScene, SceneCategory.Permanent},
            {SceneName.Title, SceneCategory.Page},
            {SceneName.Main, SceneCategory.Page},
            {SceneName.Result, SceneCategory.Page}
        };

        public IDictionary<PageName, SceneName[]> PageMap { get; } =
            new Dictionary<PageName, SceneName[]>
        {
            {PageName.Title, new[] {SceneName.Title}},
            {PageName.Main, new [] {SceneName.Main}},
            {PageName.Result, new [] {SceneName.Result}}
        };
    }
}