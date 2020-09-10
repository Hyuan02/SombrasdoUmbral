using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFlow : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels = null;

    private int actualIndex = 0;
    void Awake(){
        if(panels != null && panels.Length > 1){
            panels[actualIndex].transform.SetParent(transform.Find("CurrentPanel"));
            panels[actualIndex].transform.localPosition = Vector3.zero;
            Invoke("SetInteractable", 3.0f);
            panels[actualIndex+1].transform.SetParent(transform.Find("NextPanel"));
            panels[actualIndex+1].transform.localPosition = Vector3.zero;
        }
    }
    public void GoNext(){
        if(panels != null){
            if(actualIndex < panels.Length - 1){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("PreviousPanel"));
                //panels[actualIndex].tag = "Untagged";
                Invoke("SetUntagged", 0.1f);
            }
            if(actualIndex>0 && actualIndex < panels.Length - 1){
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
            if(actualIndex <= panels.Length - 1){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("CurrentPanel"));
                Invoke("SetInteractable", 3.0f);
            }
        }
    }
    public void GoPrevious(){
        if(panels != null){
            if(actualIndex > 0){
                panels[actualIndex].GetComponent<TranslatePanel>().GoToPoint(transform.Find("NextPanel"));
                //panels[actualIndex].tag = "Untagged";
                Invoke("SetUntagged", 0.1f);
            }
            if(actualIndex <= panels.Length - 2 && actualIndex > 0){
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
                Invoke("SetInteractable", 3.0f);
            } 
        }
    }

    void SetInteractable(){
        //panels[actualIndex].tag = "Interactable";
        foreach (Transform item in panels[actualIndex].transform)
        {
            item.tag = "Interactable";
        }
    }
    void SetUntagged(){
        //panels[actualIndex].tag = "Interactable";
        foreach (Transform item in panels[actualIndex].transform)
        {
            item.tag = "Untagged";
        }
    }

}
