using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOAudioManager : MonoSingleton<FOAudioManager>
{

    public AudioSource AS;
    public AudioSource ShotAS;
    public AudioSource BG_AS;

    public AudioClip UIClip;

    public float ACTimer = 0f;

    
    private void Awake()
    {
        if (BG_AS == null)
        {
            BG_AS = gameObject.AddComponent<AudioSource>();
          //  BG_AS.clip = Resources.Load<AudioClip>("Audio/BGM");
            BG_AS.loop = true;
            BG_AS.volume = 0.1f;
           // BG_AS.Play();

        }
        if (ShotAS == null)
        {
            ShotAS = gameObject.AddComponent<AudioSource>();
            //ShotAS.clip = Resources.Load<AudioClip>("Audio/UIButton");
            ShotAS.playOnAwake = false;
            ShotAS.volume = 1f;
        }
        if (AS == null)
        {
            AS = gameObject.AddComponent<AudioSource>();
            AS.loop = false;
            AS.playOnAwake = false;
            AS.volume = 1f;

        }
    }
    /// <summary>
    /// 设置背景音乐
    /// </summary>
    /// <param name="clip"></param>
    public void SetBgAudioClip(AudioClip clip)
    {
        BG_AS.clip = clip;
        BG_AS.Play();
    }
    public void SetBGMState(bool arg0)
    {
        if (arg0)
        {
            BG_AS.Play();
        }
        else
        {
            BG_AS.Pause();
        }
    }
    public bool BGStatus()
    {
        return BG_AS.isPlaying;
    }
    /// <summary>
    /// 播放UI音效
    /// </summary>
    /// <param name="clip"></param>
    public void ASPlayer(AudioClip clip)
    {
        AS.clip = clip;
        AS.Play();
    }
    /// <summary>
    /// 继续播放
    /// </summary>
    public void ASPlayerPlay()
    {
        AS.Play();
    }
    public void ASPlayer()
    {
        if (AS.isPlaying)
            ASPlayerPause();
        else
            ASPlayerPlay();
    }
    /// <summary>
    /// 结束播放
    /// </summary>
    public void ASPlayerStop()
    {
        AS.Stop();
    }
    /// <summary>
    /// 暂停播放
    /// </summary>
    public void ASPlayerPause()
    {
        AS.Pause();
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="clip"></param>
    public void ShotASPlayer(AudioClip clip)
    {
        ShotAS.clip = clip;
        ShotAS.Play();
    }
    /// <summary>
    /// 播放音效回调
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="callback"></param>
    public void ASPlayerAction(AudioClip clip, Action callback = null)
    {
        StartCoroutine(AudioAnimation(clip, callback));
    }

    public IEnumerator AudioAnimation(AudioClip clip, Action callback = null)
    {
        if (clip == null)
        {
            ACTimer = 0f;
        }
        else
        {
            ACTimer = clip.length;
            ASPlayer(clip);
        }
        yield return new WaitForSeconds(ACTimer);
        callback?.Invoke();
    }
    public void ASPlayerActionStop() 
    {
        StopAllCoroutines();
        ASPlayerStop();
    }
    /// <summary>
    /// 播放UI音效
    /// </summary>
    public void PlayShotClip()
    {
        if (ShotAS.clip == null)
        {
            ShotAS.clip = UIClip;
        }
        ShotAS.Play();
    }

}
