using System;
using UnityEngine;
using UnityEngine.UI;

public class AIPanel : BasePanel
{
    public Button fanhui;

    //同步系统时间
    public Text nowTime;
    public override void Init()
    {
        fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Panel1>();
            UIMgr.Instance.HideMe<AIPanel>();

            //关闭相机权限提示面板
            UIMgr.Instance.HideMe<QuanxianPanel>();
            UIMgr.Instance.HideMe<PanelHongxian>();
            //UIMgr.Instance.HideMe<AIquanxianPanel>();
            //UIMgr.Instance.HideMe<AIhongxianPanel>();

            //关闭AR功能
            //UIMgr.Instance.GetPanel<FineObjPanel>().vuforiaBehaviour.enabled = false;
        });
    }

    /// <summary>
    /// 显示内容的函数
    /// </summary>
    /// <param name="id"></param>
    public void ShowContent(int id)
    {

    }

    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
