using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectActivation : MonoBehaviour
{

    bool changed = false;
    
    [SerializeField]
    GameObject objectToActivate = null;
    [SerializeField]
    bool onSelector = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!changed){
            if(onSelector? this.transform.parent.parent.name == "CurrentPanel" : this.transform.parent.name == "CurrentPanel"){
                ActivateObject();
                changed = true;
            }
        }
    }

    public void ActivateObject(){
        objectToActivate.SetActive(true);
    }
}
