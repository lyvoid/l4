using UnityEngine;
using GameTools;

namespace GameSystem
{
    public abstract class UIBase : IUI
    {
        protected bool _isActive = true;
        protected GameObject _rootUI = null;

        protected UIBase(string UIName) {
            ResSystem.Ins.LoadRes(UIName, ResType.UIPrefab);
            _rootUI = Object.Instantiate(ResSystem.Ins.GetPrefab(UIName));
            UITool.AddToCanvas(_rootUI);
        }

        public virtual void Hide()
        {
            _rootUI.SetActive(false);
            _isActive = false;
        }

        public virtual void Show()
        {
            _rootUI.SetActive(true);
            _isActive = true;
        }

        public bool IsVisible()
        {
            return _isActive;
        }


        public virtual void Update() { }
        public virtual void Initialize() { }
        public virtual void Release() { }

    }
}
