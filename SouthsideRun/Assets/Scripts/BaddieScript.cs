using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieScript : MonoBehaviour
{
    public float timeBeforeKill = 0.75f;
    public GameObject reticle;

    public void Shoot()
    {
        StartCoroutine("Kill");
    }

    IEnumerator Kill()
    {
        reticle.SetActive(true);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(timeBeforeKill);
        // TODO: add sniper shot sound
        // TODO: add death animation
        Debug.Log("SHOULD BE DEAD");
        Destroy(gameObject);
    }
}
