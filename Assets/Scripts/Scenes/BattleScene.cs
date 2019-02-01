using GameSystem;

public class BattleScene : SceneBase
{
    public BattleScene() : base(SceneNames.BattleSceneName)
    {
    }

    public override void Initialize()
    {
        BattlePanelUI battleUI =  UISystem.Ins.NewUI<BattlePanelUI>();
        UISystem.Ins.ShowUI(battleUI);
    }

}
