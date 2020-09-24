using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TriggerChoiceEffect : MonoBehaviour
{

    string previousName = "";

    bool choiceMade = false;


    int choiceIndexMade = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!choiceMade)
        {
            if (previousName != this.transform.parent.name)
            {
                previousName = this.transform.parent.name;
                switch (previousName)
                {
                    case "CurrentPanel":
                        this.GetComponent<Volume>().enabled = true;
                        Time.timeScale = 0.2f;
                        this.transform.GetChild(0).gameObject.SetActive(true);
                        break;
                    default:
                        this.GetComponent<Volume>().enabled = false;
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        Time.timeScale = 1.0f;
                        break;
                }
            }
        }
        else{
            if(previousName != "selected"){
                this.GetComponent<Volume>().enabled = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(choiceIndexMade).gameObject.SetActive(true);
                Time.timeScale = 1.0f;
                previousName = "selected";
            }   
        }
        
    }


    public void MakeChoice(int index){
        choiceIndexMade = index;
        choiceMade = true;
        TurnToTag("Interactable");
        
    }

    public void TurnToTag(string tag){
        if(choiceMade){
            foreach (Transform item in this.transform.GetChild(choiceIndexMade))
            {
                item.tag = tag;
            }  
        }
    }
}
