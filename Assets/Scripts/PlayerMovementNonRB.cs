using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNonRB : MonoBehaviour
{
    public float Gravity = 9.81f;
    public float speed = 12f;
    public float JumpHeight = 1f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public CharacterController Controller;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded && velocity.y < 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * -Gravity);
            }
            else
            {
                velocity.y = -2f;
            }
        }

        velocity.y += -Gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);

        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * z + transform.forward * x;

        Controller.Move(move * speed * Time.deltaTime);

    }
}
