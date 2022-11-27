using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //bool dash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("Daño");
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //dash = true;
        }

        /*
        else if (Input.GetButtonDown("Jump") && dash && !isGrounded)
        {
            velocity.z = Mathf.Sqrt(jumpHeight * -4f * gravity);
            dash = false;
        }
        else if (Input.GetButtonDown("Jump") && dash && !isGrounded && Input.GetKey("w"))
        {
                velocity.z = Mathf.Sqrt(jumpHeight * -4f * gravity);
                dash = false;
        }
        else if (Input.GetButtonDown("Jump") && dash && !isGrounded && Input.GetKey("s"))
        {
            velocity.z = -Mathf.Sqrt(jumpHeight * -4f * gravity);
            dash = false;
        }
        else if (Input.GetButtonDown("Jump") && dash && !isGrounded && Input.GetKey("d"))
        {
            velocity.x = -Mathf.Sqrt(jumpHeight * -4f * gravity);
            dash = false;
        }
        else if (Input.GetButtonDown("Jump") && dash && !isGrounded && Input.GetKey("a"))
        {
            velocity.x = Mathf.Sqrt(jumpHeight * -4f * gravity);
            dash = false;
        }
        */

        //doble salto
        //velocity.y = Mathf.Sqrt(jumpHeight * -4f * gravity);

        if (isGrounded)
        {
            velocity.z = 0;
            velocity.x = 0;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
