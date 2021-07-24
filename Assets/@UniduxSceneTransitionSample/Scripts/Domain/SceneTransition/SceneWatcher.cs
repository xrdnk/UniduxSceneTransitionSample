using Cysharp.Threading.Tasks;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.SceneTransition
{
    public class SceneWatcher : MonoBehaviour
    {
        void Start()
        {
            Unidux.Subject
                .Where(state => state.Scene.IsStateChanged)
                .StartWith(Unidux.State)
                .Subscribe(state => _ = ChangeScenes(state.Scene))
                .AddTo(this);
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