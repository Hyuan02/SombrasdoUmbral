using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePanel : MonoBehaviour
{
    bool movement = false;
    
    private Transform toParent = null;
    private Vector3 nextPosition = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement){
            this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * speed);
            if(Vector3.Distance(this.transform.position, nextPosition)<1.0f){
                movement = false;
                this.transform.SetParent(toParent);
            }
        }        
    }

    public void GoToPoint(Transform parent){
        nextPosition = parent.position;
        toParent = parent;
        movement = true;
    }
}
