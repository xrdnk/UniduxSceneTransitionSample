using System;
using Denity.UniduxSceneTransitionSample.PageData;
using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;
using UniRx;

namespace Denity.UniduxSceneTransitionSample.Dispatcher
{
    public class MainPageDispatcher : IDisposable
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
            UniduxCore.Dispatch(action);
        }

        /// <summary>
        /// リザルト画面に遷移する処理
        /// </summary>
        public void LoadResultPage()
        {
            // MainGameDataにある神のHPとDDをResultPageDataに渡しながら画面遷移を実行
            var resultPageData = new ResultPageData(_mainPageData.DamageDone);
            // 情報をリザルト画面に引継ぎつつ画面遷移 → Push
            var action = PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Result, resultPageData);
            // ディスパッチ
            UniduxCore.Dispatch(action);
        }

        /// <summary>
        /// タイトル画面に遷移する処理
        /// </summary>
        public void ReturnTitlePage()
        {
            // タイトル画面に戻る → 前のページに戻る Pop
            var action = PageDuck<PageName, SceneName>.ActionCreator.Pop();
            UniduxCore.Dispatch(action);
        }

        public void Dispose()
        {
            _godHpRp?.Dispose();
        }
    }
}