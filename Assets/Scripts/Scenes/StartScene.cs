using GameSystem;

public class StartScene : SceneBase
{

    public StartScene(): base(SceneNames.StartSceneName) {
    }

    public override void Initialize()
    {
        UISystem.Ins.NewUI<StartUI>();
    }

}