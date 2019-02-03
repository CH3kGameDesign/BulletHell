using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVisionCone : MonoBehaviour {

    /*
	WHAT SCRIPT DOES:
	-	Check For Player Within Vision Cone
	-	Enable Chase Mode
	-	Set Player's Last Known Location
	*/

    public bool chasing = false;
    public Vector3 chaseePosition;



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
			if (hit.collider.gameObject.tag == "Player" && (hit.collider.gameObject.transform.position.y < transform.position.y + 0.5f && hit.collider.gameObject.transform.position.y > transform.position.y - 0.5f))
            {
				if (transform.parent.transform.parent.GetChild (0).gameObject.name == "Walls") {
					transform.parent.transform.parent.GetChild (0).gameObject.SetActive (true);
					transform.parent.transform.parent.GetChild (0).SetParent (GameObject.Find ("ActiveWalls").transform);
				}
				for (int i = 0; i < transform.parent.transform.parent.childCount; i++) {
					transform.parent.transform.parent.GetChild (i).SetParent (GameObject.Find ("Enemies").transform);
				}
                chasing = true;
                chaseePosition = other.gameObject.transform.position;
				transform.parent.GetComponent<Guard>().target = hit.collider.gameObject;
            }
        }
        
    }

    private void Update()
    {
        if (chasing == true)
        {
            RaycastHit hit;

            Vector3 fromPosition = transform.position;              //Guard Position
            Vector3 toPosition = chaseePosition;          //Object's Within VisionCone Position
            Vector3 direction = toPosition - fromPosition;          //Direction of Raycast

            //Check for objects between Guard and Player
            if (Physics.Raycast(transform.position, direction, out hit))
            {

                //If Object Is Player Start Chasing
                if (hit.collider.gameObject.tag == "Player")
                {
					transform.parent.GetComponent<Guard>().patrolMode = false;                                       //Turn Patrol Mode Off
					transform.parent.GetComponent<Guard>().chaseMode = true;                                         //Turn Chase Mode On
					transform.parent.GetComponent<Guard>().target = hit.collider.gameObject;      //Set Player's Last Known Location
                }
            }
        }
    }
}
