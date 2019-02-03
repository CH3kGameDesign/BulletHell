using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunSelection : MonoBehaviour {

	public float maxYRotation = 30;
	public int gunChoice = 0;

	private float timer;
	private GameObject gunSelectionMap;

	private bool mapOpen;

	// Use this for initialization
	void Start () {
		gunSelectionMap = GameObject.Find ("GunSelectionMap");
		gunSelectionMap.SetActive (false);
		mapOpen = false;

		for (int i = 0; i < gunSelectionMap.transform.childCount; i++) {
			int j = i;

			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = EventTriggerType.PointerEnter;

			EventTrigger.Entry leave = new EventTrigger.Entry ();
			leave.eventID = EventTriggerType.PointerExit;

			entry.callback.AddListener (delegate {
				ChooseGun(j);
			});
			leave.callback.AddListener (delegate {
				ChooseGun(100);
			});
			gunSelectionMap.transform.GetChild (i).gameObject.GetComponent<EventTrigger> ().triggers.Add (entry);
			gunSelectionMap.transform.GetChild (i).gameObject.GetComponent<EventTrigger> ().triggers.Add (leave);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1))
			timer = 0;

		if (Input.GetMouseButton (1)) {
			if (timer > 0.2f) {
				gunSelectionMap.SetActive (true);
				UpdateGunList ();
				UpdateGunMapRotation ();
				Time.timeScale = 0.2f;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
				mapOpen = true;
			}
		} else {
			if (mapOpen) {
				for (int i = 0; i < gunSelectionMap.transform.childCount; i++) {
					gunSelectionMap.transform.GetChild (i).GetComponent<ResizeOnHover> ().mouseOver = false;
				}
				gunSelectionMap.SetActive (false);
				Time.timeScale = 1;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;
				ChooseGunExit ();
				mapOpen = false;
			}
		}
		if (Input.GetMouseButtonUp (1)) {

		}

		timer += Time.deltaTime;
	}

	public void UpdateGunList () {
		for (int i = 0; i < 8; i++) {
			gunSelectionMap.transform.GetChild (i).GetChild (0).GetComponent<Text>().text = Inventory.gunList [i];
		}
	}

	public void UpdateGunMapRotation () {
		float rotY = 0;
		float rotX = 0;

		float screenScale = Screen.width / Screen.height;

		float rotYDivisionRate = (Screen.width/2)/maxYRotation;
		float rotXDivisionRate = (Screen.height/2)/(maxYRotation/screenScale);

		rotY = (Input.mousePosition.x - (Screen.width / 2))/rotYDivisionRate;
		rotX = (Input.mousePosition.y - (Screen.height / 2))/rotXDivisionRate;

		gunSelectionMap.transform.localEulerAngles =  new Vector3(-rotX, rotY, 0);
	}

	public void ChooseGun (int choice) {
		if (choice == 100)
			return;
		gunChoice = choice;
	}
	public void ChooseGunExit () {
		Inventory.gunSelected = gunChoice;
		GetComponent<InventorySelect> ().ChangeGun ();
	}
}
