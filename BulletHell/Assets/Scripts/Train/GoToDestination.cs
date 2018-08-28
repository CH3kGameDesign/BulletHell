using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDestination : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToPlace (int destination)
    {
		GameObject.Find ("GameController").gameObject.GetComponent<PermancyRecord> ().savePermancy ();
        SaveLoad.Save();
        SceneManager.LoadScene(destination);
    }
}
