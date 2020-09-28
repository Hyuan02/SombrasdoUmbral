using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalEffect : MonoBehaviour
{

    bool changed = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(this.transform.parent.name == "CurrentPanel"){
                TriggerFinalFX();
                changed = true;
            }
        }
    }


    void TriggerFinalFX(){
        FXComponent.instance.StartFXEffectOnFinal();
    }
}
