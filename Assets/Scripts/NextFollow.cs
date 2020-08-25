using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFollow : MonoBehaviour
{

    bool going = false;
    Transform nextTransform = null;

    [SerializeField]
    float speed = 1.0f;

    Vector3 nextPosition = Vector3.zero;
    GameObject panel = null;


    void Start(){
        panel = GameObject.Find("HqPanel");
        this.transform.parent = panel.transform.GetChild(panel.GetComponent<PanelFlow>().panelNumber);
    }
    public void GoToNextPanel(){
        going = false;
        nextTransform = panel.transform.GetChild(panel.GetComponent<PanelFlow>().panelNumber);
        nextPosition = nextTransform.Find("NextPoint").position;
        going = true;
    }

    void Update(){
        if(going){
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * speed);
            if(Vector3.Distance(this.transform.position, nextPosition)<1.0f){
                going = false;
                this.transform.parent = nextTransform;
            }
        }
    }
}
