using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource effectAudio;

    public AudioClip[] effClips;

    private void Awake()
    {
        instance = this;
    }

    public void PlayOnceClip(AudioSource audioSource,AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}
