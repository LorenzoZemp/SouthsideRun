using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
       
        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = movement - transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement + transform.TransformDirection(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + transform.TransformDirection(Vector3.right);
        }
        movement = Vector3.Normalize(movement);
        movement = movement * movementSpeed;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }
}
