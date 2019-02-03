using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

    public float rotSpeed;

    public float maxScale;
    public float scaleSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		transform.localScale += new Vector3(scaleSpeed * Time.timeScale, scaleSpeed * Time.timeScale, scaleSpeed * Time.timeScale);
		transform.eulerAngles = Vector3.zero;
		transform.GetChild(0).transform.localEulerAngles += new Vector3(0, Time.deltaTime * rotSpeed, 0);

        if (transform.localScale.x >= maxScale && scaleSpeed > 0)
            scaleSpeed = -scaleSpeed;
        if (transform.localScale.x <= 0.5 && scaleSpeed < 0)
            scaleSpeed = -scaleSpeed;

		for (int i = 0; i < transform.GetChild(0).childCount; i++) {
			transform.GetChild(0).GetChild(i).localScale = Vector3.one/transform.localScale.x/2;
		}
        

		if (transform.GetChild(0).transform.childCount == 0)
            Destroy(this.gameObject);
	}
}
