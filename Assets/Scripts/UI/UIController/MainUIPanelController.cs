using GameSystem;

public class MainUIPanelController : UIControllerBase
{
    public void ToBattleScenen()
    {
        SceneSystem.Ins.ChangeToScene(new BattleScene());
    }
}
