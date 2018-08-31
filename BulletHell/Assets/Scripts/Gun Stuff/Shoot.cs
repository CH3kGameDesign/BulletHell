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
    public Image ammoBar;
    public float ammo;
    public float pastAmmo;
	public float ammoLimit;

	public GameObject bullet;
    public GameObject ammoUsed;
    public GameObject muzzleFlash;

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
        
		if (GameObject.Find ("PlayerHands").transform.childCount != 0) {
			activeGun = GameObject.Find ("PlayerHands").transform.GetChild (0).gameObject;
			Debug.Log (activeGun.name);
			if (activeGun.tag == "Gun") {
				activeGun.GetComponent<FaceDirection> ().enabled = true;
				activeGun.transform.localPosition = Vector3.Lerp (activeGun.transform.localPosition, new Vector3 (activeGun.transform.localPosition.x, activeGun.transform.localPosition.y, 0), 0.1f);
				aSources = activeGun.GetComponents<AudioSource> ();
				if (Input.GetMouseButton (0) && canShoot == true) {
					if (ammo > 0) {
						Debug.Log ("BOOOM");
						canShoot = false;
						fireTimer = 0;
						ammo -= 1;
                        Inventory.shotsFired++;
                        Inventory.shotsFiredTotal++;

                        Instantiate (muzzleFlash, activeGun.transform.GetChild(0).gameObject.transform.position + activeGun.transform.forward, transform.rotation);

						Instantiate (bullet, activeGun.transform.GetChild(0).gameObject.transform.position + activeGun.transform.forward, (activeGun.transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread, activeGun.GetComponent<GunData> ().bulletSpread), 0)));

						GameObject ammoShell = Instantiate (ammoUsed, activeGun.transform.GetChild(0).gameObject.transform.position, (transform.rotation * Quaternion.Euler (0, Random.Range (-activeGun.GetComponent<GunData> ().bulletSpread * 2, activeGun.GetComponent<GunData> ().bulletSpread * 2), 0)));
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
				}

				if (fireTimer > activeGun.GetComponent<GunData> ().fireSpeed)
					canShoot = true;

				if (timeScaleReset > 1) {
					Time.timeScale = 1;
				}

				fireTimer++;
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

    private void UpdateAmmo ()
    {
        ammo = Inventory.ammo;
    }
		
}
