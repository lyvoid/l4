using System.Collections;

namespace GameSystem
{
    public class UISystem : SystemBase<UISystem>, IUISystem
    {

        private Stack _UIStack = new Stack(20);
        public int MaxSortingOrder { get; private set;}

        public T NewUI<T>() where T : IUI, new()
        {
            T UI = new T();
            UI.Initialize();
            return UI;
        }

        /// <summary>
        /// use this function show uipanel can be auto managered in a uistack
        /// </summary>
        /// <param name="UI">uiview need to display</param>
        /// <param name="hideBefore">need hide top uiview in stack or not, defaut value is true</param>
        /// <returns>current top uiview</returns>
        public IUI ShowUI(IUI UI, bool hideBefore = true) {
            if (hideBefore && _UIStack.Count > 0) {
                (_UIStack.Peek() as IUI).Hide();
            }
            MaxSortingOrder++;
            _UIStack.Push(UI);
            UI.Show();
            return UI;
        }

        /// <summary>
        /// hide the top uiview in stack and show the second view
        /// </summary>
        /// <returns>the ui been closed</returns>
        public IUI BackUI() {
            MaxSortingOrder--;
            if (MaxSortingOrder < 0)
            {
                MaxSortingOrder = 0;
            }
            IUI topUI = null;
            if (_UIStack.Count > 0)
            {
                topUI = _UIStack.Pop() as IUI;
                topUI.Hide();
            }
            if (_UIStack.Count > 0) {
                IUI secondUI = _UIStack.Peek() as IUI;
                secondUI.Show();
            }
            return topUI;
        }

        public override void BeforeSceneDestoryed()
        {
            _UIStack.Clear();
            MaxSortingOrder = 0;
        }
    }
}
