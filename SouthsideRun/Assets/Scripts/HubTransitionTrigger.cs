using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubTransitionTrigger : MonoBehaviour
{
    public string toLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch(toLevel)
            {
                //Tutorial Level -> Hub1
                case "HUB1":
                    SceneManager.LoadScene("HUB Level 1");
                    break;
                //Hub1 -> Level1;
                case "LEVEL1":
                    SceneManager.LoadScene("Level 1");
                    break;
                //Level1 -> Hub2
                case "HUB2":
                    SceneManager.LoadScene("HUB Level 2");
                    break;
                //Hub -> Level2;
                case "LEVEL2":
                    SceneManager.LoadScene("Level 2");
                    break;
                //Level2 -> Hub3;
                case "HUB3":
                    SceneManager.LoadScene("HUB Level 3");
                    break;
                //Hub -> Level3;
                case "LEVEL3":
                    SceneManager.LoadScene("Level 3");
                    break;
                default:
                    break;
            }
        }
    }
}
