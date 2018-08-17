using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelect : MonoBehaviour {

	public int activeSlot;
	public GameObject selectedSlot;

    public Texture2D cursor;
    public Texture2D reticle;

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


		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			activeSlot = 0;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			activeSlot = 1;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			activeSlot = 2;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			activeSlot = 3;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			activeSlot = 4;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			activeSlot = 5;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			activeSlot = 6;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			activeSlot = 7;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			activeSlot = 8;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			activeSlot = 9;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Minus)) {
			activeSlot = 10;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		if (Input.GetKeyDown (KeyCode.Equals)) {
			activeSlot = 11;
			Debug.Log ("Active Slot: " + activeSlot);
			ChangeItem();
		}
		selectedSlot.transform.localPosition = new Vector3 (-275.6f + 50 * activeSlot, selectedSlot.transform.localPosition.y, selectedSlot.transform.localPosition.z);
	}

    public void ChangeItem ()
    {

        Destroy(GameObject.Find("PlayerHands").transform.GetChild(0).gameObject);

        UnityEngine.Object pPrefab = Resources.Load(Inventory.inventoryList[activeSlot]);

        GameObject currentObject = (GameObject)GameObject.Instantiate(pPrefab, Vector3.zero, Quaternion.identity);
        currentObject.transform.SetParent (GameObject.Find("PlayerHands").transform);
        currentObject.transform.localRotation = Quaternion.Euler (Vector3.zero);
        currentObject.transform.localPosition = new Vector3(0, 0, 0.5f);

        if (currentObject.tag == "Gun")
        {
            Cursor.SetCursor(reticle, new Vector2(32, 32), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursor, new Vector2(7, 2), CursorMode.ForceSoftware);
        }
    }
}
