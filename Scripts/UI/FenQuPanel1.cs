using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenQuPanel1 : BasePanel
{
    public Button btnJieshao;
    public Button btnLiucheng;
    public Button btnExist;
    public override void Init()
    {
        btnJieshao.onClick.AddListener(() =>
        {
            //UIMgr.Instance.ShowPanel<YuanLiaoQuJieShaoPanel>();
            UIMgr.Instance.HideMe<FenQuPanel1>();
        });

        btnLiucheng.onClick.AddListener(() =>
        {
            //UIMgr.Instance.ShowPanel<YuanliaoLiuChengPanel>();
            UIMgr.Instance.HideMe<FenQuPanel1>();
        });

        btnExist.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<ScanPanel>();
            UIMgr.Instance.HideMe<FenQuPanel1>();
        });
    }
}
