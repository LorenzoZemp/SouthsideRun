using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    // PUBLIC
    public TextMeshProUGUI NumbersText;
    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //NumbersText.text = "0:" + playerScript.numsCollected[0] + "   1:" + playerScript.numsCollected[1] + "   2:" + playerScript.numsCollected[2]
        //    + "   3:" + playerScript.numsCollected[3] + "   4:" + playerScript.numsCollected[4] + "   5:" + playerScript.numsCollected[5]
        //    + "   6:" + playerScript.numsCollected[6] + "   7:" + playerScript.numsCollected[7] + "   8:" + playerScript.numsCollected[8]
        //    + "   9:" + playerScript.numsCollected[9];

        string phoneBufferOutput = "";

        for (int i = 0; i < playerScript.numsCollectedLimited.Length; i++)
        {
            phoneBufferOutput += playerScript.numsCollectedLimited[i] + "   ";
        }

        NumbersText.text = phoneBufferOutput;
    }
}
