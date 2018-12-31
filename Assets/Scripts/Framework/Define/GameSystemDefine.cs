using UnityEditor;

namespace GameSystem
{
    public static class GameSystemConstDefine
    {
        public const int InitialEventSystemListnerListSize = 10;
        public const string LoadingSceneName = "loading";
        public const string LoadingSceneRootName = "LoadingRoot";
        public static string[] MacrosDefine = { "DEBUG", "TESTMACRO" };
        public static BuildTargetGroup[] BuildTargets = {
            BuildTargetGroup.Android,
            BuildTargetGroup.iOS,
            BuildTargetGroup.Standalone
        };
    }
}
