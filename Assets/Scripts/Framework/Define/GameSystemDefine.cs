using System.Collections.Generic;

namespace GameSystem
{
    public static class GameSystemConst
    {
        public const int InitialEventSystemListnerListSize = 10;
        public const string LoadingSceneName = "loading";
        public const string LoadingSceneRootName = "LoadingRoot";

        public static Dictionary<ResType, string> ResPath = new Dictionary<ResType, string>{
            {ResType.UIPrefab, "UIPrefab/"},
        };
    }

    public enum ResType
    {
        UIPrefab,
    }
}
