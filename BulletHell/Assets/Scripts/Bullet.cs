using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 20;
	public float pushForce = 1;

    public Vector3 shotOrigin;

    public GameObject damageCounter;
    public int damageMin = 2;
	public int damageMax = 2;

	private float preDamage;
	public int damage;

	void Start () {
        shotOrigin = transform.position;
		preDamage = Random.Range (damageMin, damageMax);
		damage = Mathf.RoundToInt (preDamage);
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;
		Destroy (this.gameObject, 3);
	}

	public void OnTriggerStay(Collider other)
	{
        if (other.tag == "Enemy")
        {
            if (other.GetComponentInChildren<GuardVisionCone>().chasing == false)
            {
                other.GetComponent<Guard>().chaseMode = true;
                other.GetComponent<Guard>().patrolMode = false;
                other.GetComponent<Guard>().playersLastKnownPosition = shotOrigin;
                other.GetComponentInChildren<GuardVisionCone>().chasing = true;
                other.GetComponentInChildren<GuardVisionCone>().chaseePosition = shotOrigin;
            }
            GameObject thisDamageCounter = Instantiate(damageCounter, transform.position + new Vector3 (0, 2, 0), Quaternion.Euler(new Vector3(80, 0, 0)));
            thisDamageCounter.GetComponent<TextMesh>().text = damage.ToString();
            other.GetComponent<Enemy>().Health -= damage;
        }
		if (other.tag != "Player") {
			Rigidbody body = other.gameObject.GetComponent<Rigidbody> ();

			if (body != null && body.isKinematic == false) {
				body.AddForceAtPosition (transform.forward * pushForce, transform.position, ForceMode.Impulse);
			}
			Destroy (this.gameObject);
		}

	}
}
