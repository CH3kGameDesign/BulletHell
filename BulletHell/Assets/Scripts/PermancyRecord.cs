using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermancyRecord : MonoBehaviour {

    public GameObject bulletShell;

	// Use this for initialization
	void Start () {
        Invoke("loadPermancy", 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            savePermancy();
	}

    public void savePermancy ()
    {
        int permancyCount = GameObject.Find("PermancyStuff").transform.childCount;
        Debug.Log(permancyCount);

        Permancy.permancyVectorX = new List<float>();
        Permancy.permancyVectorY = new List<float>();
        Permancy.permancyVectorZ = new List<float>();

        for (int i = 0; i < permancyCount; i++)
        {
            Permancy.permancyVectorX.Add(GameObject.Find("PermancyStuff").transform.GetChild(i).transform.position.x);
            Permancy.permancyVectorY.Add(GameObject.Find("PermancyStuff").transform.GetChild(i).transform.position.y);
            Permancy.permancyVectorZ.Add(GameObject.Find("PermancyStuff").transform.GetChild(i).transform.position.z);
            Permancy.permancyRotationY.Add(GameObject.Find("PermancyStuff").transform.GetChild(i).transform.eulerAngles.y);
            Debug.Log(Permancy.permancyVectorX[i]);
        }
    }

    private void loadPermancy ()
    {
        for (int i = 0; i < Permancy.permancyVectorX.Count; i++)
        {
            Instantiate(bulletShell, new Vector3(Permancy.permancyVectorX[i], Permancy.permancyVectorY[i], Permancy.permancyVectorZ[i]), Quaternion.Euler(0, Permancy.permancyRotationY[i], 0), GameObject.Find("PermancyStuff").transform);
        }
    }
}
