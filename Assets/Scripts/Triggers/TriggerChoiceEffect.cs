using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TriggerChoiceEffect : MonoBehaviour
{

    string previousName = "";

    bool choiceMade = false;


    int choiceIndexMade = 0;

    float value = 0.0f;
    float toValue = 0.0f;

    [SerializeField]
    private Material blackAndWhiteEffect;
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
                        ActivatePostFX();
                        Time.timeScale = 0.2f;
                        this.transform.GetChild(0).gameObject.SetActive(true);
                        break;
                    default:
                        DisablePostFX();
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        Time.timeScale = 1.0f;
                        break;
                }
            }
        }
        else{
            if(previousName != "selected"){
                // this.GetComponent<Volume>().enabled = false;
                DisablePostFX();
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(choiceIndexMade).gameObject.SetActive(true);
                Time.timeScale = 1.0f;
                previousName = "selected";
            }   
        }
        
        ControlPostFXValue();
        
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

    private void ActivatePostFX(){
        toValue = 1;
    }

    private void DisablePostFX(){
        toValue = 0;
    }

    private void ControlPostFXValue(){
        if(Mathf.Abs(toValue - value) < 0.01f)
            return;
        value = Mathf.Lerp(value, toValue, Time.unscaledDeltaTime);
        blackAndWhiteEffect.SetFloat("_bwBlend", value);

    }
}
