using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject killEffect;
    public float bulletSpeed = 3.0f;
    public float travelDistance = 60.0f;
    public Rigidbody rb;
    public bool badBullet = false;

    private float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        //initialPos = transform.position.z;
        //if(badBullet == false)
        //{
        //    rb.velocity = new Vector3(0.0f, 0.0f, bulletSpeed);
        //}
        //else
        //{
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            rb.velocity = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y - 1.0f, transform.position.z - player.transform.position.z);
            rb.velocity = rb.velocity.normalized;
            rb.velocity = rb.velocity * bulletSpeed;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //// move the bullet
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + bulletSpeed * Time.deltaTime);

        // if it's far enoguh then delete it
        if (Mathf.Abs(transform.position.z - initialPos) > travelDistance)
        {
            //Debug.Log("Destroy Bullet");
            Destroy(this.gameObject);
        }
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    //Debug.Log("Hit Something");
    //    //if (collision.gameObject.tag == "Cops")
    //    //{
    //    //    Debug.Log("Hit a cop");
    //    //    Instantiate(killEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    //    //    Destroy(collision.gameObject);
    //    //}
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Something");
        if (other.tag == "Props")
        {
            StartCoroutine(waitToDestroy());
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(waitToDestroy());
        }
    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
