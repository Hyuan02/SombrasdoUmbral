using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource sourceToChange;

    [SerializeField]
    private AudioClip clipToTrigger;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float volumeToSwitch = 0.5f;

    bool changed = false;

    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                sourceToChange.Stop();
                sourceToChange.clip = clipToTrigger;
                sourceToChange.volume = volumeToSwitch; 
                sourceToChange.Play();
                changed = true;
            }
        }
    }
}
