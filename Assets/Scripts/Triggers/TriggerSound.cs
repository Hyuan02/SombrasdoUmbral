using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    int index = 0;

    [SerializeField]
    [Range (0.0f, 20.0f)]
    float secondsToPlay = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                Invoke("PlaySound", secondsToPlay);
                changed = true;
            }
        }
    }

    void PlaySound(){
        SoundManager.instance.ChangeToSound(index);
    }
}
