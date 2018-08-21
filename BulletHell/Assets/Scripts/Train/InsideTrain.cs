using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTrain : MonoBehaviour {

    private GameObject trainMap;

	// Use this for initialization
	void Start () {
        trainMap = GameObject.Find("TrainMap");
        trainMap.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trainMap.SetActive(true);
			Cursor.SetCursor(other.gameObject.GetComponent<InventorySelect> ().cursor, new Vector2(7, 2), CursorMode.ForceSoftware);
			other.gameObject.GetComponentInChildren<Shoot> ().canShoot = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trainMap.SetActive(false);
			other.gameObject.GetComponent<InventorySelect> ().ChangeItem ();
        }
    }
}
