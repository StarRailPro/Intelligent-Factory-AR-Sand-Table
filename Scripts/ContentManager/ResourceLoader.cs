using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;

public class ResourceLoader : MonoBehaviour
{
    private static Dictionary<string, Sprite> _spriteCache = new Dictionary<string, Sprite>();
    private static Dictionary<string, AudioClip> _audioCache = new Dictionary<string, AudioClip>();

    /// <summary>
    /// º”‘ÿÕºŒƒΩÈ…‹
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Sprite LoadImage(string path)
    {
        if (_spriteCache.TryGetValue(path, out var cachedSprite))
            return cachedSprite;

        var sprite = Resources.Load<Sprite>(path);
        if (sprite != null)
            _spriteCache[path] = sprite;

        return sprite;
    }

    /// <summary>
    /// º”‘ÿ“Ù∆µΩÈ…‹
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static AudioClip LoadAudio(string path)
    {
        if (_audioCache.TryGetValue(path, out var cachedAudio))
            return cachedAudio;

        var audio = Resources.Load<AudioClip>(path);
        if (audio != null)
            _audioCache[path] = audio;

        return audio;
    }

    public static void ClearCache()
    {
        _spriteCache.Clear();
        _audioCache.Clear();
        Resources.UnloadUnusedAssets();
    }
}