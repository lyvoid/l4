using GameSystem;
using GameTools;
using UnityEngine.UI;
using UnityEngine;

public partial class StartUIPanelView : UIViewBase<StartUIPanelController>
{
    private Button _CloseButton;
    private Button _OpenNewButton;
    private Text _IdentityText;

    public override void UIComponentInitialize()
    {
        _CloseButton = UITool.GetUIComponent<Button>(_rootUI, "UI_Close_Button");
        _OpenNewButton = UITool.GetUIComponent<Button>(_rootUI, "UI_OpenNew_Button");
        _IdentityText = UITool.GetUIComponent<Text>(_rootUI, "UI_Identity_Text");
    }
}

        