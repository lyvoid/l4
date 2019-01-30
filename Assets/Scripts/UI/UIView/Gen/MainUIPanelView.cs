using GameSystem;
using GameTools;
using UnityEngine.UI;

public partial class MainUIPanelView : UIViewBase<MainUIPanelController>
{
    private Button _ToBattleButton;

    public override void UIComponentInitialize()
    {
        _ToBattleButton = UITool.GetUIComponent<Button>(_rootUI, "UI_ToBattle_Button");
    }
}

        