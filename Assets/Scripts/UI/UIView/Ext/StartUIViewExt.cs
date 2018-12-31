using GameSystem;
using UnityEngine.UI;
using GameTools;

public partial class StartUIView : UIViewBase
{
    public override void InitializeUIEvt()
    {
        _button.onClick.AddListener(() => {
            SceneSystem.Ins.ChangeToScene(new MainScene());
        });
    }
}
