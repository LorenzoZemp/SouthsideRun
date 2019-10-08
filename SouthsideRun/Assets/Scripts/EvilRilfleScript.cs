using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRilfleScript : MonoBehaviour
{
    public GameObject rifleBarrel;
    public GameObject bulletPrefab;
    public float timeToShoot = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToShoot -= Time.deltaTime;
        if (timeToShoot - Time.deltaTime <= 0.0)
        {
            fire();
        }
    }

    private void fire()
    {
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z + 0.4f), Quaternion.Euler(90, 0, 0));
    }
}
