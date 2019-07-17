using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraHeight = 2;
    public float cameraDistance = -5;

    // Update is called once per frame
    void Update()
    {
        float x = Player.CurrentPlayer.transform.position.x;
        float y = cameraHeight;
        float z = Player.CurrentPlayer.transform.position.z + cameraDistance;

        transform.position = new Vector3(x, y, z);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
