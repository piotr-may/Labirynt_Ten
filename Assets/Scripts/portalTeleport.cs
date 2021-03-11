﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private bool playerIsOverlaping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered portal");
            playerIsOverlaping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Exit portal");
            playerIsOverlaping = false;
        }
    }

    private void FixedUpdate()
    {
        if(playerIsOverlaping)
        {
            Vector3 portalToPlayer = player.position - transform.position;

            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlaping = false;
            }
        }
    }

}