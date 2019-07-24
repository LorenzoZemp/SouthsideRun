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
    public string[] numsCollectedLimited;

    private string[] phoneBook;

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

        // Initialise phone book
        phoneBook = new string[2];
        phoneBook[0] = "111";

        // Initialise phone buffer
        numsCollectedLimited = new string[10];
        numsCollectedLimited[0] = "1";
        numsCollectedLimited[1] = "1";
        numsCollectedLimited[2] = "1";
        numsCollectedLimited[3] = "";
        numsCollectedLimited[4] = "";
        numsCollectedLimited[5] = "";
        numsCollectedLimited[6] = "";
        numsCollectedLimited[7] = "";
        numsCollectedLimited[8] = "";
        numsCollectedLimited[9] = "";

        Debug.Log(numsCollectedLimited.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("escape"))
        { 
            Application.Quit();
        }

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
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }

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
                if (dialANumber(phoneBook[0]))
                {
                    Debug.Log("Called the boyz");
                }
                else
                {
                    Debug.Log("Failed to call");
                }

                //// ACTUALLY CALL THE BOIS
                //if (numsCollected[1] >= 3)
                //{
                //    Debug.Log("Bois were called!");
                //    numsCollected[1] -= 3;
                //    Instantiate(BoyzPrefab, transform);
                //}
                //// INSTANT WIN
                //if (numsCollected[0] >= 1 && numsCollected[1]  >= 1 && numsCollected[2] >= 1 && numsCollected[3] >= 1 && numsCollected[4] >= 1 && numsCollected[5] >= 1 && numsCollected[6] >= 1
                //    && numsCollected[7] >= 1 && numsCollected[8] >= 1 && numsCollected[9] >= 1)
                //{
                //    Debug.Log("INSTANT WIN!!");
                //    numsCollected[0] -= 1;
                //    numsCollected[1] -= 1;
                //    numsCollected[2] -= 1;
                //    numsCollected[3] -= 1;
                //    numsCollected[4] -= 1;
                //    numsCollected[5] -= 1;
                //    numsCollected[6] -= 1;
                //    numsCollected[7] -= 1;
                //    numsCollected[8] -= 1;
                //    numsCollected[9] -= 1;
                //    disableMovement = true;
                //    copScript.setChasing(false);
                //}
                //// DIALLED A BLANK
                //else
                //{
                //    Debug.Log("Dialled a blank!");
                //}
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
            int numFound = other.gameObject.GetComponent<NumberScript>().thisNumber;
            //numsCollected[numFound]++;
            Debug.Log("Found a Number ! --> " + numFound);
            Debug.Log("You now have " + numsCollected[numFound] + "x " + numFound);
            Destroy(other.gameObject);
            collectedANumber(numFound);

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

    bool dialANumber(string s)
    {
        foreach (char c in s)
        {
            // check that the player has enough of the number
            switch (c)
            {
                case '0':
                    if (numsCollected[0] > 0)
                    {
                        numsCollected[0]--;
                    }
                    else return false;
                    break;
                case '1':
                    if (numsCollected[1] > 0)
                    {
                        numsCollected[1]--;
                    }
                    else return false;
                    break;
                case '2':
                    if (numsCollected[2] > 0)
                    {
                        numsCollected[2]--;
                    }
                    else return false;
                    break;
                case '3':
                    if (numsCollected[3] > 0)
                    {
                        numsCollected[3]--;
                    }
                    else return false;
                    break;
                case '4':
                    if (numsCollected[4] > 0)
                    {
                        numsCollected[4]--;
                    }
                    else return false;
                    break;
                case '5':
                    if (numsCollected[5] > 0)
                    {
                        numsCollected[5]--;
                    }
                    else return false;
                    break;
                case '6':
                    if (numsCollected[6] > 0)
                    {
                        numsCollected[6]--;
                    }
                    else return false;
                    break;
                case '7':
                    if (numsCollected[7] > 0)
                    {
                        numsCollected[7]--;
                    }
                    else return false;
                    break;
                case '8':
                    if (numsCollected[8] > 0)
                    {
                        numsCollected[8]--;
                    }
                    else return false;
                    break;
                case '9':
                    if (numsCollected[9] > 0)
                    {
                        numsCollected[9]--;
                    }
                    else return false;
                    break;



                default:
                    return false;
            }
        }
        return true;
    }

    void collectedANumber(int num)
    {
        if (num >= 0 && num <=9)
        { 
            // move all the numbers along
            for (int i = numsCollectedLimited.Length - 1; i > 0; i--)
            {
                numsCollectedLimited[i] = numsCollectedLimited[i - 1];
            }

            numsCollectedLimited[0] = num.ToString();
        }
        else
        {
            Debug.Log("Number out of range");
        }
    }
}
