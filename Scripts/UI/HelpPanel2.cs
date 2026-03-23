using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel2 : BasePanel
{
    public Button wufa;
    public Button AIshibie;
    public Button Yingyong;
    public Button dianzi;
    public Button shejiao;
    public Button zhuyao;
    public Button yongtu;
    public Button shiyong;
    public Button xinbanben;
    public Button jiancha;

    public Button sahngyiye;
    public Button fanhui;

    //同步系统时间
    public Text nowTime;
    public override void Init()
    {
        wufa.onClick.AddListener(() =>
        {

        });

        AIshibie.onClick.AddListener(() =>
        {

        });

        Yingyong.onClick.AddListener(() =>
        {

        });

        dianzi.onClick.AddListener(() =>
        {

        });

        shejiao.onClick.AddListener(() =>
        {

        });

        zhuyao.onClick.AddListener(() =>
        {

        });

        yongtu.onClick.AddListener(() =>
        {

        });

        shiyong.onClick.AddListener(() =>
        {

        });

        xinbanben.onClick.AddListener(() =>
        {

        });

        jiancha.onClick.AddListener(() =>
        {

        });

        fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Panel1>();
            UIMgr.Instance.HideMe<HelpPanel2>();
        });

        sahngyiye.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<HelpPanel>();
            UIMgr.Instance.HideMe<HelpPanel2>();
        });
    }

    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
