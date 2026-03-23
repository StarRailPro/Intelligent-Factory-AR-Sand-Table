using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SbPannel1 : BasePanel
{
    public Button zuixiaohau;
    public Button huanyuan;
    public Button guanbi;

    public Button tuwen;
    public Button shiping;
    public override void Init()
    {
        zuixiaohau.onClick.AddListener(() =>
        {

        });

        huanyuan.onClick.AddListener(() =>
        {

        });

        guanbi.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Xianshihongxian>();
            UIMgr.Instance.HideMe<SbPannel1>();   
        });

        tuwen.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<YuanLiaoQuJieShaoPanel>();
        });

        shiping.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<YuanliaoLiuChengPanel>();
        });
    }
}
