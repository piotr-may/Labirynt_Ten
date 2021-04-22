using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickUp
{
    public int points = 5;

    public override void Picked()
    {
        base.Picked();
        Picked();
        GameManager.Instance.AddPoints(points);
    }

    void Update()
    {
        Rotation();
    }
}
