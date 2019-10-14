using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRilfleScript : MonoBehaviour
{
    public GameObject rifleBarrel;
    public float timeToShoot = 5.0f;
    //public bool sniperEnabled = false;

    private bool shot = false;
    public float timeLeft;
    private GameObject player;
    private float sniperHeight = 8.6f;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeToShoot;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 8.0f);

           // if (shot == false)
            //{
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft);
            //}
            if (timeLeft <= 0.0f && shot == false)
            {
                fire();
                Debug.Log("shot from evs");
            }
       
    }

    private void fire()
    {
        //Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z + 0.4f), Quaternion.Euler(90, 0, 0));
        shot = true;
        //Debug.Log(shot);
        rifleBarrel.GetComponent<LaserScript>().shot = true;
        rifleBarrel.GetComponent<LaserScript>().toggleLaser();
        Debug.Log("FIRED");
        //sniperEnabled = false;
        StartCoroutine(waitToDestroy());
    }

    private IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
   /* public void resetRifle()
    {
        shot = false;
        //Debug.Log("pls toggle");
        timeLeft = timeToShoot;
    }*/
}
