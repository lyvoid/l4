using GameSystem;
using UnityEngine.UI;
using GameTools;

public partial class StartUIView: UIViewBase<StartUIController> {

    private Button _button;

    public override void UIComponentInitialize()
    {
        _button = UITool.GetUIComponent<Button>(_rootUI, "Start");
    }
}
