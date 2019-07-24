using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Animation stuff
    Animator PlayerAni;
    bool caught;
    bool disableMovement;

    //audio stuff
    AudioSource audioSource;
    public AudioClip numberPickupClip;

    //pickup effect
    public GameObject collectEffect;

    Rigidbody rb;
    public float movementSpeed = 5.0f;

    // PUBLIC
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpForce = 10.0f;
    public static Player CurrentPlayer;
    public Cops copScript;
    public int[] numsCollected;
    public GameObject BoyzPrefab;

    // PRIVATE
    // For numbers that have been collected


    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayer = this;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        numsCollected = new int[10];
        PlayerAni = this.GetComponent<Animator>();
        caught = false;
        disableMovement = false;
        audioSource = GetComponent<AudioSource>();

        //Debug.DrawRay(transform.position, Vector3.forward * 100.0f, Color.green, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (!caught && !disableMovement)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Run();
                //movement = movement + transform.forward; // Local Coord
                movement = movement + Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Run();
                //movement = movement - transform.forward; // Local Coord
                movement = movement - Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Run();
                //movement = movement + transform.TransformDirection(Vector3.left); // Local coord
                movement = movement + Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Run();
                //movement = movement + transform.TransformDirection(Vector3.right); // Local coord
                movement = movement + Vector3.right;
            }
            movement = Vector3.Normalize(movement);
            movement = movement * movementSpeed;
            rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);

            // Rotate model based on direction of movement
            transform.rotation = Quaternion.LookRotation(movement);

            Debug.DrawRay(new Vector3(transform.position.x + 0.2f, transform.position.y + 1.0f, transform.position.z), Vector3.down * 1.05f, Color.green);
            Debug.DrawRay(new Vector3(transform.position.x - 0.2f, transform.position.y + 1.0f, transform.position.z), Vector3.down * 1.05f, Color.green);
            if (Input.GetKeyDown("space"))
            {
                //bool canJump = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Vector3.down, 1.1f);

                bool leftFootHit = Physics.Raycast(new Vector3(transform.position.x - 0.2f, transform.position.y + 1.0f, transform.position.z), Vector3.down, 1.05f);
                bool rightFootHit = Physics.Raycast(new Vector3(transform.position.x + 0.2f, transform.position.y + 1.0f, transform.position.z), Vector3.down, 1.05f);

                if (leftFootHit || rightFootHit)
                {
                    //Debug.Log(jumpForce);
                    //GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                    //rb.velocity = (new Vector3(0.0f, jumpForce, 0.0f));
                    Jump();
                    rb.velocity = (new Vector3(rb.velocity.x, jumpForce, rb.velocity.z));
                }
            }

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKeyDown("space"))
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift)) // to call the bois
            {
                // ACTUALLY CALL THE BOIS
                if (numsCollected[1] >= 3)
                {
                    Debug.Log("Bois were called!");
                    numsCollected[1] -= 3;
                    Instantiate(BoyzPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                // INSTANT WIN
                if (numsCollected[0] >= 1 && numsCollected[1]  >= 1 && numsCollected[2] >= 1 && numsCollected[3] >= 1 && numsCollected[4] >= 1 && numsCollected[5] >= 1 && numsCollected[6] >= 1
                    && numsCollected[7] >= 1 && numsCollected[8] >= 1 && numsCollected[9] >= 1)
                {
                    Debug.Log("INSTANT WIN!!");
                    numsCollected[0] -= 1;
                    numsCollected[1] -= 1;
                    numsCollected[2] -= 1;
                    numsCollected[3] -= 1;
                    numsCollected[4] -= 1;
                    numsCollected[5] -= 1;
                    numsCollected[6] -= 1;
                    numsCollected[7] -= 1;
                    numsCollected[8] -= 1;
                    numsCollected[9] -= 1;
                    disableMovement = true;
                    copScript.setChasing(false);
                }
                // DIALLED A BLANK
                else
                {
                    Debug.Log("Dialled a blank!");
                }
            }
        }

        //restart scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (transform.position.y < -30)
        {
            Debug.Log("Fell off map");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if ((!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKeyDown("space")) && !(caught)))
       {
           Idle();
       }
       else if (caught)
       {
            Fall();
       }
    }

    private void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cops") // get caught by cops
        {
            Debug.Log("You got caught");
            caught = true;
            copScript.setChasing(false);
        }

        if (other.tag == "Win")
        {
            Debug.Log("You ESCAPED!");
            copScript.setChasing(false);
            disableMovement = true;
        }

        if (other.tag == "Number")
        {
            audioSource.PlayOneShot(numberPickupClip, 0.3f);
            Instantiate(collectEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            int numFound = other.gameObject.GetComponent<NumberScript>().thisNumber;
            numsCollected[numFound]++;
            Debug.Log("Found a Number ! --> " + numFound);
            Debug.Log("You now have " + numsCollected[numFound] + "x " + numFound);
            Destroy(other.gameObject);
        }

    }

    private void Run()
    {
        PlayerAni.SetBool("Run", true);
        PlayerAni.SetBool("Idle", false);
        PlayerAni.SetBool("Jump", false);
        PlayerAni.SetBool("Fall", false);
    }

    private void Idle()
    {
        PlayerAni.SetBool("Idle", true);
        PlayerAni.SetBool("Run", false);
        PlayerAni.SetBool("Jump", false);
        PlayerAni.SetBool("Fall", false);
    }

    private void Jump()
    {
        PlayerAni.SetBool("Jump", true);
        PlayerAni.CrossFade("Jump", 0.1f);
        PlayerAni.SetBool("Idle", false);
        PlayerAni.SetBool("Run", false);
        PlayerAni.SetBool("Fall", false);
    }

    private void Fall()
    {
        PlayerAni.SetBool("Fall", true);
        PlayerAni.SetBool("Run", false);
        PlayerAni.SetBool("Idle", false);
        PlayerAni.SetBool("Jump", false);
    }
}
