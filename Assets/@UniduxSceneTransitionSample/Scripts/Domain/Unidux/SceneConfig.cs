using System.Collections.Generic;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Unidux
{
    /// <summary>
    /// シーン設定を行うクラス
    /// </summary>
    public class SceneConfig : ISceneConfig<SceneName, PageName>
    {
        /// <summary>
        /// カテゴリーマップの設定
        /// <remarks>ここにUnitySceneとカテゴリーの紐づけを行う</remarks>
        /// </summary>
        public IDictionary<SceneName, int> CategoryMap { get; } =
            new Dictionary<SceneName, int>
        {
            {SceneName.UniduxBaseScene, SceneCategory.Permanent},
            {SceneName.Title, SceneCategory.Page},
            {SceneName.Main, SceneCategory.Page},
            {SceneName.Result, SceneCategory.Page}
        };

        /// <summary>
        /// ページマップの設定
        /// <remarks>ページと複数のUnitySceneの紐づけを行う</remarks>
        /// </summary>
        public IDictionary<PageName, SceneName[]> PageMap { get; } =
            new Dictionary<PageName, SceneName[]>
        {
            {PageName.Title, new[] {SceneName.Title}},
            {PageName.Main, new [] {SceneName.Main}},
            {PageName.Result, new [] {SceneName.Result}}
        };
    }
}