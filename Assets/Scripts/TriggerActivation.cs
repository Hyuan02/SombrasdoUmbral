using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    int index = 0;

    [SerializeField]
    float atTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                SoundManager.instance.Activate3DSound(index, atTime);
                changed = true;            
            }
        }   
    }
}
