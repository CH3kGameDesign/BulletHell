using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;																					*

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
				//Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);						*

				//if (Inventory.inventoryList [i] == AssetDatabase.GetAssetPath(emptySlotobj)) {		*
				if (Inventory.inventoryList [i] == "empty") {											//
					//Object otherobj = PrefabUtility.GetPrefabParent (other.gameObject);				*
					LoadItem.GetID(other.gameObject.name);												//
					Inventory.inventoryList [i] = LoadItem.NewItemID;									//
					Debug.Log(Inventory.inventoryList [i]);
					//other.gameObject.GetComponent<Collider> ().enabled = false;
					//other.gameObject.SetActive(false);
					if (Inventory.inventorySelected == i) {
						GetComponent<InventorySelect> ().ChangeItem ();
					}
					Destroy (other.gameObject);
					return;

				}
			}
		}
	}
}
