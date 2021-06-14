using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    [SerializeField]
    private AudioSource audioSource;

    public AudioClip[] audioClip;

    private bool isPlaying;

    private float clipTime = 1;

    

    public void PlaySound(AudioClip clip)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            audioSource.clip = clip;
            audioSource.Play();
            StartCoroutine(WaitForSound());
        }
          
    }

    public void PlaySoundDeterminer(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(clipTime);
        isPlaying = false;
    }
}
