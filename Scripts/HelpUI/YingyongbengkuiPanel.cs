using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YingyongbengkuiPanel : BasePanel
{

    //关联外部按钮控件
    public Button fanhui;
    public Button xiayiye;

    //同步系统时间
    public Text nowTime;
    public override void Init()
    {
        //监听各个按钮等控件
        fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<HelpPanel>();
            UIMgr.Instance.HideMe<YingyongbengkuiPanel>();
        });

        xiayiye.onClick.AddListener(() =>
        {

        });
    }

    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
