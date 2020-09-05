using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    bool changed = false;

    [SerializeField]
    private GameObject objectToActivate;
    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                objectToActivate.SetActive(true);
                changed = true;            
            }
        }   
    }
}
