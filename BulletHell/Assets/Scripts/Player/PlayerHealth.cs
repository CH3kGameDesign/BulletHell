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


	private RectTransform rectTransform;
	private Vector2 uiOffset;

	// Use this for initialization
	void Start () {
        health = healthLimit;
        pastHealth = health;
        Invoke("UpdateHealth", 0.0001f);

		rectTransform = healthBar.GetComponent<RectTransform>();
		uiOffset = new Vector2((float)Camera.main.pixelWidth / 2f, (float)Camera.main.pixelHeight / 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Debug.Log("You're Dead");
        }
        healthCounter.text = "Health: " + health;
        healthBar.fillAmount = 0.1f * health;
		//healthBar.rectTransform.position = Camera.main.WorldToScreenPoint(GameObject.Find("Player").transform.position);
		//healthBar.rectTransform.position = Camera.main.WorldToViewportPoint(GameObject.Find("Player").transform.position);
		MoveToClickPoint();

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


	public void MoveToClickPoint()
	{
			// Get the position on the canvas
		Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(GameObject.Find("Player").transform.position);
		Vector2 proportionalPosition = new Vector2 (ViewportPosition.x * Camera.main.pixelWidth, ViewportPosition.y * Camera.main.pixelHeight);

			// Set the position and remove the screen offset
		rectTransform.localPosition = proportionalPosition - uiOffset;
	}
}
