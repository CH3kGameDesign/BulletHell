using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour {

	/*
	WHAT SCRIPT DOES:
	- 	Controls Each Guard Individually
	-	Path Is Determined By Empty Game Objects Placed Around the Map
			(Link Them To Guard In Inspector)
	-	Returns Guard To Patrol Mode After Getting To Player's Last Known Location
	*/


    private UnityEngine.AI.NavMeshAgent navAgent;	//NavMeshAgent

    public List <GameObject> path;              	//The Patrol Path
    private int nextPathPos = 0;                	//First Patrol Path Position

    public bool patrolMode = true;              	//Whether Patrolling
    public bool chaseMode = false;              	//Whether Chasing

    public GameObject chaseModeMarker;          	//GameObject Shows Whether Chasing

    public Vector3 playersLastKnownPosition;    	//Where To Go To When Chasing

    

	//Link The NavMeshAgent Component
    void Start () {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

	//Moment to moment Patrolling/Chasing
	void Update () {
		//Patrolling
        if (patrolMode == true)
        {
            chaseModeMarker.SetActive(false);															//Turn Off Chase Marker (Spinning Red Marker Above Head
            navAgent.destination = path[nextPathPos].transform.position;       							//Move to next patrol place

			//If close to Patrol Point move to next Patrol Point
            if (Vector3.Distance(transform.position, path[nextPathPos].transform.position) < 0.5f)		
            {
                nextPathPos++;
                if (nextPathPos == path.Count)
                {
                    nextPathPos = 0;
                }
            }
        }

		//Chasing
        if (chaseMode == true)
        {
            chaseModeMarker.SetActive(true);
            navAgent.destination = playersLastKnownPosition;
            patrolMode = false;
            Debug.Log("Guard Chasing");

			//If close to Player's Last Position invoke ReturnToPath
            if (Vector3.Distance(transform.position, playersLastKnownPosition) < 0.5f)
            {
                Invoke("ReturnToPath", 2);
            }
        }
    }


	//Stop Chasing
    void ReturnToPath()                
    {
        chaseMode = false;
        navAgent.destination = path[nextPathPos].transform.position;
        Debug.Log("Guard Returning to path");
        patrolMode = true;
    }
}
