using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour {

    public int ammoAmount;

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.GetComponentInChildren<Shoot> ().ammo += ammoAmount;
			Destroy (this.gameObject);
		}
	}
}
