using GameSystem;

public class MainScene : SceneBase
{
    public MainScene() : base(SceneNames.MainSceneName)
    {
    }

    public override void Initialize()
    {
        UISystem.Ins.NewUI<MainUIPanelUI>();
    }
    
}
