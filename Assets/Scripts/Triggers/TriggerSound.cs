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

    [SerializeField]
    bool pageMode = true;

    [SerializeField]
    bool onSelector = false;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float volumeToTrack = -1;
    // Update is called once per frame
    void Update()
    {

        if (pageMode)
        {
            if (!changed)
            {
                if (onSelector ? this.transform.parent.parent.name == "CurrentPanel" : this.transform.parent.name == "CurrentPanel")
                {
                    Invoke("PlaySound", secondsToPlay);        
                }
            }
        }
        
    }

    void PlaySound(){
        if(!changed){
            SoundManager.instance.ChangeToSound(index, volumeToTrack);
            changed = true;
        }
    }
}
