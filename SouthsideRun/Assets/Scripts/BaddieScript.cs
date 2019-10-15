using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieScript : MonoBehaviour
{
    //AudioSource audioSource;
    public AudioClip sniperZoom;
    public AudioClip sniperShoot;
    public float timeBeforeKill = 0.75f;
    public GameObject reticle;

    public void Shoot()
    {
        StartCoroutine("Kill");
    }

    IEnumerator Kill()
    {
        reticle.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(sniperZoom, 1.0f);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(timeBeforeKill);
        // TODO: add sniper shot sound
        // TODO: add death animation
        Debug.Log("SHOULD BE DEAD");
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(sniperShoot, 1.0f);
        Destroy(gameObject);
    }
}
