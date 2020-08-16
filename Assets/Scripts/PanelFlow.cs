using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelFlow : MonoBehaviour
{

    int panelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNext(){
        if(panelIndex < transform.childCount - 1)
            panelIndex++;
        transform.GetChild(panelIndex).gameObject.SetActive(true);
    }

    public void GoPrevious(){
        transform.GetChild(panelIndex).gameObject.SetActive(false);
        if(panelIndex > 0)
            panelIndex--;
    }


}
