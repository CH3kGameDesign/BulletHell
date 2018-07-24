using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
			transform.position = hit.point;
		}

		transform.localPosition = new Vector3 (transform.localPosition.x, 0, transform.localPosition.z);
	}
}
