using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWalls : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Enemies").transform.childCount == 0) {
			for (int i = 0; i < transform.childCount; i++) {
				Destroy (transform.GetChild (i).gameObject);
			}
		}
	}
}
