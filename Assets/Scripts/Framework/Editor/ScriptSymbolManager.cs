using UnityEditor;
using UnityEngine;
using System;
using GameSystem;

public static class ScriptSymbolManager
{
    private static ScriptSymbolManagerWindow window;

    [MenuItem("Tools/ScriptSymbolManager")]
    public static void SymbolManager() 
    {
        if (window == null) {
            window = ScriptableObject.CreateInstance<ScriptSymbolManagerWindow>();
            window.titleContent = new GUIContent("Scripting Symbol Setting");
            window.RestoreData();
            window.Show();
        }
        window.ShowAuxWindow();
    }
}

public class ScriptSymbolManagerWindow : EditorWindow
{
    private const string EditorSavePlatformPref = "EditorSavePlatformPref";
    private const string EditorSaveMacroPref = "EditorSaveMacroPref";
    private bool[] _isPlatformContained = new bool[GameSystemConstDefine.BuildTargets.Length];
    private bool[] _isMacroDefines = new bool[GameSystemConstDefine.MacrosDefine.Length];

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("选择平台");
        EditorGUILayout.BeginVertical("box");
        for (int i = 0; i < _isPlatformContained.Length; i++)
        {
            _isPlatformContained[i] = EditorGUILayout.ToggleLeft(
                Enum.GetName(typeof(BuildTargetGroup), GameSystemConstDefine.BuildTargets[i]),
                _isPlatformContained[i]
            );
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("选择添加或取消的宏");
        EditorGUILayout.BeginVertical("box");
        for(int i = 0; i < _isMacroDefines.Length; i++) 
        {
            _isMacroDefines[i] = EditorGUILayout.ToggleLeft(
                GameSystemConstDefine.MacrosDefine[i], 
                _isMacroDefines[i]
            );
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndVertical();


        if (GUILayout.Button("应用")) {
            for(int i = 0; i < _isPlatformContained.Length; i++)
            {
                if (!_isPlatformContained[i]) continue;
                BuildTargetGroup btg = GameSystemConstDefine.BuildTargets[i];
                for(int j=0; j<_isMacroDefines.Length; j++)
                {
                    string macroStr = GameSystemConstDefine.MacrosDefine[j];
                    if (_isMacroDefines[j])
                    {
                        _AddMacroToPlatform(btg, macroStr);
                    }
                    else
                    {
                        _RemoveMacroFromPlatform(btg, macroStr);
                    }
                }
            }
        }
    }

    public void RestoreData() {
        for (int i = 0; i < _isMacroDefines.Length; i++)
        {
            _isMacroDefines[i] = EditorPrefs.GetBool(EditorSaveMacroPref + i);
        }

        for (int i = 0; i < _isPlatformContained.Length; i++)
        {
            _isPlatformContained[i] = EditorPrefs.GetBool(EditorSavePlatformPref + i);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _isMacroDefines.Length; i++)
        {
            EditorPrefs.SetBool(EditorSaveMacroPref + i, _isMacroDefines[i]);
        }

        for (int i = 0; i < _isPlatformContained.Length; i++) 
        {
            EditorPrefs.SetBool(EditorSavePlatformPref + i, _isPlatformContained[i]);
        }
    }

    private void _AddMacroToPlatform(BuildTargetGroup btg, string simbol)
    {
        string currentSymbolStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(btg);
        string[] currentSymbols = currentSymbolStr.Split(new char[] { ';' });
        string[] newSymbols = new string[currentSymbols.Length + 1];
        for (int i = 0; i < currentSymbols.Length; i++)
        {
            string curSymbol = currentSymbols[i];
            // if simbol already in simbols before
            if (curSymbol == simbol) { return; }
            newSymbols[i] = curSymbol;
        }
        newSymbols[newSymbols.Length - 1] = simbol;
        PlayerSettings.SetScriptingDefineSymbolsForGroup(btg, string.Join(";", newSymbols));
    }

    private void _RemoveMacroFromPlatform(BuildTargetGroup btg, string simbol)
    {
        string currentSymbolStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(btg);
        string[] currentSymbols = currentSymbolStr.Split(new char[] { ';' });
        string[] newSymbols = new string[currentSymbols.Length - 1];
        int j = 0;
        for (int i = 0; i < currentSymbols.Length; i++)
        {
            string curSymbol = currentSymbols[i];
            if (curSymbol == simbol) continue;
            // if j == currentSymbols.Length - 1 means there is no simbol equal to 
            // input in currentSymbols
            if (j == currentSymbols.Length - 1) { return; }
            newSymbols[j] = currentSymbols[i];
            j++;
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(btg, string.Join(";", newSymbols));
    }

}

