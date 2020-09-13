using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    int index = 0;

    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                SoundManager.instance.Activate3DSound(index);
                changed = true;            
            }
        }   
    }
}
