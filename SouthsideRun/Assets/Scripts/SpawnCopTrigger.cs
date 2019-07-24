using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCopTrigger : MonoBehaviour
{
    public GameObject copPrefab;
    public AudioClip triggerSound;
    public float spawnDistance = 10.0f;

    bool hasSpawned;
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && hasSpawned == false)
        {
            Debug.Log("Please spawn");
            Instantiate(copPrefab, new Vector3(other.transform.position.x, other.transform.position.y + 2, other.transform.position.z + spawnDistance), Quaternion.Euler(0, 180, 0));
            hasSpawned = true;

            if (triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound, 0.1f);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
