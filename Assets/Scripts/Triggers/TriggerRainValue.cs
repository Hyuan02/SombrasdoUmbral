using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DigitalRuby.RainMaker;

public class TriggerRainValue : MonoBehaviour
{
    
    [SerializeField]
    RainScript rain;

    bool changed = false;

    void Update(){
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                rain.WindSoundVolumeModifier = 15.0f;
                Invoke("BackToNormal", 5.0f);
                changed = true;
            }  
        }
    }

    void BackToNormal(){
        rain.WindSoundVolumeModifier = 0.5f;
    }
}
