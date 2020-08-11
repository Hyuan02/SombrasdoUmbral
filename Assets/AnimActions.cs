using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimActions : MonoBehaviour
{

    [SerializeField]
    private Animator cubeAnim;

    [SerializeField]
    private string enterState;
    [SerializeField]
    private string exitState;
    public void OnGazeEnter(){
        cubeAnim.Play(enterState);
        CameraPointer.instance.SetEnterMaterial();
    }

    public void OnGazeExit(){
        cubeAnim.Play(exitState);
        CameraPointer.instance.SetExitMaterial();
    }


}
