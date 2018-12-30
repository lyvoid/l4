using GameSystem;
using GameTools;
using UnityEngine.UI;

public class StartUI : UIBase {

    public StartUI():base(UIPrefabNames.StartUIPanel) { }

    private Button button;

    public override void Initialize() {
        button = UITool.GetUIComponent<Button>(_rootUI, "Start");
        button.onClick.AddListener(() => {
            SceneSystem.Ins.ChangeToScene(new StartScene());
        });
    }
}
