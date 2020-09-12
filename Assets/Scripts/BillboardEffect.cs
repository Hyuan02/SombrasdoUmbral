using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    [SerializeField]
    private Transform toLook = null;
    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.rotation = toLook.rotation;
    }

}
