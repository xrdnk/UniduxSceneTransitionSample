using System;
using Unidux.SceneTransition;

namespace Denity.UniduxSceneTransitionSample.PageData
{
    /// <summary>
    /// ゲーム画面用のページデータ
    /// </summary>
    [Serializable]
    public class MainPageData : IPageData
    {
        public double GodHp { get; set; }
        public double DamageDone { get; set; }

        public MainPageData()
        {
            GodHp = 9999;
            DamageDone = 0;
        }

        public MainPageData(double defaultGodHp, double defaultDamageDone)
        {
            GodHp = defaultGodHp;
            DamageDone = defaultDamageDone > 0 ? defaultDamageDone : 0;
        }
    }
}