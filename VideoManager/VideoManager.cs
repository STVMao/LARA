using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 声音管理器
/// </summary>
public class VideoManager : MonoSingleton<VideoManager>
{

    public AudioClip[] clip;
    public AudioSource au;
    public Dictionary<string, AudioClip> dicClip;
    void Start()
    {
        if (au == null)
            au = GetComponent<AudioSource>();
        dicClip = new Dictionary<string, AudioClip>();
        foreach (var item in clip)
        {
            dicClip.Add(item.name, item);
        }
    }

    public void PlayClip(string clipName)
    {
        AudioClip clip;
        if (dicClip.TryGetValue(clipName, out clip))
            au.PlayOneShot(clip);
    }


    public void PlayClip(string clipName, AudioSource selfAu)
    {
        AudioClip clip;

        if (dicClip.TryGetValue(clipName, out clip))
            selfAu.PlayOneShot(clip);
    }

}
