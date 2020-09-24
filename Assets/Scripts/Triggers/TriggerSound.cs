using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                SoundManager.instance.ChangeToSound(index);
                changed = true;
            }
        }
    }
}
