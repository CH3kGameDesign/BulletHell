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
			if (activeSlot == 12)
				activeSlot = 0;
			Debug.Log ("Active Slot: " + activeSlot);
            ChangeItem();
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			activeSlot--;
			if (activeSlot == -1)
				activeSlot = 11;
			Debug.Log ("Active Slot: " + activeSlot);
            ChangeItem();
        }
	}

    private void ChangeItem ()
    {
        for (int i = 0; i <= 1; i++)
        {
            Inventory.inventoryList[i].SetActive(false);
        }
        Inventory.inventoryList[activeSlot].SetActive(true);
    }
}
