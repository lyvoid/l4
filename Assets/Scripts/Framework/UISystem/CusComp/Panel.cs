using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public virtual void Hide() {
        this.enabled = false;
    }

    public virtual void Show() {
        this.enabled = true;
    }
}
