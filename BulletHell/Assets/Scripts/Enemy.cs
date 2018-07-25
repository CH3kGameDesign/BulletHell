using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health;
    	
	// Update is called once per frame
	void Update () {
		if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
