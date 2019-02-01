using UnityEngine;
using GameTools;

namespace GameSystem
{
    public abstract class UIBase<T, V> : IUI where T : IUIView, new() where V : IUIController, new()
    {
        protected bool _isActive = true;
        protected T _view;
        protected V _controller;

        protected UIBase(string UIName)
        {
            ResSystem.Ins.LoadRes(UIName, ResType.UIPrefab);
            GameObject rootUI = Object.Instantiate(ResSystem.Ins.GetPrefab(UIName));
            _view = new T();
            _controller = new V();
            _view.SetRootUI(rootUI);
            _view.SetController(_controller);
            UITool.AddToCanvas(rootUI);
            rootUI.SetActive(false);
        }

        public void Hide()
        {
            _view.OnHide();
            _isActive = false;
        }

        public void Show()
        {
            _view.OnShow();
            _isActive = true;
        }

        public bool IsVisible()
        {
            return _isActive;
        }

        public virtual void CustomUpdate()
        {
        }

        private void BaseUpdate() 
        {
            _controller.Update();
            _view.Update(); 
        }

        public void Update()
        {
            BaseUpdate();
            CustomUpdate();
        }

        public virtual void CustomInitialize()
        {

        }

        private void BaseInitialize() 
        {
            _controller.Initialize();
            _view.Initialize();
        }

        public void Initialize()
        {
            BaseInitialize();
            CustomInitialize();
        }

        public virtual void CustomRelease()
        {
        }

        private void BaseRelease()
        {
            if (_controller.Equals(default))
            {
                _controller.Release();
                this._controller = default;
            }
            if (_view.Equals(default))
            {
                _view.Release();
                this._view = default;
            }
        }

        public void Release()
        {
            CustomRelease();
            BaseRelease();
        }
    }
}
