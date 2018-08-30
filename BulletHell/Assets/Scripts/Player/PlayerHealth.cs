using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int healthLimit;
    public int health;

    private int pastHealth;

    public Text healthCounter;
    public Image healthBar;
    public bool invulnerable;

	// Use this for initialization
	void Start () {
        health = healthLimit;
        pastHealth = health;
        Invoke("UpdateHealth", 0.0001f);
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Debug.Log("You're Dead");
        }
        healthCounter.text = "Health: " + health;
        healthBar.fillAmount = 0.1f * health;
        healthBar.rectTransform.position = Camera.main.WorldToScreenPoint(GameObject.Find("Player").transform.position);
        if (health != pastHealth)
        {
            invulnerable = true;
            Invoke("disableInvulnerability", 1.5f);
            Inventory.health = health;
        }
        if (health > healthLimit)
        {
            health = healthLimit;
        }
        pastHealth = health;
	}

    private void UpdateHealth()
    {
        health = Inventory.health;
    }

    private void disableInvulnerability ()
    {
        invulnerable = false;
    }
}
