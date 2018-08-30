using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelect : MonoBehaviour {

	public GameObject selectedSlot;

    public Texture2D cursor;
    public Texture2D reticle;

	// Use this for initialization
	void Start () {
		Invoke ("ChangeItem", 0.0001f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			Inventory.inventorySelected++;
			if (Inventory.inventorySelected == 12)
				Inventory.inventorySelected = 0;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
            ChangeItem();
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			Inventory.inventorySelected--;
			if (Inventory.inventorySelected == -1)
				Inventory.inventorySelected = 11;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
            ChangeItem();
        }


		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Inventory.inventorySelected = 0;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Inventory.inventorySelected = 1;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Inventory.inventorySelected = 2;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Inventory.inventorySelected = 3;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Inventory.inventorySelected = 4;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			Inventory.inventorySelected = 5;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			Inventory.inventorySelected = 6;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			Inventory.inventorySelected = 7;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			Inventory.inventorySelected = 8;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Inventory.inventorySelected = 9;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Minus)) {
			Inventory.inventorySelected = 10;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Equals)) {
			Inventory.inventorySelected = 11;
			Debug.Log ("Active Slot: " + Inventory.inventorySelected);
			ChangeItem();
		}
		selectedSlot.transform.localPosition = new Vector3 (-275.6f + 50 * Inventory.inventorySelected, selectedSlot.transform.localPosition.y, selectedSlot.transform.localPosition.z);

        UpdateIcons();
	}

    public void ChangeItem ()
    {
		if (GameObject.Find ("PlayerHands").transform.childCount != 0) {
			for (int i = 0; i < GameObject.Find ("PlayerHands").transform.childCount; i++) {
				Destroy (GameObject.Find ("PlayerHands").transform.GetChild (i).gameObject);
			}
		}


		//string objectPath = Inventory.inventoryList [Inventory.inventorySelected];													*
		string itemID = Inventory.inventoryList [Inventory.inventorySelected];														//
		Debug.Log (itemID);																							//
		//string[] objectPathParts = objectPath.Split(new string[] {"."}, System.StringSplitOptions.None);			*

		//objectPathParts = objectPathParts[0].Split(new string[] {"/"}, System.StringSplitOptions.None);			*

		//objectPath = objectPathParts[2] + "/" + objectPathParts[3] + "/" + objectPathParts[4];					*
		//Debug.Log (objectPath);																					*


        //UnityEngine.Object pPrefab = Resources.Load(objectPath);													*

		LoadItem.Load(itemID);																						//
		UnityEngine.Object pPrefab = Resources.Load(LoadItem.NewItemPath);											//

        GameObject currentObject = (GameObject)GameObject.Instantiate(pPrefab, Vector3.zero, Quaternion.identity);
        currentObject.transform.SetParent (GameObject.Find("PlayerHands").transform);
        currentObject.transform.localRotation = Quaternion.Euler (Vector3.zero);
        currentObject.transform.localPosition = new Vector3(0, 0, 0.5f);

		if (currentObject.GetComponent<BoxCollider> ()) {
			currentObject.GetComponent<BoxCollider> ().enabled = false;
		}

        if (currentObject.tag == "Gun")
        {
            Cursor.SetCursor(reticle, new Vector2(32, 32), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursor, new Vector2(7, 2), CursorMode.ForceSoftware);
        }
    }

    private void UpdateIcons()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject.Find("InventoryBarItem (" + i + ")").GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/Icons/" + Inventory.inventoryList[i]);

            if (Inventory.inventoryListAmount[i] != 0)
            {
                GameObject.Find("InventoryBarText (" + i + ")").GetComponent<Text>().text = Inventory.inventoryListAmount[i].ToString();
            } else
            {
                GameObject.Find("InventoryBarText (" + i + ")").GetComponent<Text>().text = "";
            }
        }
    }
}
