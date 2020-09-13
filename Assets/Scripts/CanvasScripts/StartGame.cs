using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartGame : MonoBehaviour
{
    public void TriggerGameStart(){
        ScreenManager.instance.LoadAsyncScene();
    }

    public void TriggerConfigSound(){
        this.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void DisableConfigSound(){
        this.transform.parent.GetChild(1).gameObject.SetActive(false);
    }


    public void QuitApp(){
        Application.Quit();
    }
    
}
