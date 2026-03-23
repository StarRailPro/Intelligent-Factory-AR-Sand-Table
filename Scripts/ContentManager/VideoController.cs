using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RenderTexture renderTexture;
    [SerializeField] private GameObject loadingIndicator;

    private void Start()
    {
        videoPlayer.SetDirectAudioVolume(0, DataMgr.Instance.MusiData.SoundValue);
    }

    /// <summary>
    /// 加载视频介绍
    /// </summary>
    /// <param name="path"></param>
    public void LoadVideo(string path)
    {
        if (string.IsNullOrEmpty(path)) return;

        string videoPath = Path.Combine(Application.streamingAssetsPath, path);

        // 安卓平台需要添加 "file://" 前缀
        #if UNITY_ANDROID && !UNITY_EDITOR
        videoPath = "file://" + videoPath;
        #endif  

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoPath;
        

    }
    /// <summary>
    /// 播放视频介绍
    /// </summary>
    public void PlayVideo()
    {
        //将视频播放组件激活，并将它显示在面板的最上层
        ((RectTransform)loadingIndicator.transform).SetAsLastSibling();
        loadingIndicator.SetActive(true);
        //添加一个委托函数，当视频准备好后播放视频
        videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
        videoPlayer.Prepare();
    }
    /// <summary>
    /// 视频准备后执行的函数
    /// </summary>
    /// <param name="source"></param>
    void VideoPlayer_prepareCompleted(VideoPlayer source)
    {
        //播放视频
        videoPlayer.Play();
    }

    /// <summary>
    /// 将视频加载路径置空
    /// </summary>
    public void NullVideoUrl()
    {
        videoPlayer.url = null;
    }

    /// <summary>
    /// 关闭视频介绍
    /// </summary>
    public void HideVideoConten()
    {
        videoPlayer.Stop();
        videoPlayer.prepareCompleted -= VideoPlayer_prepareCompleted; // 清理事件监听
        loadingIndicator.gameObject.SetActive(false);
    }

}