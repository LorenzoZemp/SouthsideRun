using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject player;
    private Vector3 laserPosition;
    private float originalWidth;

    public bool shot = false;
    public GameObject god;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        originalWidth = lineRenderer.startWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (god.GetComponent<EvilRilfleScript>().timeLeft >= 1.0f)
        {
            laserPosition = new Vector3(player.transform.position.x, player.transform.position.y + (float)1.3, player.transform.position.z);
            transform.LookAt(laserPosition);
            lineRenderer.startWidth = lineRenderer.startWidth - (Time.deltaTime * 0.2f);
            lineRenderer.endWidth = lineRenderer.endWidth - (Time.deltaTime * 0.2f);
        }
        else
        {
            transform.LookAt(laserPosition);
        }

        //transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + (float)1.3, player.transform.position.z));
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance+0.5f));
                Debug.Log(hit.collider.name);
                if (shot == true && god.GetComponent<EvilRilfleScript>().timeLeft <= 0.0f)
                {
                    Debug.Log("its in here: LaserScript.46");
                    if (hit.collider.tag == "Player")
                    {
                        if(hit.collider.gameObject.GetComponent<Player>().isShielded == true)
                        {
                            hit.collider.gameObject.GetComponent<Player>().isShielded = false;
                        }
                        else if (hit.collider.gameObject.GetComponent<Player>().isShielded == false)
                        {
                            hit.collider.gameObject.GetComponent<Player>().caught = true;
                        }
                        Debug.Log("Player sniped");
                    }
                        shot = false;
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
        //lineRenderer.enabled = !lineRenderer.enabled;
        if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.startWidth = originalWidth;
        lineRenderer.endWidth = originalWidth;
    }
}
