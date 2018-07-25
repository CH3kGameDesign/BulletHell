﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVisionCone : MonoBehaviour {

	/*
	WHAT SCRIPT DOES:
	-	Check For Player Within Vision Cone
	-	Enable Chase Mode
	-	Set Player's Last Known Location
	*/




	//When Object Enters Vision Cone
    public void OnTriggerStay(Collider other)
    {
        RaycastHit hit;

        Vector3 fromPosition = transform.position;				//Guard Position
        Vector3 toPosition = other.transform.position;			//Object's Within VisionCone Position
        Vector3 direction = toPosition - fromPosition;          //Direction of Raycast

		//Check for objects between Guard and Player
        if (Physics.Raycast(transform.position, direction, out hit))        
        {
            
			//If Object Is Player Start Chasing
            if (hit.collider.gameObject.name == "Player")
            {
                GetComponentInParent<Guard>().patrolMode = false;										//Turn Patrol Mode Off
                GetComponentInParent<Guard>().chaseMode = true;											//Turn Chase Mode On
                GetComponentInParent<Guard>().playersLastKnownPosition = other.transform.position;		//Set Player's Last Known Location
            }
            Debug.Log("Hitting " + hit.collider.gameObject.name);            //Say what it hits
        }
        
    }
}
