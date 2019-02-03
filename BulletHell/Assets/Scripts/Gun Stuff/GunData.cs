using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData : MonoBehaviour {

	public float fireSpeed;
	public float knockBack;
	public float bulletSpread;

	public float chargeTime;

	public Vector3 playerPosition;

	public GameObject bullet;
	public GameObject ammoUsed;
	public GameObject muzzleFlash;

	// Use this for initialization
	void Start () {
		
	}
}
