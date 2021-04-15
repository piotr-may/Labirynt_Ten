using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime;
    public int time = 10;

    public override void Picked()
    {
        base.Picked();
        GameManager.Instance.AddTime(addTime ? time : -time);
    }


    void Update()
    {
        Rotation(); 
    }
}
