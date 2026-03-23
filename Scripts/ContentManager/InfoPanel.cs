using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InfoPanel : MonoBehaviour
{
    [Header("References")]
    //图文介绍相关
    [SerializeField] private Image contentImage;
    [SerializeField] private Button btnImageClose;
    [SerializeField] private Button btnAudio;

    //分区小面板相关
    public GameObject panel;
    public Text titleText;
    public Button btnIntr;
    public Button btnVideo;
    public Button btnClose;

    //视频相关控件
    public Button btnVideoClose;

    public VideoController videoController;

    public AudioController audioController;


    private void Start()
    {
        //交互逻辑实现
        /***************面板的按钮监听***************/
        //小面板关闭按钮
        btnClose.onClick.AddListener(() =>
        {
            Hide();
            videoController.NullVideoUrl();
            DataMgr.Instance.isOn = true;
        });
        //图文介绍按钮
        btnIntr.onClick.AddListener(() =>
        {
            ((RectTransform)contentImage.transform).SetAsLastSibling();
            contentImage.gameObject.SetActive(true);
        });
        //图文介绍关闭按钮
        btnImageClose.onClick.AddListener(() =>
        {
            contentImage.gameObject.SetActive(false);
        });
        //视频介绍按钮
        btnVideo.onClick.AddListener(() =>
        {
            PlayVideo();
        });
        //视频介绍关闭按钮
        btnVideoClose.onClick.AddListener(() =>
        {
            videoController.HideVideoConten();
        });
        //音频介绍按钮
        btnAudio.onClick.AddListener(() =>
        {
            PlayAudio();
        });

    }

    /// <summary>
    /// 显示小面板
    /// </summary>
    /// <param name="paneName"></param>
    public void Show(string paneName)
    {
        titleText.text = paneName;
        ((RectTransform)panel.transform).SetAsLastSibling();
        panel.SetActive(true);
        UIMgr.Instance.GetPanel<PaneSaoma>().HongXian.SetActive(false);

    }

    /// <summary>
    /// 隐藏小面板
    /// </summary>
    private void Hide()
    {
        panel.SetActive(false);
        UIMgr.Instance.GetPanel<PaneSaoma>().HongXian.SetActive(true);
    }

    /// <summary>
    /// 加载图文介绍
    /// </summary>
    /// <param name="path"></param>
    public void LoadImage(string path)
    {
        contentImage.sprite = ResourceLoader.LoadImage(path);
    }

    /// <summary>
    /// 加载音频介绍
    /// </summary>
    /// <param name="path"></param>
    public void LoadAudio(string path)
    {
        audioController.LoadAudio(path);
    }

    /// <summary>
    /// 播放音频介绍
    /// </summary>
    private void PlayAudio()
    {
        audioController.PlayAudio();
    }

    /// <summary>
    /// 停止音频介绍
    /// </summary>
    private void StopAudio()
    {
        audioController.StopAudio();
    }

    /// <summary>
    /// 加载视频介绍
    /// </summary>
    /// <param name="path"></param>
    public void LoadVedio(string path)
    {
        videoController.LoadVideo(path);
    }

    /// <summary>
    /// 播放视频介绍
    /// </summary>
    private void PlayVideo()
    {
        videoController.PlayVideo();
    }

}