using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeSignal : MonoBehaviour
{

   [SerializeField]
    public UnityEvent actionOnFadeIn;

    [SerializeField]
    public UnityEvent actionOnFadeOut;
    // Start is called before the first frame update
    public void OnEndFadeInAnimation(){
        actionOnFadeIn.Invoke();
    }

    public void OnEndFadeOutAnimation(){
        actionOnFadeOut.Invoke();
    }
}
