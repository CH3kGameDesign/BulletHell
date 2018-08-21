using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUp : MonoBehaviour
{

	private bool pickedUp;

	public GameObject emptySlot;

	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp" || other.gameObject.tag == "Gun") {
			pickedUp = false;
			for (int i = 0; i < 12; i++) {
				Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);

				if (Inventory.inventoryList [i] == AssetDatabase.GetAssetPath(emptySlotobj)) {
					Object otherobj = PrefabUtility.GetPrefabParent (other.gameObject);
					Inventory.inventoryList [i] = AssetDatabase.GetAssetPath(otherobj);
					Debug.Log(Inventory.inventoryList [i]);
					//other.gameObject.GetComponent<Collider> ().enabled = false;
					//other.gameObject.SetActive(false);
					if (GetComponent<InventorySelect> ().activeSlot == i) {
						GetComponent<InventorySelect> ().ChangeItem ();
					}
					Destroy (other.gameObject);
					return;

				}
			}
		}
	}
}
