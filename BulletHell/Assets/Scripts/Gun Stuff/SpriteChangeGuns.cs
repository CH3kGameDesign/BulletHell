using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeGuns : MonoBehaviour {

	public GameObject playerModel;
	private int direction = 0;

	// Use this for initialization
	void Start () {
		if (transform.parent.parent != null)
			playerModel = transform.parent.parent.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (playerModel != null) {
			if (playerModel.transform.localEulerAngles.y < 360 && playerModel.transform.localEulerAngles.y > 270) {
				direction = 0;

			}
			if (playerModel.transform.localEulerAngles.y < 90 && playerModel.transform.localEulerAngles.y > 0) {
				direction = 1;

			}
			if (playerModel.transform.localEulerAngles.y < 180 && playerModel.transform.localEulerAngles.y > 90) {
				direction = 3;

			}
			if (playerModel.transform.localEulerAngles.y < 270 && playerModel.transform.localEulerAngles.y > 180) {
				direction = 2;

			}

			if (direction == 0) {
				transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				transform.localPosition = new Vector3 (0.5f, 0, transform.localPosition.z);
				Debug.Log ("Top Left");
			}

			if (direction == 1) {
				transform.localScale = new Vector3 (-0.2f, 0.2f, 0.2f);
				transform.localPosition = new Vector3 (-0.5f, 0, transform.localPosition.z);
				Debug.Log ("Top Right");
			}

			if (direction == 2) {
				transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
				transform.localPosition = new Vector3 (0.5f, -0.11f, transform.localPosition.z);
				Debug.Log ("Bottom Right");
			}

			if (direction == 3) {
				transform.localScale = new Vector3 (-0.2f, 0.2f, 0.2f);
				transform.localPosition = new Vector3 (-0.5f, -0.11f, transform.localPosition.z);
				Debug.Log ("Bottom Left");
			}
		}
	}
}
