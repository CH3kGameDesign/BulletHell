using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject deadGuy;
    public int Health;

    public Vector3 bulletPos;
    	
	// Update is called once per frame
	void Update () {
		if (Health <= 0)
        {
            GameObject explodeGuy = Instantiate(deadGuy, transform.position, transform.rotation);
            explodeGuy.GetComponent<Rigidbody>().AddExplosionForce(500, bulletPos, 10);
            Destroy(this.gameObject);
        }
	}
}
