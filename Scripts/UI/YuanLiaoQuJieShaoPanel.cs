using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuanLiaoQuJieShaoPanel : BasePanel
{
    public Button btnExist;
    public Button btnNextPage;

    public override void Init()
    {
        btnExist.onClick.AddListener(() =>
        {
            
            UIMgr.Instance.HideMe<YuanLiaoQuJieShaoPanel>();
        });

        btnNextPage.onClick.AddListener(() =>
        {

        });
    }
}
