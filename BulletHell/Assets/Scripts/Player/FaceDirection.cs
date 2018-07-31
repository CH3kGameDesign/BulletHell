using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour {

	//public GameObject target;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (GameObject.Find("Target").transform);
	}
}
