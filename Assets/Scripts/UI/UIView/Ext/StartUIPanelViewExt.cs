using GameSystem;
public partial class StartUIPanelView : UIViewBase<StartUIPanelController>
{
    public override void UIEventInitialize()
    {
        _StartButton.onClick.AddListener(_controller.ToMainScene);
    }

    public override void CustomRelease()
    {
        _StartButton.onClick.RemoveAllListeners();
    }
}

        