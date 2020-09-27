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
    // Update is called once per frame
    void Update()
    {

        if (pageMode)
        {
            if (!changed)
            {
                if (this.transform.parent.name == "CurrentPanel")
                {
                    Invoke("PlaySound", secondsToPlay);        
                }
            }
        }
        
    }

    void PlaySound(){
        if(!changed){
            SoundManager.instance.ChangeToSound(index);
            changed = true;
        }
    }
}
