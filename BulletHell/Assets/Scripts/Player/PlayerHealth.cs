using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int healthLimit;
    public int health;

    private int pastHealth;

    public Text healthCounter;
    public bool invulnerable;

	// Use this for initialization
	void Start () {
        health = healthLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Debug.Log("You're Dead");
        }
        healthCounter.text = "Health: " + health;
        if (health != pastHealth)
        {
            invulnerable = true;
            Invoke("disableInvulnerability", 1.5f);
        }
        pastHealth = health;
	}

    private void disableInvulnerability ()
    {
        invulnerable = false;
    }
}
