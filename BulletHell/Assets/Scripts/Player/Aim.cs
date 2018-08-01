using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        int layer_mask = LayerMask.GetMask("Cursor Detector");
        RaycastHit hit;

		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100, layer_mask)) {
			transform.position = hit.point;
		}

		transform.localPosition = new Vector3 (transform.localPosition.x, 0, transform.localPosition.z);
	}
}
