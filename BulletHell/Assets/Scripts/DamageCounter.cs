using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : MonoBehaviour {

	public Material transparent;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce( new Vector3 (Random.Range(-2, 2), Random.Range(1, 3), Random.Range(-2, 2)), ForceMode.Impulse);
		Invoke ("Destroy", 2);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<MeshRenderer> ().material.color = Color.Lerp (GetComponent<MeshRenderer> ().material.color, transparent.color, 0.05f);
	}

	private void Destroy () {
		Destroy (this.gameObject);
	}
}
