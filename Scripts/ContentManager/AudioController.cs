using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup masterGroup;
    [SerializeField] private AudioSource audioSource;

    private bool isAudio = false;
    private void Start()
    {
        //初始化音频和视频的音量大小
        audioSource.volume = DataMgr.Instance.MusiData.SoundValue;
  
    }
    /// <summary>
    /// 加载音频
    /// </summary>
    /// <param name="path"></param>
    public void LoadAudio(string path)
    {
        var clip = ResourceLoader.LoadAudio(path);
        if (clip == null) return;

        // audioSource.outputAudioMixerGroup = masterGroup;
        audioSource.clip = clip;

    }
    /// <summary>
    /// 播放音频
    /// </summary>
    public void PlayAudio()
    {
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
    /// <summary>
    /// 停止播放音频
    /// </summary>
    public void StopAudio()
    {
        if (isAudio)
        {
            audioSource.Stop();
            isAudio = false;
        }

    }
}