using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    bool changed = false;

    Animation animation;

    void Start(){
        animation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
    }
    
    [SerializeField]
    string animationToPlay = "";
    public void PlayAnimation(){
        if(!changed){
            animation.Play(animationToPlay);
            changed = true;
        }
    }
}
