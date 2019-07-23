using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCopTrigger : MonoBehaviour
{
    public GameObject copPrefab;
    public float spawnDistance = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Please spawn");
            Instantiate(copPrefab, new Vector3(other.transform.position.x, other.transform.position.y + 2, other.transform.position.z + spawnDistance), Quaternion.Euler(0, 180, 0));
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
