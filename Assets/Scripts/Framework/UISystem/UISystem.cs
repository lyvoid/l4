using System.Collections;

namespace GameSystem
{
    public class UISystem : SystemBase<UISystem>, IUISystem
    {

        private Stack _UIStack = new Stack(20);

        public T NewUI<T>() where T : IUI, new()
        {
            T UI = new T();
            UI.Initialize();
            return UI;
        }

        /// <summary>
        /// use this function show uipanel can be auto managered in a uistack
        /// </summary>
        /// <param name="UIView">uiview need to display</param>
        /// <param name="hideBefore">need hide top uiview in stack or not, defaut value is true</param>
        /// <returns>current top uiview</returns>
        public IUI UIShowInStack(IUI UIView, bool hideBefore = true) {
            if (hideBefore && _UIStack.Count > 0) {
                (_UIStack.Peek() as IUI).Hide();
            }
            _UIStack.Push(UIView);
            UIView.Show();
            return UIView;
        }

        /// <summary>
        /// hide the top uiview in stack and show the second view
        /// </summary>
        /// <returns>current top uiview, if there is no ui in stack, return null</returns>
        public IUI UIHideInStack() {
            IUI topUIView = null;
            if (_UIStack.Count > 0)
            {
                topUIView = _UIStack.Pop() as IUI;
                topUIView.Hide();
            }
            if (_UIStack.Count > 0) {
                IUI secondUIView = _UIStack.Pop() as IUI;
                secondUIView.Show();
            }
            return topUIView;
        }

        public override void BeforeSceneDestoryed()
        {
            _UIStack.Clear();
        }
    }
}
