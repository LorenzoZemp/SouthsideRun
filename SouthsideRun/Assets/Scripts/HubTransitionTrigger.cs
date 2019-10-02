using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubTransitionTrigger : MonoBehaviour
{
    public int toLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            switch(toLevel)
            {
                case 1:
                    SceneManager.LoadScene("Level1Test");
                    break;
                case 2:
                    //SceneManager.LoadScene("Level2");
                    break;
                case 3:
                    //SceneManager.LoadScene("Level3");
                    break;
                default:
                    break;
            }
        }
    }
}
