using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class XRManager : MonoBehaviour
{

    [SerializeField]
    private GameObject displayObject;
    public static XRManager instance;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        StartCoroutine(StartXR());
    }
    
    public IEnumerator StartXR()
    {
        int width = Screen.width;
        int height = Screen.height;
        #if !UNITY_EDITOR
        Debug.Log("Initializing XR...");
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else 
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            displayObject.SetActive(true);
        }
        #elif UNITY_EDITOR
            displayObject.SetActive(true);
            yield break;
        #endif


    }

    public void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}
