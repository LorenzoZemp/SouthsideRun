using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 5.0f;

    // PUBLIC
    public float jumpForce = 10.0f;
    public static Player CurrentPlayer;

    // PRIVATE

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = this;
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
        if (Input.GetKeyDown("space"))
        {
            bool canJump = (Physics.Raycast(transform.position, Vector3.down, 1.0f));
            if (canJump)
            {
                //Debug.Log(jumpForce);
                //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                //rb.velocity = (new Vector3(0.0f, jumpForce, 0.0f));
                rb.velocity = (new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
