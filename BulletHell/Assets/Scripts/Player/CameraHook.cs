using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHook : MonoBehaviour {

    public GameObject cameraHook;
    public GameObject cursor;
    public float cameraSpeed;

	private Vector3 newPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Inventory.menuOpen == true)
			newPosition = Vector3.Lerp (transform.position, cameraHook.transform.position, cameraSpeed/2);
		else
        	newPosition = Vector3.Lerp(transform.position, new Vector3((cameraHook.transform.position.x * 3 + cursor.transform.position.x) / 4, cameraHook.transform.position.y, (cameraHook.transform.position.z * 3 + cursor.transform.position.z) / 4), cameraSpeed);
        GetComponent<Rigidbody>().MovePosition(newPosition);
    }
}
