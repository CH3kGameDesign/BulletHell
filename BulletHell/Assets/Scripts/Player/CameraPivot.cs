using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

	public float rotation;

	// Use this for initialization
	void Start () {
		rotation = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localRotation = Quaternion.Lerp (transform.localRotation, Quaternion.Euler(rotation, 0, 0), 0.05f);
	}
}
