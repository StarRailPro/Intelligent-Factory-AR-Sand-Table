using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel1 : BasePanel
{

    public Button btnScan;
    public Button btnSaoma;
    public Button btnAi;
    public Button btnSet;
    public Button btnHepl;

    public Text nowTime;
    public override void Init()
    {
        //读取登录数据
        LoginData loginData = DataMgr.Instance.LoginData;

        btnScan.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<ScanPanel>();
            UIMgr.Instance.HideMe<Panel1>();
        });

        btnSaoma.onClick.AddListener(() =>
        {
            //显示扫码面板
            UIMgr.Instance.ShowPanel<PaneSaoma>();

            //隐藏开始面板
            UIMgr.Instance.HideMe<Panel1>(false);
            if (loginData.isOn && !loginData.saomaCamera)
            {
                //显示相机权限提示面板
                UIMgr.Instance.ShowPanel<PanelHongxian>();
                UIMgr.Instance.ShowPanel<QuanxianPanel>();
            }

            if(DataMgr.Instance.LoginData.saomaCamera)
            {
                //打开AR功能
                UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = true;
                //UIMgr.Instance.GetPanel<FineObjPanel>().imagetarget.SetActive(true);
            }

            

        });

        btnAi.onClick.AddListener(() =>
        {
            //显示AI面板
            UIMgr.Instance.ShowPanel<AIPanel>();


            //UIMgr.Instance.ShowPanel<AIhongxianPanel>();
            //UIMgr.Instance.ShowPanel<AIquanxianPanel>();
            //隐藏开始面板
            UIMgr.Instance.HideMe<Panel1>(false);
            if (loginData.isOn && !loginData.saomaCamera)
            {
                //显示相机权限提示面板
                UIMgr.Instance.ShowPanel<PanelHongxian>();
                UIMgr.Instance.ShowPanel<QuanxianPanel>();
            }

            if (DataMgr.Instance.LoginData.saomaCamera)
            {
                //打开AR功能
                //UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = true;
                //UIMgr.Instance.GetPanel<FineObjPanel>().imagetarget.SetActive(true);
            }

           
        });

        btnSet.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<PanelShezhi>();
            UIMgr.Instance.HideMe<Panel1>();
        });

        btnHepl.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<HelpPanel>();
            UIMgr.Instance.HideMe<Panel1>();
            
        });
    }


    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
