using UnityEngine.EventSystems;

namespace Denity.UniduxSceneTransitionSample.View
{
    public abstract class UIViewBase : UIBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}