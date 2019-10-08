using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + (float)1.3, player.transform.position.z));
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            else
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
            }
        }
    }
}
