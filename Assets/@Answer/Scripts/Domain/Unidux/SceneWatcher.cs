using System;
using Cysharp.Threading.Tasks;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Answer.Unidux
{
    /// <summary>
    /// シーンの状態に変更が発生した際に監視するクラス
    /// </summary>
    public class SceneWatcher : IDisposable
    {
        CompositeDisposable _disposable = new CompositeDisposable();

        public void Originate()
        {
            UniduxCore.Subject
                .Where(state => state.Scene.IsStateChanged)
                .StartWith(UniduxCore.State)
                .Subscribe(state => _ = ChangeScenes(state.Scene))
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        async UniTaskVoid ChangeScenes(SceneState<SceneName> state)
        {
            foreach (var scene in state.Additionals(SceneUtil.GetActiveScenes<SceneName>()))
            {
                await SceneUtil.Add(scene.ToString());
            }

            foreach (var scene in state.Removals(SceneUtil.GetActiveScenes<SceneName>()))
            {
                await SceneUtil.Remove(scene.ToString());
            }
        }
    }
}