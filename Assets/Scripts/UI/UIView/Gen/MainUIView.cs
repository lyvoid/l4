using GameSystem;
using GameTools;
using UnityEngine.UI;

public partial class MainUIView : UIViewBase<MainUIController>
{
    private Button _toBattleButton;

    public override void UIComponentInitialize()
    {
        _toBattleButton = UITool.GetUIComponent<Button>(_rootUI, "ToBattleButton");
    }

}
