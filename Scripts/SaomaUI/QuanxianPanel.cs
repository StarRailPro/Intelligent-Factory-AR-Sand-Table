using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class QuanxianPanel : BasePanel
{

    public Button jujue;
    public Button benci;
    public Button shiyongzhong;
   
    public override void Init()
    {
        jujue.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<QuanxianPanel>();
        });

        benci.onClick.AddListener(() =>
        {
            UIMgr.Instance.HideMe<PanelHongxian>();
            UIMgr.Instance.HideMe<QuanxianPanel>();

            //开启AR功能
            UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = true;
           // UIMgr.Instance.GetPanel<FineObjPanel>().imagetarget.SetActive(true);
           
            //记录权限标识
            DataMgr.Instance.LoginData.saomaCamera = true;
            DataMgr.Instance.LoginData.isOn = false;

        });

        shiyongzhong.onClick.AddListener(() =>
        {
            
            UIMgr.Instance.HideMe<PanelHongxian>();
            UIMgr.Instance.HideMe<QuanxianPanel>();

            //开启AR功能
            UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = true;
            //UIMgr.Instance.GetPanel<FineObjPanel>().imagetarget.SetActive(true);

            //记录权限标识
            DataMgr.Instance.LoginData.saomaCamera = true;
            DataMgr.Instance.LoginData.isOn = false;

            //当选择 使用中选项时 才要记录数据
            DataMgr.Instance.SaveLoginData();
        });
        
        
    }
}
