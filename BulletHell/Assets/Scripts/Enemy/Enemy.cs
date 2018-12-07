using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject deadGuy;
    public int Health;

	public List<GameObject> drops;

    public Vector3 bulletPos;

	public float fireRate;
	private float fireCoolDown;
    public float fireSetRate;
    public int fireSetAmount;
    private int fireSetAmountCount;
    private float fireSetCoolDown;
    public float bulletSpread;

	public int AttackType;

	public GameObject bullet;
    	
	// Update is called once per frame
	void Update () {
		if (Health <= 0)
        {
            GameObject explodeGuy = Instantiate(deadGuy, transform.position, transform.rotation);
			explodeGuy.transform.SetParent(GameObject.Find("PermancyStuff").transform);
            explodeGuy.GetComponent<Rigidbody>().AddExplosionForce(500, bulletPos, 10);
            

			int randomDrop = Random.Range (0, drops.Capacity);
			Debug.Log (randomDrop);

			if (drops[randomDrop] != null)
				Instantiate (drops [randomDrop], transform.position, transform.rotation);
            
            Destroy(this.gameObject);
        }


	}

	public void PreAttack () {
		if (AttackType == 1)
			Attack1 ();
		if (AttackType == 2)
			Attack2 ();
		if (AttackType == 3)
			Attack3 ();
        if (AttackType == 4)
            Attack4();
    }

	public void Attack1 () {
		if (fireCoolDown > fireRate)
		{
			Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, Random.Range(-bulletSpread, bulletSpread), 0));
			fireCoolDown = 0;
		}
		fireCoolDown += Time.deltaTime;
	}

	public void Attack2 () {
		if (fireCoolDown > fireRate)
		{
			for (int i = 0; i < 6; i++) {
				Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, Random.Range(-bulletSpread, bulletSpread) + (i*60), 0));
			}

			fireCoolDown = 0;
		}
		fireCoolDown += Time.deltaTime;
	}

    public void Attack3()
    {
        if (fireCoolDown > fireRate)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject GO = Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, Random.Range(-bulletSpread, bulletSpread), 0));
                GO.GetComponent<Bullet>().bulletSpeed = 10 + (i * 2);
            }
            fireCoolDown = 0;
        }
        fireCoolDown += Time.deltaTime;
    }

    public void Attack4()
    {
        if (fireCoolDown > fireRate)
        {
            if (fireSetCoolDown > fireSetRate)
            {
                GameObject GO = Instantiate(bullet, transform.position, transform.rotation);
                GO.transform.parent = this.gameObject.transform;
                fireSetCoolDown = 0;
                fireSetAmountCount++;
            }
            if (fireSetAmountCount > fireSetAmount)
            {
                fireCoolDown = 0;
                fireSetAmountCount = 0;
                fireSetCoolDown = 0;
            }
            
        }
        fireCoolDown += Time.deltaTime;
        fireSetCoolDown += Time.deltaTime;
    }
}
