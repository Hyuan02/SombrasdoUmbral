﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    [SerializeField]
    GameObject loadingAnim = null;
    [SerializeField]
    GameObject startScreen = null;

    public Material materialToReset;

    AsyncOperation asyncLoad;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(instance);
            instance = this;
        }
    }

    void Start(){
        ResetMaterial();
    }
    public void LoadAsyncScene(){
        asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        startScreen.SetActive(false);
        loadingAnim.SetActive(true);
        StartCoroutine(WaitForLoad());
    }

    public IEnumerator WaitForLoad(){
        yield return new WaitUntil(()=>asyncLoad.progress >= 0.9f);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        asyncLoad.allowSceneActivation = true;
    }

    private void ResetMaterial(){
        materialToReset.SetFloat("_bwBlend", 0.0f);
    }
}
