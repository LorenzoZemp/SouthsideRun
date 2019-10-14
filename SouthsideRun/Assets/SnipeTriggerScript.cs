using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeTriggerScript : MonoBehaviour
{
    public GameObject sniper;
    //public GameObject laser;
    //private bool triggered = false;

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
        //triggered = true;
       /* if (other.tag == "Player")
        {
            //sniper.GetComponent<EvilRilfleScript>().sniperEnabled = true;
            //sniper.GetComponent<EvilRilfleScript>().resetRifle();
            //laser.GetComponent<LaserScript>().lineRenderer.enabled = true;
            Instantiate(sniper);
            Debug.Log("spawn sniper");
        }*/
    }

    //delete the trigger once the player has gone through
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("spawn sniper");
            Instantiate(sniper);
            Destroy(gameObject);
        }
    }

    //private IEnumerator OnTriggerEnter(Collider other)
    //{
    //    yield return null;
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("spawn sniper");
    //        Instantiate(sniper);
    //        Destroy(gameObject);
    //    }
    //}
}
