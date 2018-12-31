using System;
using GameSystem;

public class MainScene : SceneBase
{
    public MainScene() : base(SceneNames.Main)
    {
    }

    public override void Initialize()
    {
        UISystem.Ins.NewUI<MainUI>();
    }
    
}
