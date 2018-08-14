using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]

public class LaserSight : MonoBehaviour {

	private LineRenderer lr;

	public LayerMask layerMask;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, layerMask.value)) {
			//if (hit.collider.gameObject.tag != "Gun" && hit.collider.gameObject.tag != "Invisible" && hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "UsedAmmo" && hit.collider.gameObject.layer != 12) {
				if (hit.collider) {
					lr.SetPosition (1, new Vector3 (0, 0, hit.distance));
					if (Input.GetKeyDown (KeyCode.Space)) {
						Debug.Log ("Hit " + hit.collider.gameObject.name);
					}
				} 

			//}
		} else {
			lr.SetPosition (1, new Vector3 (0, 0, 50));
		}
	}
}
