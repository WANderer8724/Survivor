using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float Speed = 10;
    public float Jumppower = 20;
    public float runSpeed = 2;
    float Runer = 1;
    public Rigidbody rb;

    void Update()
    {
        Mover();
    }
    void Mover()
    {
        float hor = Input.GetAxis("Horizontal");

        float ver = Input.GetAxis("Vertical");

        if (Input.GetButton("Run"))
        {
            Runer = runSpeed;
        }
        else
        {
            Runer = 1;
        }

        Vector3 Direction = (transform.forward * ver + transform.right * hor).normalized;

        Vector3 desiredVelocity = Direction * Speed * Runer;

        rb.velocity = Vector3.Lerp(rb.velocity, desiredVelocity, Time.deltaTime * 2);
    }
}
