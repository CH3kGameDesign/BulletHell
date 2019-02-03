using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Transform inventoryBar;

	public Text PlayerName;

	private float invBarTargetX;
	private bool menuClosing;

	// Use this for initialization
	void Start () {
		invBarTargetX = 330;
		menuClosing = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			if (transform.GetChild (0).gameObject.activeInHierarchy) {
				invBarTargetX = 330;
				menuClosing = true;
			} else {
				for (int i = 0; i < transform.childCount; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
				for (int i = 1; i < 13; i++) {
					transform.GetChild (transform.childCount - 1).GetChild (i).GetComponent<Image> ().sprite = inventoryBar.GetChild (i).GetComponent<Image> ().sprite;
					transform.GetChild (transform.childCount - 1).GetChild (i).GetComponentInChildren<Text> ().text = inventoryBar.GetChild (i).GetComponentInChildren<Text> ().text;
				}
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

	}
}
