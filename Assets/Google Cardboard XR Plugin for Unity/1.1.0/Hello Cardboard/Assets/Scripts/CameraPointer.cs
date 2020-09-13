//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float k_MaxDistance = 400f;
    private GameObject m_GazedAtObject = null;
    public static CameraPointer instance;

    [SerializeField]
    private FuzeAction gazeFill = null;


    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, k_MaxDistance))
        {
            if (hit.transform.tag == "Interactable")
            {
                // GameObject detected in front of the camera.
                if (m_GazedAtObject != hit.transform.gameObject)
                {
                    gazeFill.ExitFuzeAction();
                    m_GazedAtObject = hit.transform.gameObject;
                    gazeFill.StartFuzeAction();
                }
                else
                {
                    gazeFill.OnFuzeAction();
                }
            }

        }
        else
        {
            // No GameObject detected in front of the camera.
            gazeFill.ExitFuzeAction();
            m_GazedAtObject = null;
        }

        // Checks for screen touches.
        // if (Google.XR.Cardboard.Api.IsTriggerPressed)
        // {
        //     m_GazedAtObject?.SendMessage("OnPointerClick");
        // }
    }


    public void SendGazeEnter(){
        m_GazedAtObject?.SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
    }

    public void SendGazeExit(){
        m_GazedAtObject?.SendMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
    }

    
}
