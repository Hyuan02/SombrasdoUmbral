using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();

    private AudioSource mainAudioSource;

    public AudioMixer mainMixer;
    public static SoundManager instance;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volumeToTrack = 0.20f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volumeToFX = 1.0f;

    private int soundActivated = 1;

    private int soundMode = 1;
    AudioMixerSnapshot audio;

     
    void Awake(){
        mainAudioSource = this.GetComponent<AudioSource>();
        instance = this;

        soundActivated = PlayerPrefs.GetInt("Sound", 1);
        soundMode = PlayerPrefs.GetInt("SoundMode", 0);
        mainAudioSource.mute = soundActivated > 0 ? false : true;
        // volumeToTrack = soundMode > 0 ? volumeToTrack : volumeToTrack * 2;
        audio = soundMode > 0 ? mainMixer.FindSnapshot("Fone de Ouvido") : mainMixer.FindSnapshot("Alto Falante");
        // mainAudioSource.volume = volumeToTrack;
    }

    void Start(){
        // mainMixer.SetFloat("rain_volume", soundActivated > 0 ? 0f : -80f);
        // mainMixer.SetFloat("music_volume", soundMode > 0 ? -10f : 0f);
        audio.TransitionTo(0.5f);
    }


    public void ChangeToSound(int soundIndex, float volumeToTrack = -1){
        mainAudioSource.Stop();
        mainAudioSource.clip = clips[soundIndex];
        mainAudioSource.volume = volumeToTrack > -1 ?  volumeToTrack : mainAudioSource.volume;
        mainAudioSource.Play();
    }

    public void Activate3DSound(int soundIndex, float time = 0.0f){
        this.transform.GetChild(soundIndex).gameObject.SetActive(true);
        AudioSource a1 = this.transform.GetChild(soundIndex).GetComponent<AudioSource>();
        a1.volume = volumeToFX;
        a1.time = time;
        a1.mute = soundActivated > 0 ? false : true;
        a1.spatialBlend = soundMode;
        a1.panStereo = soundMode > 0 ? 0 : 1;
        // mainMixer.SetFloat("fx_volume", soundMode > 0 ? 20f : 0f);

    }

    public void Disable3DSound(int soundIndex){
        if(this.transform.GetChild(soundIndex).gameObject.activeSelf)
            this.transform.GetChild(soundIndex).gameObject.SetActive(false);
    }
    

}
