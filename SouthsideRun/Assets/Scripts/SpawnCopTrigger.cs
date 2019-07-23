using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCopTrigger : MonoBehaviour
{
    public GameObject copPrefab;
    public float spawnDistance = 10.0f;

    bool hasSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && hasSpawned == false)
        {
            Debug.Log("Please spawn");
            Instantiate(copPrefab, new Vector3(other.transform.position.x, other.transform.position.y + 2, other.transform.position.z + spawnDistance), Quaternion.Euler(0, 180, 0));
            hasSpawned = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
