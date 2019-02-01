using GameSystem;
public partial class BattlePanelView : UIViewBase<BattlePanelController>
{
    public override void UIEventInitialize()
    {
        _FirstButton.onClick.AddListener(() =>
        {
            UISystem.Ins.ShowUI((UISystem.Ins.NewUI<StartUIPanelUI>()));
        });
        _SecondButton.onClick.AddListener(() =>
        {
            UISystem.Ins.BackUI();
        });
        _ThirdButton.onClick.AddListener(() =>
        {
            _ButtonsPanel.Hide();
        });
    }

    public override void CustomRelease()
    {
    }
}

        