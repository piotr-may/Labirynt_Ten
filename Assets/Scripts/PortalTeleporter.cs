using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
	public Transform player;
	public Transform reciever;

	private bool playerIsOverlapping = false;

	void FixedUpdate()
	{
		Vector3 portalToPlayer = player.position - transform.position;
		float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
        Debug.Log(gameObject.name + " Dot: " + dotProduct);
        Debug.DrawLine(transform.position, transform.position + transform.up * 10f, Color.blue);
        Debug.DrawLine(transform.position, portalToPlayer + transform.position, Color.cyan);

        if (playerIsOverlapping)
		{
            
            if (dotProduct < 0)
			{
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);
				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = reciever.position + positionOffset;
				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player entered portal");
			playerIsOverlapping = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player entered portal");
			playerIsOverlapping = false;
		}
	}

}
