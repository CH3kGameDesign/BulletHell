using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour {

	//public GameObject target;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (GameObject.Find("Target").transform);
		transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0);
	}
}
