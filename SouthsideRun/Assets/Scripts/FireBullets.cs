using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireBullets : MonoBehaviour
{
    public AudioClip shootingSound;
    public float timeBetweenShots = 0.25f;
    public int numberOfShots = 5;
    public GameObject bulletsPrefab;
    private float shotTimer = 0.0f;
    private bool stopFiring = false;
    private AudioSource audioSorce;

    [SerializeField] private int shotsFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();

        StartCoroutine(playGunSounds());
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= timeBetweenShots && !stopFiring)
        {
            shotTimer = 0.0f;
            // fire a bullet
            Instantiate(bulletsPrefab, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z + 0.4f), Quaternion.Euler(90,0,0));
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

    IEnumerator playGunSounds()
    {
        audioSorce.clip = shootingSound;
        audioSorce.PlayOneShot(shootingSound, 0.2f);
        yield return new WaitForSeconds(audioSorce.clip.length);
        audioSorce.PlayOneShot(shootingSound, 0.2f);
    }
}


