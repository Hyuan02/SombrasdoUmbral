using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class TriggerMixerCut : MonoBehaviour
{
    [SerializeField]
    private List<AudioMixerGroup> groupsToCut = new List<AudioMixerGroup>();

    bool changed = false;
    [SerializeField]
    private float onTime = 1.0f;

    [SerializeField]
    private bool pageMode = true;
    void Update()
    {
        if (pageMode)
        {
            if (!changed)
            {
                if (this.transform.parent.name == "CurrentPanel")
                {
                    ActivateCut();
                    changed = true;
                }
            }
        }
    }
    public void ActivateCut(){
        if(pageMode || !changed){
            foreach(AudioMixerGroup group in groupsToCut){
                group.audioMixer.SetFloat(group.name + "_volume", -80.0f);
            }
        }
        changed = true;
    }

    public void DisableCut(){
        if (pageMode || !changed)
        {
            foreach (AudioMixerGroup group in groupsToCut)
            {
                group.audioMixer.ClearFloat(group.name + "_volume");
            }
        }
        changed = true;
    }
}
