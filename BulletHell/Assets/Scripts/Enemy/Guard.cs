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
    public GameObject target;

    public Vector3 playersLastKnownPosition;    	//Where To Go To When Chasing

    private int chaseTimer = 0;
    private int randomPathTimer = 0;

    

    

	//Link The NavMeshAgent Component
    void Start () {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgent.destination = transform.position;
    }

	//Moment to moment Patrolling/Chasing
	void Update () {
		//Patrolling
        if (patrolMode == true)
        {
            chaseModeMarker.SetActive(false);															//Turn Off Chase Marker (Spinning Red Marker Above Head

            if (path[nextPathPos] != null)
            {
                navAgent.destination = path[nextPathPos].transform.position;
                //If close to Patrol Point move to next Patrol Point
                if (Vector3.Distance(transform.position, path[nextPathPos].transform.position) < 0.5f)
                {

                    nextPathPos++;
                    if (nextPathPos == path.Count)
                    {
                        nextPathPos = 0;
                    }
                }
            } else
            {
                randomPathTimer++;
                if (randomPathTimer > 20)
                {
                    navAgent.destination = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + Random.Range(-2, 2));
                    randomPathTimer = 0;
                }
            }
        }

		//Chasing
        if (chaseMode == true)
        {
            chaseModeMarker.SetActive(true);
            navAgent.destination = target.transform.position;
            patrolMode = false;
            Debug.Log("Guard Chasing");
            transform.LookAt(target.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            if (Vector3.Distance(transform.position, target.transform.position) < 3)
            {
                navAgent.destination = transform.position;
            }
			GetComponent<Enemy> ().PreAttack ();
        }
    }


	//Stop Chasing
    void ReturnToPath()                
    {
        chaseMode = false;
        if (path[nextPathPos] != null)
        {
            navAgent.destination = path[nextPathPos].transform.position;
        } else
        {
            navAgent.destination = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + Random.Range(-2, 2));
        }
        
        Debug.Log("Guard Returning to path");
        patrolMode = true;
        GetComponentInChildren<GuardVisionCone>().chasing = false;
    }
}
