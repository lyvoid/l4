using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public abstract class UIViewBase<T>: IUIView where T: IUIController{
        protected GameObject _rootUI;
        protected T _controller;

        public void Initialize()
        {
            UIComponentInitialize();
            UIEventInitialize();
            CustomInitialize();
        }

        public virtual void UIComponentInitialize() 
        { 
        }

        public virtual void UIEventInitialize() 
        { 
        }

        public virtual void CustomInitialize() {  }

        public virtual void OnHide()
        {
            _rootUI.SetActive(false);
        }

        public virtual void OnShow()
        {
            _rootUI.SetActive(true);
            _ToTopOrder();
        }

        protected void _ToTopOrder() {
            Canvas canvas = _rootUI.GetComponent<Canvas>();
            // if can not find canvas, then add a canvas to rootUI
            if (canvas == null)
            {
                canvas = _rootUI.AddComponent<Canvas>();
            }
            canvas.overrideSorting = true;
            canvas.sortingOrder = UISystem.Ins.MaxSortingOrder;
            _EnableTouch();
        }

        public virtual void CustomRelease()
        {
        }

        private void BaseRelease()
        {
            this._rootUI = null;
            this._controller = default;
        }

        public void Release() 
        {
            CustomRelease();
            BaseRelease();
        }


        public void SetRootUI(GameObject rootUI)
        {
            _rootUI = rootUI;
        }

        public virtual void Update()
        {
        }

        void IUIView.SetController(IUIController controller)
        {
            _controller = (T)controller;
        }

        protected void _DisableTouch()
        {
            GraphicRaycaster raycaster = _rootUI.GetComponent<GraphicRaycaster>();
            // disable raycaster to save performance
            if (raycaster != null)
            {
                raycaster.enabled = false;
            }
        }

        protected void _EnableTouch()
        {
            GraphicRaycaster raycaster = _rootUI.GetComponent<GraphicRaycaster>();
            if (raycaster == null)
            {
                raycaster = _rootUI.AddComponent<GraphicRaycaster>();
            }
            raycaster.enabled = true;
        }
    }
}
