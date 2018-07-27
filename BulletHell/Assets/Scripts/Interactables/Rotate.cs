using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	/*
	WHAT SCRIPT DOES:
	-	Rotates Tiny ChaseModeMarker Super Fast
			(Intended To Attract Attention To Chasing Guards
	*/

    public float rotateSpeed;           //How Fast To Rotate
    private Vector3 rotationVector;     //What Direction To Rotate

	//Rotate GameObject
    void Update()
    {
        rotationVector = new Vector3(0, rotateSpeed * Time.deltaTime, 0);
        transform.Rotate(rotationVector);
    }
}
