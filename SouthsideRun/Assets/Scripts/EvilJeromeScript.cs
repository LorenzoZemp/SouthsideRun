using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilJeromeScript : MonoBehaviour
{
    public AudioClip shootingSound;
    public float timeBetweenShots = 0.5f;
    public ParticleSystem muzzleFlash;
    public int numberOfShots = 10;
    public GameObject bulletsPrefab;
    private float shotTimer = 0.0f;
    private bool stopFiring = false;
    private AudioSource audioSource;

    public float triggerDistance = 35.0f;
    GameObject player;
    float distanceToPlayer;

    [SerializeField] private int shotsFired = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform);
        if (distanceToPlayer <= triggerDistance)
        {
            if (muzzleFlash.isStopped)
            {
                muzzleFlash.Play();
                StartCoroutine(playGunSounds());

            }
            shotTimer += Time.deltaTime;

            if (shotTimer >= timeBetweenShots && !stopFiring)
            {
                shotTimer = 0.0f;
                // fire a bullet
                Instantiate(bulletsPrefab, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z + 0.4f), Quaternion.Euler(90,0,0));

                shotsFired++;
            }

            //// destroy once finished firing
            //if (shotsFired >= numberOfShots)
            //{
            //    stopFiring = true;
            //}

            //// check if all bullets are gone so we can safely delete
            //if (stopFiring)
            //{
            //    int numBullets = 0;
            //    for (int i = 0; i < transform.childCount; i++)
            //    {
            //        if (transform.GetChild(i).tag == "Bullet")
            //        {
            //            numBullets++;
            //        }
            //    }

            //    if (numBullets == 0)
            //    {
            //        //Destroy(this.gameObject);
            //    }
            //}
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
        audioSource.clip = shootingSound;
        audioSource.PlayOneShot(shootingSound, 0.2f);
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.PlayOneShot(shootingSound, 0.2f);
    }
}
