using System.Collections;

namespace GameSystem
{
    public interface IScene
    {
        string SceneName();
        IEnumerator PreLoad();
        void Initialize();
        void Update();
        void Release();
    }
}
