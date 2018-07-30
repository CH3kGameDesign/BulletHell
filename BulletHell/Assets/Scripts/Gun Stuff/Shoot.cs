using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public bool canShoot;

	public int fireTimer;
	public int fireSpeed;

    public float knockBack;
    public float bulletSpread;

	public Text ammoCounter;
	public int ammo;
	public int ammoLimit;

	public GameObject bullet;
    public GameObject ammoUsed;
    public GameObject muzzleFlash;

    private int timeScaleReset = 0;

	private GameObject activeGun;
    private AudioSource[] aSources;



    private void Start()
    {
		
    }
    void Update () {
		ammoCounter.text = "Ammo: " + ammo; 
	}

	// Update is called once per frame
	void FixedUpdate () {
		activeGun = Inventory.inventoryList [GetComponentInParent<InventorySelect> ().activeSlot];
		if (activeGun.tag == "Gun") {
			aSources = activeGun.GetComponents<AudioSource>();
			if (Input.GetMouseButton (0) && canShoot == true) {
				if (ammo > 0) {
					Debug.Log ("BOOOM");
					canShoot = false;
					fireTimer = 0;
					ammo -= 1;
					Instantiate (muzzleFlash, transform.position + transform.forward, transform.rotation);
					Instantiate (bullet, transform.position, (transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData>().bulletSpread, activeGun.GetComponent<GunData>().bulletSpread), 0)));
					GameObject ammoShell = Instantiate (ammoUsed, transform.position, (transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData>().bulletSpread * 2, activeGun.GetComponent<GunData>().bulletSpread * 2), 0)));
					ammoShell.transform.SetParent (GameObject.Find ("PermancyStuff").transform);
					ammoShell.GetComponent<Rigidbody> ().AddForce (-new Vector3 (transform.forward.x + Random.Range (-activeGun.GetComponent<GunData>().bulletSpread / 15, activeGun.GetComponent<GunData>().bulletSpread / 15), transform.forward.y, transform.forward.z + Random.Range (-activeGun.GetComponent<GunData>().bulletSpread / 15, activeGun.GetComponent<GunData>().bulletSpread / 15)) * 8, ForceMode.Impulse);
					GetComponentInParent<Movement> ().KnockBack (activeGun.GetComponent<GunData>().knockBack, transform.forward);
                
					aSources [Random.Range (0, aSources.Length - 1)].Play ();
					Time.timeScale = 0.7f;
					timeScaleReset = 0;
				}
				if (ammo < 5) {
					aSources [aSources.Length - 1].Play ();
					canShoot = false;
					fireTimer = 0;
				}
			}

			if (fireTimer > activeGun.GetComponent<GunData>().fireSpeed)
				canShoot = true;

			if (timeScaleReset > 1) {
				Time.timeScale = 1;
			}

			fireTimer++;
			timeScaleReset++;
		}
	}
		
}
