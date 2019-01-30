using GameSystem;

public class StartUIPanelController : UIControllerBase
{
    public void ToMainScene() {
        SceneSystem.Ins.ChangeToScene(new MainScene());
    }
}
