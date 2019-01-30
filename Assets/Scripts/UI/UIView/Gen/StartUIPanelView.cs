using GameSystem;
using GameTools;
using UnityEngine.UI;

public partial class StartUIPanelView : UIViewBase<StartUIPanelController>
{
    private Button _StartButton;

    public override void UIComponentInitialize()
    {
        _StartButton = UITool.GetUIComponent<Button>(_rootUI, "UI_Start_Button");
    }
}

        