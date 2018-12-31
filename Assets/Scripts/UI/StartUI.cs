using GameSystem;
using GameTools;

public class StartUI : UIBase<StartUIView, StartUIController>
{
    public StartUI():base(UIPrefabNames.StartUIPanel) 
    {
        UISystem.Ins.NewUI<AutoCodeGenTestPanelUI>();

    }
}
