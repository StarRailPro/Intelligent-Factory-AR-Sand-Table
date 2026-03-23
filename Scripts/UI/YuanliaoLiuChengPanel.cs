using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuanliaoLiuChengPanel : BasePanel
{

    public Button btnExist;
    public Button btnNextPage;
    public override void Init()
    {
        btnExist.onClick.AddListener(() =>
        {
            
            UIMgr.Instance.HideMe<YuanliaoLiuChengPanel>();
        });

        btnExist.onClick.AddListener(() =>
        {

        });
    }
}
