using GameSystem;

public class StartUIController : UIControllerBase
{
    public void ToMainScene()
    {
        SceneSystem.Ins.ChangeToScene(new MainScene());
    }
}
