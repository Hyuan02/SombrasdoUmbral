using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerActions : MonoBehaviour
{
    [SerializeField]
    public UnityEvent actionToEnter;

    [SerializeField]
    public UnityEvent actionToExit;

    public void OnGazeEnter(){
        actionToEnter.Invoke();
    }

    public void OnGazeExit(){
        actionToExit.Invoke();
    }

    
}
