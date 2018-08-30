using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    private bool inside;
    private bool activate;

    private float timer;

    public int floor;

    public Vector3 bottom;
    public Vector3 top;

    public GameObject bottomDoor;
	public GameObject topDoor;

    // Use this for initialization
    void Start () {
        activate = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (inside == false)
        {
            timer = 0;
        }

		if (floor == 0) {
			bottomDoor.SetActive (false);
			topDoor.SetActive (true);
		}
		if (floor == 1) {
			bottomDoor.SetActive (true);
			topDoor.SetActive (false);
		}

        timer += Time.deltaTime;
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;

            if (timer >= 1)
            {
                if (activate == true)
                {
                    other.transform.parent = transform;
                    if (floor == 0)
                    {
                        transform.position = top;
                        floor = 1;
                    }
                    else
                    {
                        transform.position = bottom;
                        floor = 0;
                    }
                    other.transform.parent = null;
                    activate = false;
                }
            }
			GameObject.Find ("CameraPivot").GetComponent<CameraPivot> ().rotation = -60;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
			Invoke ("Reactivate", 1);
			GameObject.Find ("CameraPivot").GetComponent<CameraPivot> ().rotation = 0;
        }
    }


	private void Reactivate()
	{
		activate = true;
	}
}
