using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (Canvas))]
public class ZoomSinglePanel : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 initialScale = new Vector3(0.05f, 0.05f, 0.05f);
    // private bool zoomMode = false;

    private Vector3 initialParentScale = new Vector3(1,1,1);
    [SerializeField]
    private float scaleFactor = 2.0f;

    [SerializeField]
    private float speed = 1.0f;
    private Vector3 toScale = Vector3.zero;

    private Vector3 toParentScale = Vector3.zero;

    private string pageParentName = "";

    [SerializeField]
    private bool isChoicePage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // toParentScale = initialParentScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckParent();
        Scaler();
        ParentScaler();
    }

    void Scaler(){
        transform.localScale = Vector3.Lerp(this.transform.localScale, toScale, Time.unscaledDeltaTime * speed);
    }

    void ParentScaler(){
        transform.parent.localScale = Vector3.Lerp(this.transform.parent.localScale, toParentScale, Time.unscaledDeltaTime * speed);
    }

    public void ActivateZoom(){
        // zoomMode = true;
        toScale = initialScale * scaleFactor;
        this.GetComponent<Canvas>().sortingOrder = 2;
    }

    public void DisableZoom(){
        // zoomMode = true;
        toScale = initialScale;
        this.GetComponent<Canvas>().sortingOrder = 1;
    }

    private void CheckParent(){
        string parentName = isChoicePage ? transform.parent.parent.parent.name : transform.parent.parent.name;
        if(parentName != pageParentName){
            pageParentName = parentName;
            switch(parentName){
                case "PreviousPanel":
                case "NextPanel":
                    toParentScale = initialParentScale * 0.5f;
                    toScale = initialScale;
                    this.GetComponent<Canvas>().sortingOrder = 0;
                break;
                case "CurrentPanel":
                    toParentScale = initialParentScale;
                    toScale = initialScale;
                    this.GetComponent<Canvas>().sortingOrder = 1;
                break;
            }    
        }
    }
}
