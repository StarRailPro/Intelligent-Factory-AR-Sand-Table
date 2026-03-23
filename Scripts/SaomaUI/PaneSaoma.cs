using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaneSaoma : BasePanel
{
    //返回按钮
    public Button fanhui;
    //右上角时间
    public Text nowTime;
    //底部加载文本
    public  Text txtTip;

    //动态红线
    public GameObject HongXian;

    public override void Init()
    {
        txtTip = transform.Find("Text底部提示").GetComponent<Text>();
        HongXian = transform.Find("hongxian").gameObject;

        fanhui.onClick.AddListener(() =>
        {
           UIMgr.Instance.ShowPanel<Panel1>();
           UIMgr.Instance.HideMe<PaneSaoma>();
           UIMgr.Instance.HideMe<QuanxianPanel>();
           UIMgr.Instance.HideMe<PanelHongxian>();

           //退出扫码模块时,关闭AR功能
           UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = false;

        });
    }

    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }


}
