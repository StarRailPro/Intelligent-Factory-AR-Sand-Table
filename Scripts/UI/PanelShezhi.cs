using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelShezhi : BasePanel
{
    //面板上的各个按钮控件
    public Button btnDenglu;
    public Button btnShense;
    public Button btnGeren;
    public Button btnYingyong;
    public Button btnXunwen;
    public Button btnZidong;
    public Button btnJingyin;
    public Button btnPingmu;
    public Button btnShiping;

    public Toggle zidong;
    public Toggle xunwen;
    public Toggle yingyong;
    public Toggle yansemoshi;
    public Toggle jinyingmoshi;
    public Slider musiValue;//通知音量
    public Slider sounValue;//媒体音量
    public Button btnKaifazhe;
    public Button btnExist;

    //个人资料小面板及相关控件
    private GameObject PsDataPanel;
    private Button psClose;

    //屏幕分辨率小面板及相关控件
    private GameObject ScreenRePanel;
    private Button re2800;
    private Button re2560;
    private Button re1920;
    private Button re1280;
    private Button reClose;
    private Button btnApply;
    private Button btnCancel;

    //同步系统时间
    public Text nowTime;

    public override void Init()
    {
        PsDataPanel = transform.Find("GerenziliaoPanel").gameObject;
        psClose=PsDataPanel.transform.Find("Button返回").GetComponent<Button>();

        ScreenRePanel = transform.Find("PingmuPanel").gameObject;
        re2800 = ScreenRePanel.transform.Find("Button2800").GetComponent<Button>();
        re2560 = ScreenRePanel.transform.Find("Button2560").GetComponent<Button>();
        re1920 = ScreenRePanel.transform.Find("Button1920").GetComponent<Button>();
        re1280 = ScreenRePanel.transform.Find("Button1280").GetComponent<Button>();
        reClose = ScreenRePanel.transform.Find("Button返回").GetComponent<Button>();
        btnApply = ScreenRePanel.transform.Find("Button应用").GetComponent<Button>();
        btnCancel = ScreenRePanel.transform.Find("Button取消").GetComponent <Button>();

        btnDenglu.onClick.AddListener(() =>
        {

        });

        btnShense.onClick.AddListener(() =>
        {

        });

        btnGeren.onClick.AddListener(() =>
        {
            PsDataPanel.SetActive(true);
        });

        btnYingyong.onClick.AddListener(() =>
        {

        });

        btnXunwen.onClick.AddListener(() =>
        {

        });

        btnZidong.onClick.AddListener(() =>
        {

        });

        btnJingyin.onClick.AddListener(() =>
        {

        });

        btnPingmu.onClick.AddListener(() =>
        {
            ScreenRePanel.SetActive(true);
        });

        btnShiping.onClick.AddListener(() =>
        {

        });

        btnKaifazhe.onClick.AddListener(() =>
        {


        });

        btnExist.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Panel1>();
            UIMgr.Instance.HideMe<PanelShezhi>();
        });

        zidong.onValueChanged.AddListener((ison) =>
        {
            if(ison)
                xunwen.isOn=false;
            
            DataMgr.Instance.LoginData.saomaCamera=ison;
            //存储数据
            DataMgr.Instance.SaveLoginData();
        });

        xunwen.onValueChanged.AddListener((ison) =>
        {
            if(ison)
                zidong.isOn=false;  
            
            DataMgr.Instance.LoginData.isOn=ison;
            //存储数据
            DataMgr.Instance.SaveLoginData();
        });

        //个人资料面板控件监听
        psClose.onClick.AddListener(() =>
        {
            PsDataPanel.SetActive(false);
        });
        //通知音量控制条
        musiValue.onValueChanged.AddListener((s) =>
        {
            DataMgr.Instance.MusiData.BkValue = s;
            DataMgr.Instance.SaveVisualData();
        });
        //媒体音量控制条
        sounValue.onValueChanged.AddListener((s) =>
        {
            DataMgr.Instance.MusiData.SoundValue = s;
            DataMgr.Instance.SaveMusiData();
        });

        //屏幕分辨率面板控件监听
        re2800.onClick.AddListener(() => { });
        re2560.onClick.AddListener(() => { });
        re1920.onClick.AddListener(() => { });
        re1280.onClick.AddListener(() => { });
        reClose.onClick.AddListener(() => { ScreenRePanel.SetActive(false); });
        btnApply.onClick.AddListener(() => { });
        btnCancel.onClick.AddListener(() => { });
        
    }

    public override void Show()
    {
        base.Show();
        //得到数据
        LoginData loginData= DataMgr.Instance.LoginData;
        MusiData musiData = DataMgr.Instance.MusiData;//读取音量数据
        //初始化面板显示
        zidong.isOn = loginData.saomaCamera;
        xunwen.isOn = loginData.isOn;
        sounValue.value = musiData.SoundValue;
        musiValue.value = musiData.BkValue;
    }

    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
