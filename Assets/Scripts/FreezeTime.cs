using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : PickUp
{
    public int duration = 10;

    public override void Picked()
    {
        base.Picked();
        GameManager.Instance.FreezeTime(duration);
    }
    void Update()
    {
        Rotation();
    }
}