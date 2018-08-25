using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//time[0] == Hours
		//time[1] == Minutes
		//time[2] == Seconds

		if (Inventory.time.Count < 1) {
			Inventory.time.Add (8);
			Inventory.time.Add (0);
			Inventory.time.Add (0);
		}

		Inventory.time[2] += Time.deltaTime;
		Inventory.time[1] = Mathf.Round (Inventory.time[2]);
		if (Inventory.time[1] >= 60) {
			Inventory.time[0] += 1;
			Inventory.time[1] = 0;
			Inventory.time[2] = 0;
		}

		string smallHours = "0";
		string smallMinutes = "0";

		if (Inventory.time[0] < 10)
			smallHours = "0";
		else
			smallHours = "";

		if (Inventory.time[1] < 10)
			smallMinutes = "0";
		else
			smallMinutes = "";
		
		GameObject.Find ("Time").GetComponent<Text> ().text = smallHours + Inventory.time[0] + ":" + smallMinutes + Inventory.time[1];
	}
}
