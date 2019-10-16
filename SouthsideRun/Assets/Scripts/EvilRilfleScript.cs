using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRilfleScript : MonoBehaviour
{
    public GameObject rifleBarrel;
    public float timeToShoot = 5.0f;
    public AudioClip sniperCharge;
    public AudioClip sniperShot;
    //public bool sniperEnabled = false;

    private bool shot = false;
    private bool hasPlayedCharged = false;
    private bool hasPlayedShot = false;
    public float timeLeft;
    private GameObject player;
    private float sniperHeight = 8.6f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeToShoot;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 8.0f);

           if (shot == false)
            {
                timeLeft -= Time.deltaTime;
            if (hasPlayedCharged == false)
            {
                StartCoroutine(playChargeSound());
                hasPlayedCharged = true;
            }
                Debug.Log(timeLeft);
            }
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
        if (hasPlayedShot == false)
        {
            StartCoroutine(playShootSound());
            hasPlayedShot = true;
        }
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

    private IEnumerator playShootSound()
    {
        audioSource.clip = sniperShot;
        audioSource.PlayOneShot(sniperShot);
        yield return null;
    }

    private IEnumerator playChargeSound()
    {
        audioSource.clip = sniperCharge;
        audioSource.PlayOneShot(sniperCharge);
        yield return null;
    }
}
