using GameSystem;
using UnityEngine.UI;
using GameTools;

public partial class StartUIView: UIViewBase {

    private Button _button;

    public override void InitializeUIComp()
    {
        _button = UITool.GetUIComponent<Button>(_rootUI, "Start");
    }
}
