using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

	public bool canShoot;

	public float fireTimer;

    public float knockBack;
    public float bulletSpread;

	public Text ammoCounter;
    public Image ammoBar;
    public float ammo;
    public float pastAmmo;
	public float ammoLimit;

	public float charge;

    private int timeScaleReset = 0;

	private GameObject activeGun;
    private AudioSource[] aSources;














    private void Start()
    {
        pastAmmo = ammo;
        Invoke("UpdateAmmo", 0.00001f);
    }













    void Update () {
		ammoCounter.text = "Ammo: " + ammo;
        ammoBar.fillAmount = ammo / ammoLimit;
	}
















	// Update is called once per frame
	void FixedUpdate () {
        
		if (GameObject.Find ("PlayerGunHands").transform.childCount != 0) {
			activeGun = GameObject.Find ("PlayerGunHands").transform.GetChild (0).gameObject;
			Debug.Log (activeGun.name);
			if (activeGun.tag == "Gun") {
				activeGun.GetComponentInChildren<FaceDirection> ().enabled = true;
				//activeGun.GetComponentInChildren<SpriteChangeGuns> ().playerModel = this.gameObject;
				activeGun.transform.localPosition = Vector3.Lerp (activeGun.transform.localPosition, new Vector3 (activeGun.transform.localPosition.x, activeGun.transform.localPosition.y, 0), 0.1f);
				aSources = activeGun.GetComponents<AudioSource> ();
				if (Input.GetMouseButton (0) && canShoot == true && GetComponentInParent<Movement> ().rolling == false) {
					charge += Time.deltaTime;
					if (charge >= activeGun.GetComponent<GunData> ().chargeTime)
						Fire ();
					else
						if (ammo > 0)
							Instantiate (activeGun.GetComponent<GunData> ().muzzleFlash, activeGun.transform.GetChild (0).gameObject.transform.position + activeGun.transform.forward, transform.rotation);
				} else
					charge = 0;

				if (fireTimer > activeGun.GetComponent<GunData> ().fireSpeed)
					canShoot = true;

				if (timeScaleReset > 1) {
					Time.timeScale = 1;
				}

				fireTimer+= Time.deltaTime;
				timeScaleReset++;

				activeGun.GetComponent<GunData> ().transform.localPosition = new Vector3 (-activeGun.GetComponent<GunData> ().playerPosition.x, activeGun.transform.localPosition.y, activeGun.transform.localPosition.z);
				//transform.localPosition = Vector3.Lerp (transform.localPosition, activeGun.GetComponent<GunData> ().playerPosition, 0.5f);
			}
		}

		if (ammo > ammoLimit)
			ammo = ammoLimit;

        if (ammo != pastAmmo)
            Inventory.ammo = ammo;

        pastAmmo = ammo;
	}



























	private void Fire ()
	{
		if (ammo > 0) {
			Debug.Log ("BOOOM");
			canShoot = false;
			fireTimer = 0;
			ammo -= 1;
			Inventory.shotsFired++;
			Inventory.shotsFiredTotal++;

			Instantiate (activeGun.GetComponent<GunData> ().muzzleFlash, activeGun.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.position/* + activeGun.transform.forward*/, transform.GetChild (0).gameObject.transform.rotation);
			Instantiate (activeGun.GetComponent<GunData> ().bullet, activeGun.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.position/* + activeGun.transform.forward*/, (activeGun.transform.GetChild (0).gameObject.transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread, activeGun.GetComponent<GunData> ().bulletSpread), 0)));

			GameObject ammoShell = Instantiate (activeGun.GetComponent<GunData> ().ammoUsed, activeGun.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.transform.position, (transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread * 2, activeGun.GetComponent<GunData> ().bulletSpread * 2), 0)));
			ammoShell.transform.SetParent (GameObject.Find ("PermancyStuff").transform);
			ammoShell.GetComponent<Rigidbody> ().AddForce (-new Vector3 (transform.forward.x + Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread / 15, activeGun.GetComponent<GunData> ().bulletSpread / 15), transform.forward.y, transform.forward.z + Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread / 15, activeGun.GetComponent<GunData> ().bulletSpread / 15)) * 8, ForceMode.Impulse);

			GetComponentInParent<Movement> ().KnockBack (activeGun.GetComponent<GunData> ().knockBack, transform.forward);

			aSources [Random.Range (0, aSources.Length - 1)].Play ();

			activeGun.transform.localPosition = new Vector3 (activeGun.transform.localPosition.x, activeGun.transform.localPosition.y, -0.3f);

			Time.timeScale = 0.7f;
			timeScaleReset = 0;
		}

		if (ammo < 5) {
			aSources [aSources.Length - 1].Play ();
			canShoot = false;
			fireTimer = 0;
		}
		charge = 0;
	}



















    private void UpdateAmmo ()
    {
        ammo = Inventory.ammo;
    }
		
}
