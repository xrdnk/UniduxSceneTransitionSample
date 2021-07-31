using Denity.UniduxSceneTransitionSample.MainService.PageData;
using Denity.UniduxSceneTransitionSample.ResultService;
using Denity.UniduxSceneTransitionSample.Unidux;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.Transitioner
{
    public class SceneTransitioner
    {
        /// <summary>
        /// タイトル画面に遷移する
        /// 次の画面に遷移する時はEnterXXXXPageと書く
        /// </summary>
        public void EnterTitlePage()
        {
            // 一旦ステートのクリーンのためにResetでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Reset());
            // 最初のタイトル画面を起動 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Title));
        }

        /// <summary>
        /// ゲーム画面に遷移する
        /// 次に遷移する場合はEnterXXXXPageと書く
        /// </summary>
        public void EnterMainPage()
        {
            // 次画面に移行．ここではMainPageDataの初期化も行いたいので，新たにMainPageDataのインスタンスを作成 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Main, new MainPageData()));
        }

        /// <summary>
        /// リザルト画面に遷移する処理
        /// 次に遷移する場合はEnterXXXXPageと書く
        /// </summary>
        public void EnterResultPage()
        {
            // MainGameDataにある神のHPとDDをResultPageDataに渡しながら画面遷移を実行
            var damageDone = UniduxCore.State.Page.GetData<MainPageData>().DamageDone;
            // 情報をリザルト画面に引継ぎつつ画面遷移 → Pushでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Push(PageName.Result, new ResultPageData(damageDone)));
        }

        /// <summary>
        /// タイトル画面に遷移する処理
        /// 前に遷移する場合はReturnXXXXPageと書く
        /// </summary>
        public void ReturnTitlePage()
        {
            // タイトル画面に戻る → 前のページに戻る Pop
            var action = PageDuck<PageName, SceneName>.ActionCreator.Pop();
            UniduxCore.Dispatch(action);
        }

        /// <summary>
        /// タイトル画面に遷移する
        /// 全く違う画面に遷移する場合はGoToXXXXPageと書く
        /// </summary>
        public void GoToTitlePage()
        {
            // これまでの情報を破棄してタイトル画面に戻る → Replaceでディスパッチ
            UniduxCore.Dispatch(PageDuck<PageName, SceneName>.ActionCreator.Replace(PageName.Title));
        }
    }
}