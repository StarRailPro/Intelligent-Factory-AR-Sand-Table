
using System;
using UnityEngine;
using UnityEngine.UI;

public class VisualPanel : BasePanel
{
    public Button btn;
    public Button btnInput;
    public Button btnOutput;
    public GameObject chartInput;
    public GameObject chartOutput;
    public Text nowTime;
    public override void Init()
    {
        btn.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<ScanPanel>();
            UIMgr.Instance.HideMe<VisualPanel>();
        });

        btnInput.onClick.AddListener(() =>
        {
            chartInput.SetActive(true);
            chartOutput.SetActive(false);
        });

        btnOutput.onClick.AddListener(() => 
        {
            chartOutput.SetActive(true);
            chartInput.SetActive(false);
        });
    }
    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
