using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHook : MonoBehaviour {

    public GameObject cameraHook;
    public GameObject cursor;
    public float cameraSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3((cameraHook.transform.position.x * 3 + cursor.transform.position.x)/4, cameraHook.transform.position.y, (cameraHook.transform.position.z * 3+ cursor.transform.position.z) / 4), cameraSpeed);
    }
}
