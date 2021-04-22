using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform slider;
    public Transform closedPosition;
    public Transform openedPosition;

    public bool open =false;
    public float speed = 5f;

    void Start()
    {
        slider.position = open ? openedPosition.position : closedPosition.position;
    }

    public void OpenClose()
    {
        open = !open;
    }

    void Update()
    {
        if(open && Vector3.Distance(slider.position, openedPosition.position)> 0f)
        {
            slider.position = Vector3.MoveTowards(slider.position, openedPosition.position,
                Time.deltaTime * speed);
            OpenClose();
        }

        if (!open && Vector3.Distance(slider.position, openedPosition.position) > 0f)
        {
            slider.position = Vector3.MoveTowards(slider.position, closedPosition.position,
                Time.deltaTime * speed);
            OpenClose();
        }
    }
}
