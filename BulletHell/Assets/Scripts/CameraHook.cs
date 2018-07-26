using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHook : MonoBehaviour {

    public GameObject cameraHook;
    public float cameraSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraHook.transform.position, cameraSpeed);
    }
}
