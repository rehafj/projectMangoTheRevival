
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraShader : MonoBehaviour
{
    public Material effectMaterial;
    // Start is called before the first frame update
    void OnRenderImage(RenderTexture src, RenderTexture dst){
        Graphics.Blit(src, dst, effectMaterial);
    }
}
