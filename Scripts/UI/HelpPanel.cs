using System;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : BasePanel
{

    //面板按钮控件
    public Button zhuyao;
    public Button jiaohu;
    public Button banben;
    public Button liulan;
    public Button saoma;
    public Button AIgongneng;
    public Button shezhi;
    public Button ruanjian;
    public Button chukong;
    public Button erweima;
    public Button AIjingdu;
    public Button shipin;
    public Button changjing;
    public Button Fanhui;

    //内部小面板及控件
    private GameObject panel;
    private Button upPage;
    private Button downPage;
    private Button close;
    private Text pageNum;
    private Image imageContent;

    //标记按钮的数字以及图片加载的路径
    private int a;
    private string path;
    private GameObject pageCntro;
    //图片路径加载的尾缀数字
    private string str;

    //记录当前页数
    private int currentPage = 1;
    private int b;
    //同步系统时间
    public Text nowTime;
    public override void Init()
    {
        panel = transform.Find("Panel").gameObject;
        pageCntro = panel.transform.Find("pageCntro").gameObject;
        upPage = pageCntro.transform.Find("Button上一页").GetComponent<Button>();
        downPage = pageCntro.transform.Find("Button下一页").GetComponent<Button>();
        close = panel.transform.Find("Button返回").GetComponent<Button>();
        imageContent = panel.transform.Find("ImagContent").GetComponent<Image>();
        pageNum = pageCntro.transform.Find("Text页数").GetComponent<Text>();

        zhuyao.onClick.AddListener(() =>
        {
            ShowImageContent(1, imageContent);
            pageCntro.SetActive(true);
        });

        jiaohu.onClick.AddListener(() =>
        {
            ShowImageContent(2, imageContent);
            pageCntro.SetActive(true);
        });

        banben.onClick.AddListener(() =>
        {
            ShowImageContent(3, imageContent);
        });

        liulan.onClick.AddListener(() =>
        {
            ShowImageContent(4, imageContent);
            pageCntro.SetActive(true);
        });

        saoma.onClick.AddListener(() =>
        {
            ShowImageContent(5, imageContent);
            pageCntro.SetActive(true);
        });

        AIgongneng.onClick.AddListener(() =>
        {
            ShowImageContent(6, imageContent);
        });

        shezhi.onClick.AddListener(() =>
        {
            ShowImageContent(7,imageContent);
            pageCntro.SetActive(true);
        });

        ruanjian.onClick.AddListener(() =>
        {
            ShowImageContent(8, imageContent);
        });

        chukong.onClick.AddListener(() =>
        {
            ShowImageContent(9, imageContent);
        });

        erweima.onClick.AddListener(() =>
        {
            ShowImageContent(10, imageContent);
        });

        AIjingdu.onClick.AddListener(() =>
        {
            ShowImageContent(11, imageContent);
        });

        shipin.onClick.AddListener(() =>
        {
            ShowImageContent(12, imageContent);
        });

        changjing.onClick.AddListener(() =>
        {
            ShowImageContent(13, imageContent);
        });

        Fanhui.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Panel1>();
            UIMgr.Instance.HideMe<HelpPanel>();
        });

        //小面板关闭按钮
        close.onClick.AddListener(() => 
        {
            panel.SetActive(false);
            pageCntro.SetActive(false);
            currentPage = 1;
        });
        
        upPage.onClick.AddListener(() => 
        {
            currentPage--;
            ShowPageContent(path);
            
        });

        downPage.onClick.AddListener(() =>
        {
            currentPage++;
            ShowPageContent(path);
            
        });
    }

    /// <summary>
    /// 切换页面的函数
    /// </summary>
    /// <param name="str"></param>
    private void ShowPageContent(string str)
    {
        if(currentPage > b)
        {
            currentPage = 1; 
        }
        if(currentPage < 1)
        {
            currentPage = b;
        }
        string path = str + currentPage;
        imageContent.sprite = GameObject.Instantiate(Resources.Load<Sprite>(path));
        pageNum.text = currentPage + "/"+b;
    }

/// <summary>
/// 加载图文内容的函数
/// </summary>
/// <param name="a">按钮标识</param>
/// <param name="image"></param>
    private void ShowImageContent(int a,Image image)
    {
        switch(a)
        {
            case 1:
                path = "help/zhuyao";
                pageNum.text = "1/3";
                b = 3;
                str = "1";
                break;
            case 2:
                path = "help/jiaohu";
                pageNum.text = "1/2";
                b = 2;
                str = "1";
                break;
            case 3:
                path = "help/banben";
                str = "";
                break;
            case 4:
                path = "help/liulan";
                pageNum.text = "1/3";
                b = 3;
                str = "1";    
                break;
            case 5:
                path = "help/saoma";
                pageNum.text = "1/2";
                b = 2;
                str = "1";
                break;
            case 6:
                path = "help/AIgongneng";
                pageNum.text = "1/2";
                b = 2;
                str = "1";
                break;
            case 7:
                path = "help/shezhi";
                pageNum.text = "1/3";
                b = 3;
                str = "1";
                break;
            case 8:
                path = "help/ruanjian";
                str = "";    
                break;
            case 9:
                path = "help/chukong";
                str = "";
                break;
            case 10:
                path = "help/erweima";
                str = "";
                break;
            case 11:
                path = "help/AIjingdu";
                str = "";
                break;
            case 12:
                path = "help/shipin";
                str = "";
                break;
            case 13:
                path = "help/changjing";
                str = "";
                break;
        }
        image.sprite = GameObject.Instantiate(Resources.Load<Sprite>(path+str));
        panel.SetActive(true);
    }
    protected override void Update()
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
