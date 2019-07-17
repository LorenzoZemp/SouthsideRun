using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cops : MonoBehaviour
{
    // PUBLIC
    public float movespeed = 3.3333f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + movespeed * Time.deltaTime);
    }
}
