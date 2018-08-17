using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUp : MonoBehaviour
{

	private bool pickedUp;

	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp" || other.gameObject.tag == "Gun") {
			pickedUp = false;
			for (int i = 0; i < 12; i++) {
				if (Inventory.inventoryList [i] == AssetDatabase.GetAssetPath(GameObject.Find("Empty Slot"))) {
					Inventory.inventoryList [i] = AssetDatabase.GetAssetPath(other.gameObject);
					other.gameObject.GetComponent<Collider> ().enabled = false;
					other.gameObject.SetActive(false);
					if (GetComponent<InventorySelect> ().activeSlot == i) {
						GetComponent<InventorySelect> ().ChangeItem ();
					}
					return;

				}
			}
		}
	}
}
