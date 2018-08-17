using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTrain : MonoBehaviour {

    private GameObject trainMap;

	// Use this for initialization
	void Start () {
        trainMap = GameObject.Find("TrainMap");
        trainMap.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trainMap.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trainMap.SetActive(false);
        }
    }
}
