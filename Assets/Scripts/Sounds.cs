using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
   public AudioClip[] sounds;
    public SoundArray[] tracks;
   private AudioSource audioSrc => GetComponent<AudioSource>();
    
   public void PlaySound
                        (int index,
                        float volume =1f,
                        bool destroyed = false,
                        bool random = false,
                        float p1=0.85f,
                        float p2=1.2f)
                        {
        AudioClip clip = random ? tracks[index]
            .soundArray[Random.Range(0, tracks[index]
            .soundArray.Length)]
            : tracks[index]
            .soundArray[0];

        audioSrc.pitch = Random.Range(p1, p2);
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        else
        audioSrc.PlayOneShot(clip,volume);
    }
    [System.Serializable]
    public class SoundArray
    {
        public AudioClip[] soundArray;
    }
}
