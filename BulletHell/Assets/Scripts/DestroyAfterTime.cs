using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    private float time = 0;
    public float destroyTime;
	

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time >= destroyTime)
        {
            Destroy(this.gameObject);
        }
	}
}
