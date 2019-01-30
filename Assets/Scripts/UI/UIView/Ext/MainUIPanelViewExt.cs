using GameSystem;
public partial class MainUIPanelView : UIViewBase<MainUIPanelController>
{
    public override void UIEventInitialize()
    {
        _ToBattleButton.onClick.AddListener(_controller.ToBattleScenen);
    }

    public override void CustomRelease()
    {
        _ToBattleButton.onClick.RemoveAllListeners();
    }
}

        