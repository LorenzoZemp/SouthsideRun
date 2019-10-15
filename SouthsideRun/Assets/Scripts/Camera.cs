using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraHeight = 2.0f;
    public float cameraDistance = -5.0f;
    public float cameraXRotation = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float x = Player.CurrentPlayer.transform.position.x;
        float y;
        if (Player.CurrentPlayer.transform.position.y >= 0.0f)
        {
            y = cameraHeight + Player.CurrentPlayer.transform.position.y;
        }
        else
        {
            y = cameraHeight;
        }
        float z = Player.CurrentPlayer.transform.position.z + cameraDistance;

        transform.position = new Vector3(x, y, z);
        transform.rotation = Quaternion.Euler(cameraXRotation, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
    }
}
