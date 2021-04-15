using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -0.015f;
    bool isGrounded;

    //sluzy do obliczenia spadania
    private Vector3 velocity;
    private CharacterController characterController;

    public Transform groundCheck;
    public LayerMask Groundmask;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,0.25f, Groundmask);

        RaycastHit hit;

        if(Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),out hit, 0.25f,Groundmask))
        {
            string terrainType= hit.collider.gameObject.tag;

            switch(terrainType)
            {
                default:
                    speed = 12f;
                    break;
                case "Low":
                    speed = 3f;
                    break;
                case "High":
                    speed =40f;
                    break;
            }
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        if(!isGrounded)
        {
            velocity.y += gravity;
        }
        else
        {
            velocity.Set(velocity.x, 0f, velocity.z);
        }

        
        characterController.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Somethin Collided!!");
        Debug.Log(hit.gameObject.name);

        if(hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
