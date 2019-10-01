using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCopScript : MonoBehaviour
{
    // PUBLIC
    public float movespeed = 3.3333f;
    public GameObject player;

    // PRIVATE
    private bool chasing = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            chasing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movespeed * Time.deltaTime);
        }
    }

    public void setChasing(bool _b)
    {
        chasing = _b;
    }
}
