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

    [SerializeField]
    [Range (0.0f, 20.0f)]
    float onTime = 1.0f;

    [SerializeField]
    bool pageMode = true;

    [SerializeField]
    bool onSelector = false;

    // Update is called once per frame
    void Update()
    {
        if (pageMode)
        {
            if (!changed)
            {
                if (onSelector? this.transform.parent.parent.name == "CurrentPanel" : this.transform.parent.name == "CurrentPanel")
                {
                    Invoke("ActivateEffect", onTime);
                    changed = true;
                }
            }
            else if (changed)
            {
                if (onSelector? this.transform.parent.parent.name != "CurrentPanel" : this.transform.parent.name != "CurrentPanel")
                {
                    Invoke("DisableEffect", 0.0f);
                }
            }
        }
    }


    public void ActivateEffect(){
        if(pageMode){
            SoundManager.instance.Activate3DSound(index, atTime);
        }
        else
        {
            if (!changed)
            {
                SoundManager.instance.Activate3DSound(index, atTime);
                changed = true;
            }
        }
    }

    public void DisableEffect(){
        CancelInvoke("ActivateEffect");
        SoundManager.instance.Disable3DSound(index);
    }
}
