using UnityEditor;
using UnityEngine;
using GameTools;
using GameSystem;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

public static class UIGenEditorMenu
{
    private static Transform _panelTransform = null;
    private static HashSet<string> _enabledCompNames = new HashSet<string>{
        "Image", 
        "Text", 
        "Button",
    };
    private static HashSet<string> _enabledCusCompNames = new HashSet<string> {
        "Panel"
    };

    [MenuItem("Tools/UI/Generate Code")]
    public static void GenerateCode()
    {
        GameObject canvas = UITool.GetCanvas();
        if (canvas == null)
        {
            return;
        }
        if (canvas.transform.childCount != 1)
        {
            Debug.LogError("There are no element or more than one element below canvas.");
            EditorUtility.DisplayDialog("代码生成失败", "Cavas下没有或存在多个子物体", "确定");
            return;
        }
        _panelTransform = canvas.transform.GetChild(0);
        string panelName = _panelTransform.name;
        if (!panelName.EndsWith("Panel", System.StringComparison.CurrentCulture))
        {
            Debug.LogError("Must has a panel as parent Object.");
            EditorUtility.DisplayDialog("代码生成失败", "母物体名必须以Panel结尾", "确定");
            return;
        }
        _AddUIPrefabNameDefine(panelName);
        _WriteUIClass(panelName);
        _WriteViewGenClass(panelName);
        _WriteViewExtClass(panelName);
        _WriteControllerClass(panelName);
        AssetDatabase.Refresh();
    }

    private static void _WriteUIClass(string panelName)
    {
        string UIClassPath = UISystemDefine.UIPath + panelName + "UI.cs";
        string content = string.Format(@"using GameSystem;
public class {0}UI : UIBase<{0}View, {0}Controller>
{{
    public {0}UI():base(UIPrefabNames.{0}Name)
    {{
    }}
}}
        ", panelName);
        File.WriteAllText(UIClassPath, content);
        Debug.Log(string.Format("generate {0} successfully", UIClassPath));
    }

    /// <summary>
    /// generate and write code of view class
    /// </summary>
    /// <param name="panelName">Panel name.</param>
    private static void _WriteViewGenClass(string panelName)
    {
        string viewClassPath = UISystemDefine.UIViewGenPath + panelName + "View.cs";

        StringBuilder widgetsDefinedSb = new StringBuilder();
        StringBuilder widgetsFindSb = new StringBuilder();
        // travel all elements below panel, generate tmp code
        LinkedList<Transform> UIWidgets = new LinkedList<Transform>();
        UIWidgets.AddLast(_panelTransform);
        while (UIWidgets.Count > 0)
        {
            var curTransform = UIWidgets.First.Value;
            UIWidgets.RemoveFirst();
            int childCount = curTransform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                UIWidgets.AddLast(curTransform.GetChild(i));
            }
            string elemName = curTransform.name;
            // if current element is start with UI_, generate code
            if (elemName.StartsWith("UI_", StringComparison.CurrentCulture))
            {
                string[] splitNames = elemName.Split(new char[] { '_' });
                if (splitNames.Length < 3)
                {
                    Debug.LogError(string.Format("error format of ui elements {0}, auto pass", elemName));
                    continue;
                }
                string compName = splitNames[splitNames.Length - 1];
                // if component is disabled, skip this ui object
                if (!_enabledCusCompNames.Contains(compName) && !_enabledCompNames.Contains(compName))
                {

                    Debug.LogError(string.Format(
                        "can not generate code of component {0} in element {1}, auto pass",
                        compName,
                        elemName
                    ));
                    continue;
                }

                // if component is enabled
                string[] varibaleSplitName = new string[splitNames.Length - 2];
                for (int i = 0; i < varibaleSplitName.Length; i++)
                {
                    varibaleSplitName[i] = splitNames[i + 1];
                }
                string variableName = "_" + string.Join("_", varibaleSplitName) + compName;
                widgetsFindSb.Append(string.Format(
                    "\n        {0} = UITool.GetUIComponent<{1}>(_rootUI, \"{2}\");",
                    variableName,
                    compName,
                    elemName
                ));
                widgetsDefinedSb.Append(string.Format(
                    "\n    private {0} {1};",
                    compName,
                    variableName
                ));

                // for custom component, if there is no component added before, need to auto add this component in code
                if (_enabledCusCompNames.Contains(compName))
                {
                    widgetsFindSb.Append(string.Format(
                        "\n        if ({0} == null) {{" +
                        "\n            GameObject {0}GO = UITool.FindUIGameObject(\"{2}\");" +
                        "\n            {0} = {0}GO.AddComponent<{1}>();" +
                        "\n        }}",
                        variableName,
                        compName,
                        elemName
                    ));
                }
            }
        }

        string content = string.Format(@"using GameSystem;
using GameTools;
using UnityEngine.UI;
using UnityEngine;

public partial class {0}View : UIViewBase<{0}Controller>
{{{1}

    public override void UIComponentInitialize()
    {{{2}
    }}
}}

        ", panelName, widgetsDefinedSb, widgetsFindSb);
        File.WriteAllText(viewClassPath, content);
        Debug.Log(string.Format("generate {0} successfully", viewClassPath));
    }

    private static void _WriteViewExtClass(string panelName)
    {
        string viewExtClassPath = UISystemDefine.UIViewExtPath + panelName + "ViewExt.cs";
        if (File.Exists(viewExtClassPath)) 
        {
            Debug.Log(string.Format("{0} already exist.", viewExtClassPath));
            return;
        }
        string content = string.Format(@"using GameSystem;
public partial class {0}View : UIViewBase<{0}Controller>
{{
    public override void UIEventInitialize()
    {{
    }}

    public override void CustomRelease()
    {{
    }}
}}

        ", panelName);
        File.WriteAllText(viewExtClassPath, content);
        Debug.Log(string.Format("generate {0} successfully", viewExtClassPath));
    }


    private static void _WriteControllerClass(string panelName)
    {
        string controllerClassPath = UISystemDefine.UIControllerPath + panelName + "Controller.cs";
        if (File.Exists(controllerClassPath))
        {
            Debug.Log(string.Format("{0} already exist.", controllerClassPath));
            return;
        }
        string content = string.Format(@"using GameSystem;

public class {0}Controller : UIControllerBase
{{
}}
", panelName);
        File.WriteAllText(controllerClassPath, content);
        Debug.Log(string.Format("generate {0} successfully", controllerClassPath));
    }

    private static void _AddUIPrefabNameDefine(string panelName)
    {
        string defineLineHead = string.Format("public const string {0}Name = ", panelName);
        string defineContent = File.ReadAllText(UISystemDefine.UIPrefNamesDefPath);

        if (defineContent.Contains(defineLineHead))
        {
            Debug.Log(string.Format("{0} was already defined in {1}", panelName, UISystemDefine.UIPrefNamesDefPath));
            return;
        }
        defineContent = defineContent.Replace("{", "");
        defineContent = defineContent.Replace(
            "public static class UIPrefabNames",
            "public static class UIPrefabNames {\n    " + defineLineHead + "\"" + panelName + "\";"
        );
        File.WriteAllText(UISystemDefine.UIPrefNamesDefPath, defineContent);
        Debug.Log(string.Format("Adding {0} to define file successfully.", panelName));
    }
}