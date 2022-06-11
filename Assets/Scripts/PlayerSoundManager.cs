using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gunshot;
    public AudioClip reloading;

    private void Start()
    {
        
    }

    public void ShotSound()
    {
        PlaySound(gunshot);
    }

    public void ReloadSound()
    {
        PlaySound(reloading);
    }


    public void PlaySound(AudioClip clipToPlay)
    {
        var soundGameObject = new GameObject("SoundPlayer", typeof(AudioSource));

        var audioSource = soundGameObject.GetComponent<AudioSource>();

        audioSource.PlayOneShot(clipToPlay);

        soundGameObject.transform.parent = transform;

        soundGameObject.transform.localPosition = Vector3.zero;

        Destroy(soundGameObject, clipToPlay.length);

    }

}
