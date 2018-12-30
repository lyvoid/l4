using GameSystem;

public class StartScene : SceneBase
{

    public StartScene(): base(SceneNames.Start) {
    }

    public override void Initialize()
    {
        UISystem.Ins.NewUI<StartUI>();
    }

    public override void Update()
    {
    }

}