using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public PortalTeleporter portalTeleporter;
    public PortalCamera portalCamera;
    public PortalTexture portalTexture;
    public Portal targetPortal;
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player").transform;

        targetPortal.portalTeleporter.reciever = portalTeleporter.transform;
        portalTeleporter.player = player;

        portalCamera.playerCamera = Camera.main.transform;
        portalCamera.portal = portalTexture.transform;
        targetPortal.portalCamera.otherPortal = portalCamera.portal;
        //portalTexture.portalCamera = targetPortal.portalCamera.renderTextureCamera;
    }

   
}
