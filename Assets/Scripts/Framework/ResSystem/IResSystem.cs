using System.Collections;
using UnityEngine;

namespace GameSystem
{
    public interface IResSystem
    {
        GameObject GetPrefab(string prefabName);
        IEnumerator AsyncLoadRes(string resName, ResType type, bool isGlobal=false);
        void LoadRes(string resName, ResType type, bool isGlobal=false);
        void ClearCache();
        void ClearCache(string resName);
    }

}
