using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelect : MonoBehaviour {

	public int activeSlot;

	// Use this for initialization
	void Start () {
		activeSlot = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			activeSlot++;
			if (activeSlot == 13)
				activeSlot = 1;
			Debug.Log ("Active Slot: " + activeSlot);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			activeSlot--;
			if (activeSlot == 0)
				activeSlot = 12;
			Debug.Log ("Active Slot: " + activeSlot);
		}
	}
}
