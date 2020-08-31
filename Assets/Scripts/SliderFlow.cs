using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFlow : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels = null;

    private int actualIndex = 0;
    void Start(){
        if(panels != null && panels.Length > 1){
            panels[actualIndex].transform.SetParent(transform.Find("CurrentPanel"));
            panels[actualIndex].transform.localPosition = Vector3.zero;
            panels[actualIndex+1].transform.SetParent(transform.Find("NextPanel"));
            panels[actualIndex+1].transform.localPosition = Vector3.zero;
        }
    }
    public void GoNext(){
        if(panels != null){
            if(actualIndex < panels.Length - 1){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("PreviousPanel"));
            }
            if(actualIndex>0){
                panels[actualIndex-1].transform.SetParent(transform.Find("Deactivated"));
                panels[actualIndex-1].transform.localPosition = Vector3.zero;
            }
            if(actualIndex < panels.Length - 1){
                actualIndex++;
            }
            if(actualIndex <= panels.Length - 2){
                panels[actualIndex + 1].transform.SetParent(transform.Find("NextPanel"));
                panels[actualIndex + 1].transform.localPosition = Vector3.zero;
            }
            if(actualIndex <= panels.Length - 1)
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("CurrentPanel"));
        }
    }
    public void GoPrevious(){
        if(panels != null){
            if(actualIndex > 0){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("NextPanel"));
            }
            if(actualIndex <= panels.Length - 2){
                panels[actualIndex + 1].transform.SetParent(transform.Find("Deactivated"));
                panels[actualIndex + 1].transform.localPosition = Vector3.zero;
            }
            if(actualIndex > 0){
                actualIndex--;
            }
            if(actualIndex >= 1){
                panels[actualIndex-1].transform.SetParent(transform.Find("PreviousPanel"));
                panels[actualIndex-1].transform.localPosition = Vector3.zero;
            }
            if(actualIndex >= 0){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("CurrentPanel"));
            } 
        }
    }


}
