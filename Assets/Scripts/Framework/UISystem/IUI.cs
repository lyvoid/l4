namespace GameSystem
{
    public interface IUI
    {
        bool IsVisible();
        void Show();
        void Hide();
        void Initialize();
        void Release();
        void Update();
    }
}
