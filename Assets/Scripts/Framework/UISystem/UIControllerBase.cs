using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public abstract class UIControllerBase : IUIController
    {
        public virtual void Initialize()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void Update()
        {
        }
    }
}
