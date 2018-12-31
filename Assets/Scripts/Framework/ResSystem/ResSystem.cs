using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    /// <summary>
    /// This class only load resource from Resource folder. 
    /// (I just want to make a single player game. It may not need asset bundle tools.)
    /// Resource loaded will be release after scene been destroyed except global res.
    /// </summary>
    public class ResSystem : SystemBase<ResSystem>, IResSystem
    {

        private Dictionary<string, Object> _resCache = new Dictionary<string, Object>();
        private Dictionary<string, Object> _globalResCache = new Dictionary<string, Object>();

        public GameObject GetPrefab(string prefabName)
        {
            if (_resCache.ContainsKey(prefabName))
                return (GameObject)_resCache[prefabName];
            if (_globalResCache.ContainsKey(prefabName))
                return (GameObject)_globalResCache[prefabName];
            Debug.LogError("get prefab [" + prefabName + "] before load");
            return null;
        }


        public IEnumerator AsyncLoadRes(string resName, ResType resType, bool isGlobal = false)
        {
            Dictionary<string, Object> resCache = isGlobal ? _globalResCache : _resCache;
            if (resCache.ContainsKey(resName))
                yield return null;
            else {
                var r = Resources.LoadAsync(_GetResComplName(resName, resType));
                yield return r;
                var loadRes = r.asset;
                if (loadRes == null)
                {
                    Debug.LogError("can not load res [" + resName + "]");
                }
                else
                {
                    resCache[resName] = loadRes;
                }
            }
        }

        /// <summary>
        /// clear cache named `resName`
        /// </summary>
        /// <param name="resName"></param>
        public void ClearCache(string resName) {
            if (_resCache.ContainsKey(resName)) {
                _resCache.Remove(resName);
            }
            if (_globalResCache.ContainsKey(resName)) {
                _globalResCache.Remove(resName);
            }
        }

        /// <summary>
        /// clear all cache except global resource
        /// </summary>
        public void ClearCache()
        {
            _resCache.Clear();
        }

        public void LoadRes(string resName, ResType resType, bool isGlobal = false)
        {
            Dictionary<string, Object> resCache = isGlobal ? _globalResCache : _resCache;
            if (resCache.ContainsKey(resName))
            {
                Debug.Log(resName + " already loaded before.");
                return;
            }
            var loadRes = Resources.Load(_GetResComplName(resName, resType));
            if (loadRes == null) {
                Debug.LogError("can not load res [" + resName + "]");
                return;
            }
            resCache[resName] = loadRes;
        }

        private string _GetResComplName(string resName, ResType resType) {
            return ResSystemDefine.ResPath[resType] + resName;
        }

        public override void AfterSceneDestoryed()
        {
            ClearCache();
        }
    }
}
