using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Answer.Unidux
{
    /// <summary>
    /// シーン状態を変更するクラス
    /// </summary>
    public class SceneReducer : SceneDuck<SceneName>.Reducer
    {
        /// <summary>
        /// 状態変更
        /// </summary>
        /// <param name="state">シーンの状態</param>
        /// <param name="action">シーンの状態を変更する処理</param>
        /// <returns></returns>
        public override object ReduceAny(object state, object action)
        {
            var _state = (State) state;
            var _action = (SceneDuck<SceneName>.Action) action;
            _state.Scene = base.Reduce(_state.Scene, _action);
            return state;
        }
    }
}