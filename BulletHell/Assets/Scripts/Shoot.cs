using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public bool canShoot;

	public int fireTimer;
	public int fireSpeed;

	public Text ammoCounter;
	public int ammo;
	public int ammoLimit;

	public GameObject bullet;
	public GameObject target;

	void Update () {
		ammoCounter.text = "Ammo: " + ammo; 
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0) && canShoot == true) {
			if (ammo > 0) {
				Debug.Log ("BOOOM");
				canShoot = false;
				fireTimer = 0;
				ammo -= 1;
				Instantiate (bullet, transform.position, transform.rotation);
			}
		}

		if (fireTimer > fireSpeed)
			canShoot = true;

		fireTimer++;
	}
		
}
