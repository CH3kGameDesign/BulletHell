using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Vector3 origPos;

    public float shakeDuration;             //Controlled by when called
    public float shakeAmount;               //Controlled by when called


    private void Start()
    {
        origPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
        if (shakeDuration > 0)
        {
            transform.localPosition = origPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = origPos;
        }
    }
}
