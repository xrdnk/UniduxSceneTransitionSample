using Denity.UniduxSceneTransitionSample.MainService.PageData;
using Denity.UniduxSceneTransitionSample.Progression;
using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.MainService
{
    public class MainPageService : IPeriod
    {
        MainPageData _mainPageData;

        public IReadOnlyReactiveProperty<double> GodHpProperty => _godHpRp;
        DoubleReactiveProperty _godHpRp;

        double _godHp;
        double _damageDone;

        public void Originate()
        {
            // Uniduxから現状のページデータであるMainGameDataを取得する
            _godHp = UniduxCore.State.Page.GetData<MainPageData>().GodHp;
            _damageDone = UniduxCore.State.Page.GetData<MainPageData>().DamageDone;
            _mainPageData = new MainPageData(_godHp, _damageDone);
            _godHpRp = new DoubleReactiveProperty(_godHp);
        }

        public void Terminate()
        {
            _godHpRp?.Dispose();
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

            // データの更新 → SetData でディスパッチ
            var setDataAction = PageDuck<PageName, SceneName>.ActionCreator.SetData(_mainPageData);
            UniduxCore.Dispatch(setDataAction);
        }
    }
}