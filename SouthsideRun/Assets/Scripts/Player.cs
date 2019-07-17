using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // PUBLIC
    public float jumpForce = 10.0f;
    public static Player CurrentPlayer;

    // PRIVATE
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = this;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
