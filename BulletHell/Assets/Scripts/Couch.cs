using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Couch : MonoBehaviour {

	public Texture2D intCursor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.Find("SleepMenu").transform.GetChild(0).gameObject.activeInHierarchy == true)
            GameObject.Find("SleepMenu").transform.GetChild(0).gameObject.SetActive(false);
			SaveLoad.ResetPermancy(Inventory.saveFile);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
			RaycastHit hit;

			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
				Debug.Log (hit.collider.gameObject.name);
				if (hit.collider.gameObject == this.gameObject) {
					Debug.Log ("Half way there 3");
					Cursor.SetCursor (intCursor, new Vector2 (7, 2), CursorMode.ForceSoftware);
					if (Input.GetKeyDown (KeyCode.Mouse1)) {
						Debug.Log ("Sleep");
						for (int i = 0; i < GameObject.Find("PermancyStuff").transform.childCount; i++) {
							GameObject.Destroy(GameObject.Find ("PermancyStuff").transform.GetChild (i).gameObject);
						}
                        GameObject.Find("SleepMenu").transform.GetChild(0).gameObject.SetActive(true);
                        GameObject.Find("ShotsFired").GetComponent<Text>().text = "Shots Fired: " + Inventory.shotsFired;
                        GameObject.Find("ShotsFiredTotal").GetComponent<Text>().text = "Shots Fired Total: " + Inventory.shotsFiredTotal;

                        other.GetComponent<PlayerHealth>().health = other.GetComponent<PlayerHealth>().healthLimit;
                        
                        //SaveLoad.ResetPermancy ();
						SaveLoad.Save(Inventory.saveFile);
					}
				} else {
					other.gameObject.GetComponent<InventorySelect> ().ChangeItem ();
				}
			}
        }
    }

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			other.gameObject.GetComponent<InventorySelect> ().ChangeItem ();
		}
	}
}
