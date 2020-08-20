using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody BodyRb;
    public Transform BodyTransform;
    public Transform Head;
    public float ForwardForce = 400f;
    public float BackwardForce = 100f;
    public float SidewaysForce = 200f;
    public float JumpForce = 20f;
    public float MaxVelocity = 1;

    bool TouchedGround = true;
    public float TotalVelocity;
    Vector3 PlayerRot;

    private void OnCollisionEnter(Collision collision)
    {
        TouchedGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRot.y = Head.eulerAngles.y;
        BodyTransform.eulerAngles = PlayerRot;
        if (Input.GetKeyDown("space") && TouchedGround)
        {
            Debug.Log("jump");
            BodyRb.AddForce(0, JumpForce, 0, ForceMode.Impulse);
            TouchedGround = true;
        }
    }

    void FixedUpdate()
    {
        TotalVelocity = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(BodyRb.velocity.x), 2) + Mathf.Pow(Mathf.Abs(BodyRb.velocity.z), 2));

        if (TotalVelocity < MaxVelocity)
        {
            if (Input.GetKey("w"))
            {
                BodyRb.AddRelativeForce(0, 0, ForwardForce * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Input.GetKey("s"))
            {
                BodyRb.AddRelativeForce(0, 0, -BackwardForce * Time.deltaTime, ForceMode.Acceleration);
            }

            if (Input.GetKey("d"))
            {
                BodyRb.AddRelativeForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            }
            if (Input.GetKey("a"))
            {
                BodyRb.AddRelativeForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            }
        }
    }
}
