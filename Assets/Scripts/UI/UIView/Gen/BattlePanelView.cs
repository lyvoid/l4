using GameSystem;
using GameTools;
using UnityEngine.UI;
using UnityEngine;

public partial class BattlePanelView : UIViewBase<BattlePanelController>
{
    private Panel _ButtonsPanel;
    private Panel _testPanel;
    private Button _FirstButton;
    private Button _SecondButton;
    private Button _ThirdButton;
    private Button _FourthButton;

    public override void UIComponentInitialize()
    {
        _ButtonsPanel = UITool.GetUIComponent<Panel>(_rootUI, "UI_Buttons_Panel");
        if (_ButtonsPanel == null) {
            GameObject _ButtonsPanelGO = UITool.FindUIGameObject("UI_Buttons_Panel");
            _ButtonsPanel = _ButtonsPanelGO.AddComponent<Panel>();
        }
        _testPanel = UITool.GetUIComponent<Panel>(_rootUI, "UI_test_Panel");
        if (_testPanel == null) {
            GameObject _testPanelGO = UITool.FindUIGameObject("UI_test_Panel");
            _testPanel = _testPanelGO.AddComponent<Panel>();
        }
        _FirstButton = UITool.GetUIComponent<Button>(_rootUI, "UI_First_Button");
        _SecondButton = UITool.GetUIComponent<Button>(_rootUI, "UI_Second_Button");
        _ThirdButton = UITool.GetUIComponent<Button>(_rootUI, "UI_Third_Button");
        _FourthButton = UITool.GetUIComponent<Button>(_rootUI, "UI_Fourth_Button");
    }
}

        