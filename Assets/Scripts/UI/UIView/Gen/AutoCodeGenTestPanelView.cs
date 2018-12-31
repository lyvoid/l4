using GameSystem;
using GameTools;
using UnityEngine.UI;

public partial class AutoCodeGenTestPanelView : UIViewBase<AutoCodeGenTestPanelController>
{
    private Button _testButton;
    private Image _testImage;
    private Text _testText;

    public override void UIComponentInitialize()
    {
        _testButton = UITool.GetUIComponent<Button>(_rootUI, "UI_test_Button");
        _testImage = UITool.GetUIComponent<Image>(_rootUI, "UI_test_Image");
        _testText = UITool.GetUIComponent<Text>(_rootUI, "UI_test_Text");
    }
}

        