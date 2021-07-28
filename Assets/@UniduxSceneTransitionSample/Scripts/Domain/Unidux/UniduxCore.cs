using System.Text;
using Unidux;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Unidux
{
    /// <summary>
    /// Uniduxのコアサービスクラス
    /// </summary>
    public sealed class UniduxCore : SingletonMonoBehaviour<UniduxCore>, IStoreAccessor
    {
        public TextAsset InitialStateJson;

        static Store<State> Store
        {
            get { return Instance._store ??= new Store<State>(InitialState, Reducers); }
        }
        private Store<State> _store;

        public IStoreObject StoreObject => Store;

        public static State State => Store.State;

        public static Subject<State> Subject => Store.Subject;

        private static IReducer[] Reducers
        {
            get {
                // Assign your reducers
                return new IReducer[]
                {
                    new SceneReducer(),
                    new PageReducer(),
                };
            }
        }

        private static State InitialState =>
            Instance.InitialStateJson != null ? UniduxSetting.Serializer.Deserialize(
                    Encoding.UTF8.GetBytes(Instance.InitialStateJson.text),
                    typeof(State)
                ) as State
                : new State();

        public static object Dispatch<TAction>(TAction action)
        {
            return Store.Dispatch(action);
        }

        void Update()
        {
            Store.Update();
        }
    }
}