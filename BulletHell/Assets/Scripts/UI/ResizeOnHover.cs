using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResizeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public float minSize;
	public float maxSize;

	private float currentSize;

	public bool mouseOver;

	// Use this for initialization
	void Start () {
		mouseOver = false;
		currentSize = minSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mouseOver) {
			currentSize += (maxSize - currentSize) / 10;
		} else {
			currentSize += (minSize - currentSize) / 10;
		}
		GetComponent<RectTransform> ().localScale = new Vector3 (currentSize, currentSize, 1);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		mouseOver = false;
	}
}
