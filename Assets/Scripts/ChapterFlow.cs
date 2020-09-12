using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterFlow : MonoBehaviour
{

    [SerializeField]
    Animation animPanel;
    int actualIndex = 1;

    AsyncOperation op;

    public static ChapterFlow instance;
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }
    public void GoNext(){
        if(actualIndex < SceneManager.sceneCountInBuildSettings){
            actualIndex++;
            op = SceneManager.LoadSceneAsync(actualIndex, LoadSceneMode.Single);
            op.allowSceneActivation = false;
            StartCoroutine(WaitForLoad());
        }
            
        
    }

    public void GoPrevious(){
        if(actualIndex > 1){
            actualIndex--;
            op = SceneManager.LoadSceneAsync(actualIndex, LoadSceneMode.Single);
            op.allowSceneActivation = false;
            StartCoroutine(WaitForLoad());
        }
    }

    IEnumerator WaitForLoad(){
        yield return new WaitUntil(()=>op.progress >= 0.9f);
        animPanel.transform.parent.gameObject.SetActive(true);
        animPanel.Play("alphaentryanim");        
    }

    public void AllowSceneActivator(){
        op.allowSceneActivation = true;
        animPanel.Play("alphaexitanim");
        CheckButtons();
    }

    public void DisableSceneActivator(){
        animPanel.transform.parent.gameObject.SetActive(false);
    }
    
    void CheckButtons(){
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        if(actualIndex == 1){
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if(actualIndex == SceneManager.sceneCountInBuildSettings - 1){
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void GoToMenu(){
        op = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        op.allowSceneActivation = false;
        StartCoroutine(SetupForMenu());
    }

    IEnumerator SetupForMenu(){
        yield return new WaitUntil(()=>op.progress>=0.9f);
        XRManager.instance.GotoMenu();
        op.allowSceneActivation = true;
        Destroy(this.gameObject);
    }    
    
}
