using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 20;
	public float pushForce = 1;

	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward * Time.deltaTime * bulletSpeed;
		Destroy (this.gameObject, 3);
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.tag != "Player") {
			Rigidbody body = other.gameObject.GetComponent<Rigidbody> ();

			if (body != null && body.isKinematic == false) {
				body.AddForceAtPosition (transform.forward * pushForce, transform.position, ForceMode.Impulse);
			}
			Debug.Log ("IM PUSHING");
			Destroy (this.gameObject);
		}

	}
}
