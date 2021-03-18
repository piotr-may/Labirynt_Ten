using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    float myAngle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFormPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFormPortal;

        float angulatDifferenceBetweenPortals = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifferande = Quaternion.AngleAxis(angulatDifferenceBetweenPortals, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifferande * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}
