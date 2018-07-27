using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainMenuManager : MonoBehaviour {

	public GameObject emptySlot;

	// Use this for initialization
	void Start () {
		if (File.Exists (Application.persistentDataPath + "/Inventory.gd")) {
			SaveLoad.Load ();
		} else {
			for (int i = 0; i < 12; i++) {
				Inventory.inventoryList.Add (emptySlot);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
