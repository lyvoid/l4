using GameSystem;
using UnityEngine.UI;
using GameTools;

public partial class StartUIView : UIViewBase<StartUIController>
{
    public override void UIEventInitialize()
    {
        _button.onClick.AddListener(_controller.ToMainScene);
    }

    public override void CustomRelease()
    {
        _button.onClick.RemoveAllListeners();
    }
}
