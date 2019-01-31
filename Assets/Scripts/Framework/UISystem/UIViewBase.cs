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
            _RootUILayerHide();
            _rootUI.SetActive(false);
        }

        public virtual void OnShow()
        {
            _RootUILayerShow();
            _rootUI.SetActive(true);
        }

        private void _RootUILayerHide()
        {
            Canvas canvas = _rootUI.GetComponent<Canvas>();
            // if can not find canvas, then dont need do anything
            if (canvas == null) {
                return;
            }
            canvas.overrideSorting = true;
            canvas.sortingOrder = -1;
        }

        private void _RootUILayerShow() {
            Canvas canvas = _rootUI.GetComponent<Canvas>();
            // if can not find canvas, then add a canvas to rootUI
            if (canvas == null)
            {
                canvas = _rootUI.AddComponent<Canvas>();
            }
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100;
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
    }
}
