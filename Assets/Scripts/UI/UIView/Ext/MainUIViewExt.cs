using GameSystem;

public partial class MainUIView : UIViewBase<MainUIController>
{
    public override void UIEventInitialize()
    {
        _toBattleButton.onClick.AddListener(_controller.ToBattleScene);
    }

    public override void CustomRelease()
    {
        _toBattleButton.onClick.RemoveAllListeners();
    }
}
