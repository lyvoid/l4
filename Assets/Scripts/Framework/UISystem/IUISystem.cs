namespace GameSystem
{
    public interface IUISystem
    {
        T NewUI<T>() where T : IUI, new();
    }
}
