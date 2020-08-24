using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimActions : MonoBehaviour
{

    [SerializeField]
    private Animator cubeAnim = null;

    [SerializeField]
    private string enterState = "";
    [SerializeField]
    private string exitState = "";
    public void OnGazeEnter(){
        cubeAnim.Play(enterState);
    }

    public void OnGazeExit(){
        cubeAnim.Play(exitState);
    }


}
