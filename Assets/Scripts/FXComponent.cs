using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FXMode{
    INIT,
    FINAL
}

public class FXComponent : MonoBehaviour
{
    public static FXComponent instance;
    const float INIT_VALUE = 8.0f;
    const float FINAL_VALUE = 12.0f;
    float goTo = INIT_VALUE;
    float actualValue = FINAL_VALUE;
    bool accomplished = false;
    private Material fxMaterial = null;
    private FXMode mode = FXMode.INIT;

    // [SerializeField]
    float speed = 0.5f;
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this.gameObject);
        }

        
    }

    void Start(){
        Debug.Log("OnStart method");
        CreateMaterial();
        StartFXEffectOnInit();
    }
    
    
    void LateUpdate(){
        LerpEffect();
    }

    void LerpEffect(){
        if(!accomplished){
            actualValue = Mathf.Lerp(actualValue, goTo, Time.fixedDeltaTime * speed);
            fxMaterial.SetFloat("_CutoffHeight", actualValue);
            if(Mathf.Abs(goTo - actualValue) < 0.05){
                Debug.Log("Accomplished!");
                accomplished = true;
                // actualValue = goTo;                
                DisableFX();
            }
        }
    }

    void DisableFX(){
        switch(mode){
            case FXMode.INIT:
                this.transform.Find("CanvasEntry").gameObject.SetActive(false);
                this.transform.Find("FXPlane").gameObject.SetActive(false);
            break;
            case FXMode.FINAL: 
                ChapterFlow.instance.GoToMenu();
            break;
        }
        Destroy(fxMaterial);
    }

    public void StartFXEffectOnInit(){
        mode = FXMode.INIT;
        CreateMaterial();
        actualValue = FINAL_VALUE;
        goTo = INIT_VALUE;
        fxMaterial.SetFloat("_CutoffHeight", actualValue);
        this.transform.Find("FXPlane").gameObject.SetActive(true);
        this.transform.Find("CanvasEntry").gameObject.SetActive(true);
        accomplished = false;
        Debug.Log("Started!");
        
    }
    
    public void StartFXEffectOnFinal(){
        Debug.Log("Started!");
        mode = FXMode.FINAL;
        CreateMaterial();
        actualValue = INIT_VALUE;
        goTo = FINAL_VALUE;
        fxMaterial.SetFloat("_CutoffHeight", actualValue);
        this.transform.Find("FXPlane").gameObject.SetActive(true);
        this.transform.Find("CanvasFinal").gameObject.SetActive(true);
        accomplished = false;
    }

    void CreateMaterial(){
        fxMaterial = new Material(Shader.Find("Shader Graphs/DissolveUnlit"));
        fxMaterial.SetFloat("_NoiseScale", 50.0f);
        fxMaterial.SetFloat("_CutoffHeight", actualValue);
        fxMaterial.SetFloat("_NoiseStrength", 1.87f);
        this.transform.Find("FXPlane").GetComponent<Renderer>().sharedMaterial = fxMaterial;
        // DontDestroyOnLoad(fxMaterial);
    }    
}
