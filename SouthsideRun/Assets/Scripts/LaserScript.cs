using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject player;

    public bool shot = false;
    public GameObject god;
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
                lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance+0.5f));
                //Debug.Log(hit.collider.name);
                if (shot == true && god.GetComponent<EvilRilfleScript>().timeLeft <= 0.0f)
                {
                    if (hit.collider.tag == "Player")
                    {
                        //hit.collider.gameObject.GetComponent<Player>().caught = true;
                        //shot = false;
                    }
                }
            }
            else
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
            }
        }
    }

    public void toggleLaser()
    {
        lineRenderer.enabled = !lineRenderer.enabled;
    }
}
