using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    
    public AudioClip[] audioClip;

    private bool isPlaying;

    private float clipTime = 1;

    public void PlaySound(AudioClip clip)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            StartCoroutine(WaitForSound());
        }
          
    }

    public void PlaySoundDeterminer(AudioClip clip)
    {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(clipTime);
        isPlaying = false;
    }
}
