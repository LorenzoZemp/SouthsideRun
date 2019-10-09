using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject shield;
    public GameObject jump;
    public GameObject sniper;
    public GameObject speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // switches the phone in the overlay to match what is provided in the function
    public void SwitchPhone(PHONE _type)
    {
        shield.SetActive(false);
        jump.SetActive(false);
        sniper.SetActive(false);
        speed.SetActive(false);
        switch (_type)
        {
            case PHONE.JUMP:
                jump.SetActive(true);
                break;
            case PHONE.SHIELD:
                shield.SetActive(true);
                break;
            case PHONE.SNIPER:
                sniper.SetActive(true);
                break;
            case PHONE.SPEED:
                speed.SetActive(true);
                break;
            default:break;
        }
    }
}
