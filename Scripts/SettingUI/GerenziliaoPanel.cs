using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenziliaoPanel : BasePanel
{
    public Button fanhui;
    public override void Init()
    {
        fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<GerenziliaoPanel>();
        });
    }
}
