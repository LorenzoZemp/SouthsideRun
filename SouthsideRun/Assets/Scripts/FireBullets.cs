using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireBullets : MonoBehaviour
{
    public float timeBetweenShots = 0.25f;
    public int numberOfShots = 5;
    public GameObject bulletsPrefab;
    private float shotTimer = 0.0f;
    private bool stopFiring = false;

    [SerializeField] private int shotsFired = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= timeBetweenShots && !stopFiring)
        {
            shotTimer = 0.0f;

            // fire a bullet
            Instantiate(bulletsPrefab, transform);
            //Instantiate(bulletsPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), true);

            shotsFired++;
        }

        // destroy once finished firing
        if (shotsFired >= numberOfShots)
        {
            stopFiring = true;
        }

        // check if all bullets are gone so we can safely delete
        if (stopFiring)
        {
            int numBullets = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag == "Bullet")
                {
                    numBullets++;
                }
            }

            if (numBullets == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    int CountBullets(Transform a)
    {
        int bulletCount = 0;

        foreach (Transform b in a)
        {
            if (b.tag == "Bullet")
            {
                bulletCount++;
                bulletCount += CountBullets(b);
            }
        }
        return bulletCount;
    }
}


