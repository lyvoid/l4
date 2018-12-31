using UnityEngine;

namespace GameSystem
{
    public interface IUIView
    {
        void SetRootUI(GameObject rootUI);
        void SetController(IUIController controller);
        void Initialize();
        void Update();
        void Release();
        void OnShow();
        void OnHide();
    }
}
