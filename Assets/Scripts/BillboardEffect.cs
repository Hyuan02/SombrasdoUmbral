using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    
    [SerializeField]
    private Transform toLook = null;

    void Awake(){
        if(toLook == null){
            toLook = Camera.main.transform;
        }
    }
    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.rotation = toLook.rotation;
    }

}
