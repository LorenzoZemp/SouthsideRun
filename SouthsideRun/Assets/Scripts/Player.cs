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
    public Cops copScript;

    // PRIVATE
    // For numbers that have been collected
    int[] numsCollected;
  

    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = this;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        numsCollected = new int[10];
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

        if (Input.GetKeyDown(KeyCode.LeftShift)) // to call the bois
        {
            // ACTUALLY CALL THE BOIS
            if (numsCollected[1] >= 3)
            {
                Debug.Log("Bois were called!");
                numsCollected[1] -= 3;
            }
            // DIALLED A BLANK
            else
            {
                Debug.Log("Dialled a blank!");
            }
        };
    }

    private void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cops") // get caught by cops
        {
            Debug.Log("You got caught");
            copScript.setChasing(false);
        }

        if (other.tag == "Number")
        {
            int numFound = other.gameObject.GetComponent<NumberScript>().thisNumber;
            numsCollected[numFound]++;
            Debug.Log("Found a Number ! --> " + numFound);
            Debug.Log("You now have " + numsCollected[numFound] + "x " + numFound);
            Destroy(other.gameObject);
        }

    }
}
