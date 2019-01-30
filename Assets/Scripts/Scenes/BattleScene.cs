using GameSystem;

public class BattleScene : SceneBase
{
    public BattleScene() : base(SceneNames.BattleSceneName)
    {
    }

    public override void Initialize()
    {
        UISystem.Ins.NewUI<BattlePanelUI>();
    }

}
