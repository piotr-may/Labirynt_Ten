using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public enum KeyColor
    {
        Green,
        Red,
        Gold
    }

    public KeyColor keyColor;

    public override void Picked()
    {
        base.Picked();
        GameManager.Instance.keys[(int)keyColor]++;
    }

    void Update()
    {
        Rotation();  
    }
}
