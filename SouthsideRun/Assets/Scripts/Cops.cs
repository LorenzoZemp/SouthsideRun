using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cops : MonoBehaviour
{
    // PUBLIC
    public float movespeed = 3.3333f;

    // PRIVATE
    private bool chasing = true;

    // Start is called before the first frame update
    void Start()
    {
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
