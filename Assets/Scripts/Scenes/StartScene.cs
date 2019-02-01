using GameSystem;

public class StartScene : SceneBase
{

    public StartScene(): base(SceneNames.StartSceneName) {
    }

    public override void Initialize()
    {
        StartUIPanelUI startUIPanelUI = UISystem.Ins.NewUI<StartUIPanelUI>();
        UISystem.Ins.ShowUI(startUIPanelUI);
    }

}