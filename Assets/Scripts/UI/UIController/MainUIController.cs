using GameSystem;

public class MainUIController : UIControllerBase
{
    public void ToBattleScene()
    {
        SceneSystem.Ins.ChangeToScene(new MainScene());
    }
}
