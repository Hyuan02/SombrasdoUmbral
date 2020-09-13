using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();

    private AudioSource mainAudioSource;

    public static SoundManager instance;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volumeToTrack = 0.20f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volumeToFX = 1.0f;
    void Awake(){
        mainAudioSource = this.GetComponent<AudioSource>();
        instance = this;
        mainAudioSource.volume = volumeToTrack;
    }


    public void ChangeToSound(int soundIndex){
        mainAudioSource.Stop();
        mainAudioSource.clip = clips[soundIndex];
        mainAudioSource.volume = volumeToTrack;
        mainAudioSource.Play();
    }

    public void Activate3DSound(int soundIndex){
        this.transform.GetChild(soundIndex).gameObject.SetActive(true);
        this.transform.GetChild(soundIndex).GetComponent<AudioSource>().volume = volumeToFX;
    }
    

}
