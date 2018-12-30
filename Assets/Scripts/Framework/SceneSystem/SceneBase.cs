using System.Collections;

namespace GameSystem
{
    /// <summary>
    /// to loading scene by unity -> other scene class.release -> 
    /// unload unused resouce -> current class.constructor -> 
    /// current class.preload -> load scene by unity -> current class.initialize
    /// </summary>
    public abstract class SceneBase : IScene
    {

        private readonly string _sceneName;

        protected SceneBase(string sceneName)
        {
            _sceneName = sceneName;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Release()
        {
        }

        /// <summary>
        /// the reason to use this function instead of get and set is to 
        /// ensure that there is a function to get scenename 
        /// defined in the IScene interface
        /// </summary>
        /// <returns></returns>
        public string SceneName()
        {
            return _sceneName;
        }

        public virtual void Update()
        {
        }

        public virtual IEnumerator PreLoad()
        {
            yield return null;
        }
    }
}