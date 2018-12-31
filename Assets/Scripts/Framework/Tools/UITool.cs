using UnityEngine;

namespace GameTools
{
    public static class UITool
    {
        private static GameObject _canvas = null;

        public static GameObject FindUIGameObject(string UIName)
        {
            GetCanvas();
            return UnityTool.FindChildGameObject(_canvas, UIName);
        }

        public static T GetUIComponent<T>(GameObject container, string UIName) where T : UnityEngine.Component
        {
            GameObject childGameObject = UnityTool.FindChildGameObject(container, UIName);
            if (childGameObject == null)
            {
                return null;
            }

            T tmpObj = childGameObject.GetComponent<T>();
            if (tmpObj == null)
            {
                Debug.LogWarning("Component [" + UIName + "] is not [" + typeof(T) + "]");
                return null;
            }
            return tmpObj;
        }

        public static void AddToCanvas(GameObject UI)
        {
            GetCanvas();
            UI.transform.SetParent(_canvas.transform);
            RectTransform rectTransform = UI.GetComponent<RectTransform>();
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
        }

        public static GameObject GetCanvas()
        {
            if (_canvas == null)
            {
                _canvas = UnityTool.FindGameObject("Canvas");
            }
            if (_canvas == null)
            {
                Debug.LogError("can not find canvas in current scene");
            }
            return _canvas;
        }
    }
}
