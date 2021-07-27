using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Unidux
{
    /// <summary>
    /// ページ状態を変更するクラス
    /// </summary>
    public class PageReducer : PageDuck<PageName, SceneName>.Reducer
    {
        public PageReducer() : base(new SceneConfig()) { }

        /// <summary>
        /// ページの状態を変更する
        /// </summary>
        /// <param name="state">ページの状態</param>
        /// <param name="action">ページの状態を変更する処理</param>
        /// <returns></returns>
        public override object ReduceAny(object state, object action)
        {
            var _state = (State) state;
            var _action = (PageDuck<PageName, SceneName>.IPageAction) action;
            _state.Page = Reduce(_state.Page, _state.Scene, _action);
            return state;
        }
    }
}