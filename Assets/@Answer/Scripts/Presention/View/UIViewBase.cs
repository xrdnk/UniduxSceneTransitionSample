using UnityEngine.EventSystems;

namespace Denity.UniduxSceneTransitionSample.Answer.View
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