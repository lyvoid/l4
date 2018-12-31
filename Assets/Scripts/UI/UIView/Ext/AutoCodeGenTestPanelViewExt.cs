using GameSystem;
using UnityEngine;
public partial class AutoCodeGenTestPanelView : UIViewBase<AutoCodeGenTestPanelController>
{
    public override void UIEventInitialize()
    {
        _testButton.onClick.AddListener(() => { Debug.Log("emmmmm"); });
    }

    public override void CustomRelease()
    {
    }
}

        