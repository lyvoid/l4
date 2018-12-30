namespace GameSystem
{
    public class UISystem : SystemBase<UISystem>, IUISystem
    {
        public T NewUI<T>() where T : IUI, new()
        {
            T UI = new T();
            UI.Initialize();
            return UI;
        }
    }
}
