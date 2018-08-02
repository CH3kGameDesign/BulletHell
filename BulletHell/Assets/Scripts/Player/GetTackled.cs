using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTackled : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<Guard>().chaseMode == true)
            {
                Debug.Log("ASDFGHJKL:");
                if (GetComponent<PlayerHealth>().invulnerable == false)
                {
                    GetComponent<PlayerHealth>().health -= Random.Range(1, 4);
                    GetComponent<Rigidbody>().AddExplosionForce(10, other.transform.position, 10, 1.1f, ForceMode.Impulse);
                }
            }

        }
    }
}
