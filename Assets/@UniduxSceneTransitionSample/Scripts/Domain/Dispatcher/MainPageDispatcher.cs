using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.SceneTransition;
using Unidux.SceneTransition;
using UniRx;
using UnityEngine;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class MainPageDispatcher : MonoBehaviour
    {
        MainPageData _mainPageData;

        public IReadOnlyReactiveProperty<double> GodHpProperty => _godHpRp;
        DoubleReactiveProperty _godHpRp;

        double _godHp;
        double _damageDone;

        void Awake()
        {
            // Uniduxから現状のページデータであるMainGameDataを取得する

            _godHp = SceneTransition.Unidux.State.Page.GetData<MainPageData>().GodHp;
            _damageDone = SceneTransition.Unidux.State.Page.GetData<MainPageData>().DamageDone;
            _mainPageData = new MainPageData(_godHp, _damageDone);

            _godHpRp = new DoubleReactiveProperty(_godHp);
        }

        /// <summary>
        /// 神に攻撃する処理
        /// </summary>
        public void AttackGod()
        {
            // ビジネスロジック
            _godHp -= 10;
            _damageDone += 10;

            // View側に反映
            _godHpRp.Value = _godHp;

            // MainGameDataの更新処理
            _mainPageData.GodHp = _godHp;
            _mainPageData.DamageDone = _damageDone;
            var action = PageDuck<PageName, SceneName>.ActionCreator.SetData(_mainPageData);
            // ディスパッチ
            SceneTransition.Unidux.Dispatch(action);
        }

        public void LoadResultPage()
        {
            // MainGameDataにある神のHPとDDをResultPageDataに渡しながら画面遷移を実行
            var resultPageData = new ResultPageData(_mainPageData.DamageDone);
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Result, resultPageData);
            // ディスパッチ
            SceneTransition.Unidux.Dispatch(action);
        }
    }
}