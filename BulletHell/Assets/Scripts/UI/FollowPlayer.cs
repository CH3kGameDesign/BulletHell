using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Vector2 posOffset;
	public float posMultiplier = 2;

	private RectTransform rectTransform;
	private Vector2 uiOffset;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform>();
		uiOffset = new Vector2((float)Camera.main.pixelWidth / 2f, (float)Camera.main.pixelHeight / 2f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(GameObject.Find("Player").transform.position);
		Vector2 proportionalPosition = new Vector2 (ViewportPosition.x * Camera.main.pixelWidth, ViewportPosition.y * Camera.main.pixelHeight);

		// Set the position and remove the screen offset
		rectTransform.localPosition = ((proportionalPosition - uiOffset)/posMultiplier) + posOffset;
	}
}
