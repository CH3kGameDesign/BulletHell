using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelect : MonoBehaviour {

	public int activeSlot;
	public GameObject selectedSlot; 

	// Use this for initialization
	void Start () {
		activeSlot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			activeSlot++;
			if (activeSlot == 12)
				activeSlot = 0;
			Debug.Log ("Active Slot: " + activeSlot);
            ChangeItem();
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			activeSlot--;
			if (activeSlot == -1)
				activeSlot = 11;
			Debug.Log ("Active Slot: " + activeSlot);
            ChangeItem();
        }
		selectedSlot.transform.localPosition = new Vector3 (-275.6f + 50 * activeSlot, selectedSlot.transform.localPosition.y, selectedSlot.transform.localPosition.z);
	}

    public void ChangeItem ()
    {
        for (int i = 0; i <= 1; i++)
        {
            Inventory.inventoryList[i].SetActive(false);
        }
        Inventory.inventoryList[activeSlot].SetActive(true);
		Inventory.inventoryList [activeSlot].transform.SetParent (this.gameObject.transform);
		Inventory.inventoryList [activeSlot].transform.localPosition = new Vector3(0, 2, 0);
    }
}
