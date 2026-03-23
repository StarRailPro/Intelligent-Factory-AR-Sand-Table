using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class ScanPanel : BasePanel
{
    //关联外部各个按钮控件
    public Button btnZong;//总览图
    public Button btnShengcanliucheng;//生产流程
    public Button btnYuanliao;//原料区
    public Button btnHunliao;//混料区
    public Button btnJichuqu;//挤出区
    public Button btnGanzao;//干燥区
    public Button btnShaocheng;//烧成区
    public Button btnQiege;//切割区
    public Button btnBaozhuang;//包装区
    public Button btnCangchu;//仓储区
    public Button btnExist;//返回按钮
    public Button btnVisu;//工厂数据可视化

    private bool isShowBtnAudio = true;//记录是否显示音频播放按钮的标识

    private int b;//分区按钮标记

    public Text PanelName;//面板名字
    public GameObject panel;//分区小面板
    public Button Fenquclose;//分区关闭按钮
    public Button Fenquintroduce;//图文介绍按钮
    public Button Fenquvideo;//视频播放按钮

    public Image imageContent;
    public RawImage videoContent;

    public Button btnImageClose;
    public Button btnAudio;
    public Button btnVideoClose;

    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private bool isAudio;

    //同步系统时间
    public Text nowTime;
    
    public override void Init()
    {

        //初始化视频和音频的音量
        audioSource.volume = DataMgr.Instance.MusiData.SoundValue;
        videoPlayer.SetDirectAudioVolume(0, DataMgr.Instance.MusiData.SoundValue);

        //按钮控件监听
        #region 
        btnZong.onClick.AddListener(() =>
        {
            b = 1;
            ShowImage(b);

            //隐藏音频按钮，将标识置为false
            if(isShowBtnAudio)
            {
                btnAudio.gameObject.SetActive(false);
                isShowBtnAudio = false;
            }

        });

        btnShengcanliucheng.onClick.AddListener(() =>
        { 
            ShowVideo(1);
        });

        btnYuanliao.onClick.AddListener(() =>
        {
            
            ShowPart(btnYuanliao.name, panel);
            b = 2;
        });

        btnHunliao.onClick.AddListener(() =>
        {
            
            ShowPart(btnHunliao.name, panel);
            b = 3;
        });

        btnJichuqu.onClick.AddListener(() =>
        {
            
            ShowPart(btnJichuqu.name, panel);
            b = 4;
        });

        btnGanzao.onClick.AddListener(() =>
        {
            
            ShowPart(btnGanzao.name, panel);
            b = 5;
        });

        btnQiege.onClick.AddListener(() =>
        {
            
            ShowPart(btnQiege.name, panel);
            b = 7;
        });

        //btnCangchu.onClick.AddListener(() =>
        //{
        //    ShowPart(btnCangchu.name, panel);
        //    b = 9;
        //});

        btnShaocheng.onClick.AddListener(() =>
        {
            
            ShowPart(btnShaocheng.name, panel);
            b = 6;
        });

        //btnBaozhuang.onClick.AddListener(() =>
        //{
            
        //    ShowPart(btnBaozhuang.name, panel);
        //    b = 8;
        //});

        btnExist.onClick.AddListener(() =>
        {
            UIMgr.Instance.ShowPanel<Panel1>();
            UIMgr.Instance.HideMe<ScanPanel>();

        });

        //分区图文介绍按钮
        Fenquintroduce.onClick.AddListener(() =>
        {
            //显示对应分区的图文介绍
            ShowImage(b);

            if(!isShowBtnAudio)
            {
                btnAudio.gameObject.SetActive(true);
                isShowBtnAudio = true;
            }

        });

        //图文介绍音频播放按钮
        btnAudio.onClick.AddListener(() =>
        {
            //播放对应分区的音频
            PlayAudio(DataMgr.Instance.resourcesInfos[b - 1].audioPath);  
        });

        //分区视频播放按钮
        Fenquvideo.onClick.AddListener(() =>
        {
            //显示并播放对应分区的视频介绍
            ShowVideo(b);
        });

        //图文介绍关闭按钮
        btnImageClose.onClick.AddListener(() =>
        {
            //若此时音频按钮处于隐藏状态，则将它显示，并将标识置为true
            imageContent.gameObject.SetActive(false);
            StopAudio();
        });

        //视频关闭
        btnVideoClose.onClick.AddListener(() =>
        {
            CloseVideo();
            
        });

        //分区面板关闭
        Fenquclose.onClick.AddListener(() =>
        {
            panel.gameObject.SetActive(false);
        });

        //打开可视化界面按钮
        btnVisu.onClick.AddListener(() => 
        {
            UIMgr.Instance.ShowPanel<VisualPanel>();
            UIMgr.Instance.HideMe<ScanPanel>();
        });
        #endregion  
    }

    /// <summary>
    /// 用于为面板命名和 调整分区小面板位置的函数
    /// </summary>
    /// <param name="partName"></param>
    /// <param name="panel"></param>
    private void ShowPart(string partName, GameObject panel)
    {
        PanelName.text = partName;
        if(partName == btnYuanliao.name)
        {
            panel.transform.localPosition = new Vector2(0, 0);
        }
        if(partName == btnHunliao.name)
        {
            panel.transform.localPosition = new Vector2(520, 0);
        }
        if (partName == btnJichuqu.name)
        {
            panel.transform.localPosition = new Vector2(1040, 0);
        }
        if (partName == btnGanzao.name)
        {
            panel.transform.localPosition = new Vector2(1560, 0);
        }
        if(partName == btnShaocheng.name)
        {
            panel.transform.localPosition = new Vector2(1560, -350);
        }
        if(partName == btnQiege.name)
        {
            panel.transform.localPosition = new Vector2(1040, -350);
        }
        if(partName == btnBaozhuang.name)
        {
            panel.transform.localPosition = new Vector2(520, -350);
        }
        if(partName == btnCangchu.name)
        {
            panel.transform.localPosition = new Vector2(0, -350);
        }
        panel.SetActive(true);
    }
    /// <summary>
    /// 显示图文介绍
    /// </summary>
    /// <param name="b"></param>
    /// <param name="image"></param>
    private void ShowImage(int index)
    {
        imageContent.sprite = ResourceLoader.LoadImage(DataMgr.Instance.resourcesInfos[index - 1].imagePath);
        imageContent.gameObject.SetActive(true);
    }

    /// <summary>
    /// 加载并播放音频介绍的函数
    /// </summary>
    /// <param name="b"></param>
    private void PlayAudio(string path)//用于加载并播放音频介绍
    {

        var clip = ResourceLoader.LoadAudio(path);
        if (clip == null) return;
        audioSource.clip = clip;

        if (!isAudio)
        {
            audioSource.Play();
            isAudio = true;
        }
        else
        {
            audioSource.Stop();
            isAudio = false;
        }
        
    }

    private void StopAudio()
    {
        if (isAudio)
        {
            audioSource.Stop();
            isAudio = false;
        }
    }

    /// <summary>
    /// 用于加载和显示视频的函数
    /// </summary>
    /// <param name="b"></用于识别各个分区的id>
    private void ShowVideo(int b)
    {
        string videoPath = Path.Combine(Application.streamingAssetsPath, DataMgr.Instance.resourcesInfos[b - 1].videoPath);

        // 安卓平台需要添加 "file://" 前缀
#if UNITY_ANDROID && !UNITY_EDITOR
        videoPath = "file://" + videoPath;
#endif
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoPath;
        videoContent.gameObject.SetActive(true);
        
        videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
        videoPlayer.Prepare();
    }

    /// <summary>
    /// 播放视频的函数
    /// </summary>
    /// <param name="source"></param>
    void VideoPlayer_prepareCompleted(VideoPlayer source)
    {  
        //播放视频
        videoPlayer.Play();
    }

    private void CloseVideo()
    {
        videoPlayer.Stop();
        videoPlayer.url = null; // 清空 URL
        videoPlayer.prepareCompleted -= VideoPlayer_prepareCompleted; // 清理事件监听
        videoContent.gameObject.SetActive(false);
    }

    protected override void Update()//同步系统时间
    {
        base.Update();
        DateTime NowTime = DateTime.Now.ToLocalTime();
        nowTime.text = NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
