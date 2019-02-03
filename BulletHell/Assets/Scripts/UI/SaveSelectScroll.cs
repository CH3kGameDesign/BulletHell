using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSelectScroll : MonoBehaviour {

	public float saveWidth;

	private int saveNumber;
	private float maxScroll;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		saveNumber = Mathf.RoundToInt(transform.childCount / 2);
		maxScroll = saveNumber * saveWidth;
	}

	private void FixedUpdate ()
	{
		if (saveNumber != 0) {
			float transX = transform.localPosition.x;
			if (transform.localPosition.x > -maxScroll) {
				if (Input.mousePosition.x > (Screen.width/2 + 200)) {
					transform.localPosition = new Vector3(transX -= (Input.mousePosition.x - (Screen.width / 2 + 200)) / 70, 0, 0);
				}
			}
			
			if (transform.localPosition.x < 0) {
				if (Input.mousePosition.x < (Screen.width / 2 - 200)) {
					transform.localPosition = new Vector3(transX -= (Input.mousePosition.x - (Screen.width / 2 - 200)) / 70, 0, 0);
				} 
			}
		} else
			transform.localPosition = Vector3.zero;
	}
}
