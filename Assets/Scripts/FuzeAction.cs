using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuzeAction : MonoBehaviour
{
    
    [SerializeField]
    private Image loadingFill = null;
    [SerializeField]
    private Image centerFill = null;
    private float currentAmount = 0;

    [SerializeField]
    [Range(0.25f, 5.0f)]
    private float SPEED = 2;

    [SerializeField]
    private Color enterColor = new Color(0f,1f,0f,1f);
    [SerializeField]
    private Color exitColor = new Color(0f,0f,1f,1f);

    private bool triggered = false;
    public void StartFuzeAction(){
        currentAmount = 0;
        triggered = false;
        loadingFill.fillAmount = currentAmount;
        centerFill.color = enterColor;
    }

    public void OnFuzeAction(){
        if(!triggered){
            if(currentAmount < 1){
                currentAmount += SPEED * Time.deltaTime; 
            }
            else{
                CameraPointer.instance.SendGazeEnter();
                currentAmount = 0;
                triggered = true;
            }
        }
        loadingFill.fillAmount = currentAmount;
    }

    public void ExitFuzeAction(){
        currentAmount = 0;
        triggered = false;
        loadingFill.fillAmount = currentAmount;
        CameraPointer.instance.SendGazeExit();
        centerFill.color = exitColor;
    } 
}
