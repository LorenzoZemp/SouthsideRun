using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeTriggerScript : MonoBehaviour
{
    public GameObject sniper;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("reset sniper");
            //sniper.GetComponent<EvilRilfleScript>().sniperEnabled = true;
            sniper.GetComponent<EvilRilfleScript>().resetRifle();
            laser.GetComponent<LaserScript>().lineRenderer.enabled = true;
        }
    }

    //delete the trigger once the player has gone through
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("i kms");
            Destroy(gameObject);
        }
    }
}
