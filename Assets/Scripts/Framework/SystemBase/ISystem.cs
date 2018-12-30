namespace GameSystem
{
    public interface ISystem
    {
        void Update();
        void Initialize();
        void BeforeSceneLoaded();
        void AfterSceneDestoryed();
        void BeforeSceneDestoryed();
        void AfterSceneLoaded();
    }
}
