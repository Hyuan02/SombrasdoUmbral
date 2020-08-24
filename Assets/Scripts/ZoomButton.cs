using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomButton : MonoBehaviour
{
    bool toogleZoom = false;

    [SerializeField]
    private Transform player = null;
    private static ZoomButton inZoom = null;

    private Vector3 positionToMove = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TriggerZoomButton(){
        toogleZoom = !toogleZoom;
        if(toogleZoom){
            if(inZoom != null){
                inZoom.TriggerZoomButton();
            }
            this.transform.parent.Translate(0,0,-5, player);
            inZoom = this;
        }
        else{
            this.transform.parent.Translate(0,0,5, player);
            inZoom = null;
        }
    }
}
