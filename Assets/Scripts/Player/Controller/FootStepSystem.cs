using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSystem : MonoBehaviour
{
    [Header("石灰地")]
    public List<AudioClip> rockClipsN = new List<AudioClip>();
    public List<AudioClip> rockClipsR = new List<AudioClip>();
    [Header("木板")]
    public List<AudioClip> woodClips = new List<AudioClip>();
    public List<AudioClip> curClips;

    public AudioSource audioSource;

    public float footStepTimer;
    public float walkTimer = .7f;
    public float runTimer = .4f;
    
  

    public bool canPlay = true;
        
    private void Start()
    {
        curClips = rockClipsN;
    }
    public void PlayerStepSound()
    {
        StartCoroutine("PlaySound", footStepTimer);
    }

    IEnumerator PlaySound(float timer)
    {
        var randomIndex = Random.Range(0, curClips.Count);
        audioSource.clip = curClips[randomIndex];
        audioSource.Play();

        canPlay = false;
        yield return new WaitForSeconds(timer);
        canPlay = true;
    }
}
