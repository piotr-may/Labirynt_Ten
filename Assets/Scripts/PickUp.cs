using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log("Picked up: " + gameObject.name);
        Destroy(gameObject);
    }

    protected void Rotation()
    {
        transform.Rotate(new Vector3(0, 5f, 0));
    }

}
