using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using GameTools;

namespace GameSystem
{
    public class SceneSystem : SystemBase<SceneSystem>, ISceneSystem
    {

        private IScene _curScene;
        public AsyncOperation AsyncOp { private set; get; }

        public override void Initialize()
        {
            _curScene = new StartScene();
            _curScene.Initialize();
        }


        public override void Update()
        {
            _curScene.Update();
        }

        /// <summary>
        /// Changes to scene.
        /// to loading scene -> beforeScene.release ->
        /// Systems.AfterSceneDestoryed -> unloadunusedasset ->
        /// current scene.preload -> currentscene.initialize ->
        /// destroy loading scene
        /// </summary>
        /// <param name="newScene">New scene.</param>
        public void ChangeToScene(IScene newScene)
        {
            GameRoot.Ins.BeforeSceneDestoryed();
            SceneManager.LoadScene(GameSystemConst.LoadingSceneName);
            _curScene.Release();
            GameRoot.Ins.AfterSceneDestoryed();
            _curScene = newScene;
            GameRoot.Ins.StartCoroutine(_LoadCurScene());
        }

        private IEnumerator _LoadCurScene() {
            // unload resource of before scene
            yield return Resources.UnloadUnusedAssets();
            GameRoot.Ins.BeforeSceneLoaded();
            // load resource of current scene
            yield return _curScene.PreLoad();
            // load to current scene use additive mode
            AsyncOp = SceneManager.LoadSceneAsync(_curScene.SceneName(), LoadSceneMode.Additive);
            yield return AsyncOp;
            // _curScene.Initialize();
            GameRoot.Ins.AfterSceneLoaded();
            AsyncOp = null;
            // destory loading scene
            GameObject loadingRoot = UnityTool.FindGameObject(GameSystemConst.LoadingSceneRootName);
            Object.Destroy(loadingRoot);
        }
    }
}
