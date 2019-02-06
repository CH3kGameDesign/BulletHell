using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Transform inventoryBar;

	public Text PlayerName;

	public GameObject cursorInv;

	private string selectedObject;
	private int pastButton;

	private float invBarTargetX;
	private bool menuClosing;

	// Use this for initialization
	void Start () {
		invBarTargetX = 330;
		menuClosing = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && Inventory.enemiesNear == false) {
			if (transform.GetChild (0).gameObject.activeInHierarchy) {
				invBarTargetX = 330;
				menuClosing = true;
				Inventory.menuOpen = false;
				Inventory.player.GetComponent<InventorySelect> ().ChangeItem ();
			} else {
				for (int i = 0; i < transform.childCount; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
				for (int i = 1; i < 13; i++) {
					transform.GetChild (transform.childCount - 1).GetChild (i).GetComponent<Image> ().sprite = inventoryBar.GetChild (i).GetComponent<Image> ().sprite;
					transform.GetChild (transform.childCount - 1).GetChild (i).GetComponentInChildren<Text> ().text = inventoryBar.GetChild (i).GetComponentInChildren<Text> ().text;
				}
				Inventory.menuOpen = true;
				Cursor.SetCursor(Inventory.player.GetComponent<InventorySelect>().cursor, new Vector2(7, 2), CursorMode.ForceSoftware);
				PlayerName.text = Inventory.name;
				invBarTargetX = 200;
				inventoryBar.gameObject.SetActive (false);
			}
		}
		if (transform.GetChild (transform.childCount - 1).gameObject.activeInHierarchy)
			transform.GetChild (transform.childCount - 1).localPosition = new Vector3 ((invBarTargetX + (transform.GetChild (transform.childCount - 1).localPosition.x * 2)) / 3, 0, 0);
			//transform.GetChild(transform.childCount-1).localPosition = Vector3.Lerp(transform.GetChild(transform.childCount-1).position, new Vector3 (invBarTargetX, 0, 0), 0.3f);

		if (transform.GetChild (transform.childCount - 1).localPosition.x > 329 && menuClosing == true) {
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).gameObject.SetActive (false);
			}
			inventoryBar.gameObject.SetActive (true);
		}

		for (int i = 0; i < transform.GetChild (transform.childCount - 2).childCount; i++) {
			transform.GetChild (transform.childCount - 2).GetChild (i).GetComponentInChildren<Text> ().text = Inventory.gunList [i];
		}


	}

	void LateUpdate () {
		if (!Input.GetKey (KeyCode.Mouse0))
			ButtonCancel ();
		if (Inventory.enemiesNear == true) {
			invBarTargetX = 330;
			menuClosing = true;
			Inventory.menuOpen = false;
			Inventory.player.GetComponent<InventorySelect> ().ChangeGun ();
			ButtonCancel ();
		}
	}

	public void ButtonCancel ()
	{
		pastButton = -1;
		selectedObject = " ";
		cursorInv.GetComponent<Image>().sprite = Resources.Load<Sprite> ("Prefabs/Icons/empty");
		Debug.Log ("MOUSE up");
	}

	public void ButtonClick (int button)
	{
		pastButton = button;

		if (button >= 100) {
			selectedObject = Inventory.gunList [button - 100];
			cursorInv.GetComponent<Image>().sprite = Resources.Load<Sprite> ("Prefabs/Icons/" + Inventory.gunList [pastButton - 100]);
			Debug.Log ("GRABBED GUN LIST " + button + " " + selectedObject);
		} else {
			selectedObject = Inventory.inventoryList [button];
			cursorInv.GetComponent<Image>().sprite = Resources.Load<Sprite> ("Prefabs/Icons/" + Inventory.inventoryList [pastButton]);
			Debug.Log ("GRABBED INVENTORY LIST " + button + " " + selectedObject);
		}
	}

	public void ButtonRelease (int button)
	{
		if (pastButton != -1) {
			if (button >= 100) {
				Debug.Log ("RELEASED GUN LIST " + button + " " + selectedObject);
				if (Inventory.gunList [button - 100] == "empty") {
					Inventory.gunList [button - 100] = selectedObject;
					if (pastButton >= 100) {
						Inventory.gunList[pastButton - 100] = "empty";
					} else {
						Inventory.inventoryList[pastButton] = "empty";
						if (pastButton < 12)
							Inventory.inventoryListAmount[pastButton] = 0;
					}
				}
			} else {
				Debug.Log ("RELEASED INVENTORY LIST " + button + " " + selectedObject);
				if (Inventory.inventoryList [button] == "empty") {
					Inventory.inventoryList [button] = selectedObject;
					if (button < 12 && pastButton < 12)
						Inventory.inventoryListAmount [button] = Inventory.inventoryListAmount [pastButton];
					if (pastButton >= 100) {
						Inventory.gunList[pastButton - 100] = "empty";
					} else {
						Inventory.inventoryList[pastButton] = "empty";
						if (pastButton < 12)
							Inventory.inventoryListAmount[pastButton] = 0;
					}
					for (int i = 1; i < 13; i++) {
						inventoryBar.GetChild (i).GetComponentInChildren<Text> ().text = transform.GetChild (transform.childCount - 1).GetChild (i).GetComponentInChildren<Text> ().text;
						inventoryBar.GetChild (i).GetComponent<Image> ().sprite = transform.GetChild (transform.childCount - 1).GetChild (i).GetComponent<Image> ().sprite;
					}
				}

			}
		}
		UpdateIcons ();
	}

	private void UpdateIcons()
	{
		for (int i = 1; i < 13; i++) {
			if (Inventory.inventoryListAmount [i - 1] != 0)
				transform.GetChild (transform.childCount - 1).GetChild (i).GetComponentInChildren<Text> ().text = Inventory.inventoryListAmount [i - 1].ToString ();
			else
				transform.GetChild (transform.childCount - 1).GetChild (i).GetComponentInChildren<Text> ().text = "";
			transform.GetChild (transform.childCount - 1).GetChild (i).GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Prefabs/Icons/" + Inventory.inventoryList [i - 1]);
		}
	}
}
