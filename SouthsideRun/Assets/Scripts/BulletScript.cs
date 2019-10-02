using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject killEffect;
    public float bulletSpeed = 3.0f;
    public float travelDistance = 60.0f;
    public Rigidbody rb;

    private float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.z;
        rb.velocity = new Vector3(0.0f, 0.0f, bulletSpeed);
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
}
