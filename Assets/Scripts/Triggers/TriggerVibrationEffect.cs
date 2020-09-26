using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;
public class TriggerVibrationEffect : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    private int miliseconds = 1000;

    [SerializeField]
    private int intensity = 2;
    public void TriggerVibration(){
        if(!changed){
            if(Vibration.HasVibrator()){
                Vibration.Vibrate(miliseconds, intensity, true);
            }
            changed = true;
        }
    }
}
