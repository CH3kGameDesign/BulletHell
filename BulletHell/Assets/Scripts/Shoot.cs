using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public bool canShoot;
	public int fireTimer;
	public int fireSpeed;

	public GameObject bullet;
	public GameObject target;

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0) && canShoot == true) {
			Debug.Log ("BOOOM");
			canShoot = false;
			fireTimer = 0;
			Instantiate (bullet, transform.position, transform.rotation);
		}

		if (fireTimer > fireSpeed)
			canShoot = true;

		fireTimer++;
	}
}
