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

    public Image iconGun;
    public Image iconShoe;
    public Image iconCar;

    public float iconUnavailableAlpha = 0.25f;

    //public GameObject whiteHighlight;
    public RectTransform whiteHighlight;
    [SerializeField] private int currentSelection = 0;
    private int totalSelection = 3;

    // Start is called before the first frame update
    void Start()
    {
        setSelection();
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

        setIconAlpha();
    }

    public void setIconAlpha()
    {
  
        if (!playerScript.CheckNumber(0))
        {
            var tempColor = iconGun.color;
            tempColor.a = iconUnavailableAlpha;
            iconGun.color = tempColor;
        }
        else
        {
            var tempColor = iconGun.color;
            tempColor.a = 1f;
            iconGun.color = tempColor;
        }

        if (!playerScript.CheckNumber(1))
        {
            var tempColor = iconShoe.color;
            tempColor.a = iconUnavailableAlpha;
            iconShoe.color = tempColor;
        }
        else
        {
            var tempColor = iconShoe.color;
            tempColor.a = 1f;
            iconShoe.color = tempColor;
        }

        if (!playerScript.CheckNumber(2))
        {
            var tempColor = iconCar.color;
            tempColor.a = iconUnavailableAlpha;
            iconCar.color = tempColor;
        }
        else
        {
            var tempColor = iconCar.color;
            tempColor.a = 1f;
            iconCar.color = tempColor;
        }
    }

    public void moveSelectRight()
    {
        if (currentSelection < totalSelection - 1)
        {
            currentSelection++;
            setSelection();
        }
    }
    public void moveSelectLeft()
    {
        if (currentSelection > 0)
        {
            currentSelection--;
            setSelection();

        }
    }

    private void setSelection()
    {
        switch (currentSelection)
        {
            case 0:
                whiteHighlight.anchoredPosition = new Vector3(480, -335, 0);
                break;
            case 1:
                whiteHighlight.anchoredPosition = new Vector3(584, -335, 0);
                break;
            case 2:
                whiteHighlight.anchoredPosition = new Vector3(684, -335, 0);
                break;
            default:
                break;
        }
            
    }

    public int getCurrentSelection () { return currentSelection; }

    public void ExitGame()
    {
        Application.Quit();
    }
}
