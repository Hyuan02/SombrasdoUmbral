using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configurations : MonoBehaviour
{

    [SerializeField]
    Toggle soundToogle;

    [SerializeField]
    Dropdown soundDropdown;
    void Awake(){
        if(!PlayerPrefs.HasKey("Sound")){
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("SoundMode", 1);    
        }
        soundToogle.isOn = PlayerPrefs.GetInt("Sound", 1) > 0 ? true : false;
        soundDropdown.value = PlayerPrefs.GetInt("SoundMode", 1);
    }

    void Update(){
        if (Application.platform == RuntimePlatform.Android) {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape)) {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void SetSoundActivation(){
        Debug.Log(soundToogle.isOn);
        PlayerPrefs.SetInt("Sound", soundToogle.isOn?1:0);
    }

    public void SetSoundMode(){
        Debug.Log(soundDropdown.value);
        PlayerPrefs.SetInt("SoundMode", soundDropdown.value);
    }
}
