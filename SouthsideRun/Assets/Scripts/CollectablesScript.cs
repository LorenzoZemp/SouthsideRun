using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectablesScript : MonoBehaviour
{
    public TextMeshProUGUI itemsCollected;

    // Update is called once per frame
    void Update()
    {
        itemsCollected.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stuffCollected.ToString();
    }
}
