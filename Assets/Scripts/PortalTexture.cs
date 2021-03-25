using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTexture : MonoBehaviour
{
    public Camera portalCamera;
    public Material material;


    private void Start()
    {
        if(portalCamera.targetTexture != null)
        {
            portalCamera.targetTexture.Release();
        }

        portalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        material.mainTexture = portalCamera.targetTexture;

    }
}
