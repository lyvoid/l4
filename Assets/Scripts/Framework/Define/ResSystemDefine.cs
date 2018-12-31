using System.Collections.Generic;

namespace GameSystem
{
    public enum ResType
    {
        UIPrefab,
    }

    public static class ResSystemDefine
    {
        public static Dictionary<ResType, string> ResPath = new Dictionary<ResType, string>{
            {ResType.UIPrefab, "UIPrefab/"},
        };
    }
}
