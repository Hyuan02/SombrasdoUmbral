using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class GrayscaleFilter : ScriptableRenderPass
{
    // Start is called before the first frame update
    public float intensity;
    private Material material;

    static readonly string k_RenderTag = "Black and White FX";

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/BWDiffuse"));
    }

    // Postprocess the image
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        // if (intensity == 0)
        // {
        //     Graphics.Blit(source, destination);
        //     return;
        // }
        // material.SetFloat("_bwBlend", intensity);
        // Debug.Log("Drawing");
        // Graphics.Blit (source, destination, material);



    }
}
