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

    private AudioSource[] aSources;

    private void Start()
    {
        aSources = GetComponents<AudioSource>();
    }
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
                Instantiate(muzzleFlash, transform.position + transform.forward, transform.rotation);
				Instantiate (bullet, transform.position, (transform.rotation * Quaternion.Euler (0, Random.Range(-bulletSpread, bulletSpread), 0)));
                GameObject ammoShell = Instantiate(ammoUsed, transform.position, (transform.rotation * Quaternion.Euler(0, Random.Range(-bulletSpread*2, bulletSpread*2), 0)));
				ammoShell.transform.SetParent (GameObject.Find ("PermancyStuff").transform);
                ammoShell.GetComponent<Rigidbody>().AddForce(-new Vector3(transform.forward.x + Random.Range(-bulletSpread/15, bulletSpread/15), transform.forward.y, transform.forward.z + Random.Range(-bulletSpread/15, bulletSpread/15)) * 8, ForceMode.Impulse);
                GetComponentInParent<Movement>().KnockBack(knockBack, transform.forward);
                
                aSources[Random.Range(0, aSources.Length - 1)].Play();
                Time.timeScale = 0.7f;
                timeScaleReset = 0;
			}
            else
            {
                aSources[aSources.Length - 1].Play();
                canShoot = false;
                fireTimer = 0;
            }
		}

		if (fireTimer > fireSpeed)
			canShoot = true;

        if (timeScaleReset > 1)
        {
            Time.timeScale = 1;
        }

		fireTimer++;
        timeScaleReset++;
	}
		
}
