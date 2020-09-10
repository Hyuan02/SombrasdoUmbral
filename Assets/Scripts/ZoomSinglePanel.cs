using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSinglePanel : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 initialScale = new Vector3(0.05f, 0.05f, 0.05f);
    // private bool zoomMode = false;

    [SerializeField]
    private float scaleFactor = 2.0f;

    [SerializeField]
    private float speed = 1.0f;
    private Vector3 toScale = Vector3.zero;

    private string pageParentName = "";
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckParent();
        transform.localScale = Vector3.Lerp(this.transform.localScale, toScale, Time.deltaTime * speed);
    }

    public void ActivateZoom(){
        // zoomMode = true;
        toScale = initialScale * scaleFactor;
    }

    public void DisableZoom(){
        // zoomMode = true;
        toScale = initialScale;
    }

    private void CheckParent(){
        if(transform.parent.parent.name != pageParentName){
            pageParentName = transform.parent.parent.name;
            switch(transform.parent.parent.name){
                case "PreviousPanel":
                case "NextPanel":
                    toScale = initialScale * 0.5f;
                break;
                case "CurrentPanel":
                    toScale = initialScale;
                break;
            }    
        }
    }
}
