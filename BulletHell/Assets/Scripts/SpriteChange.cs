using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {

	public int direction = 0;

	private GameObject playerModel;
	private GameObject sprites;
    private GameObject NCSprites;

    private Vector3 pastPosition = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        playerModel = transform.GetChild(0).gameObject;
        sprites = transform.GetChild(1).gameObject;
        NCSprites = transform.GetChild(2).gameObject;
        pastPosition = transform.position;

        for (int i = 0; i < sprites.transform.childCount; i++)
        {
            //sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerModel.transform.localEulerAngles.y < 360 && playerModel.transform.localEulerAngles.y > 270) {
			direction = 0;
			Debug.Log ("direction0");
		}
		if (playerModel.transform.localEulerAngles.y < 90 && playerModel.transform.localEulerAngles.y > 0) {
			direction = 1;
			Debug.Log ("direction1");
		}
		if (playerModel.transform.localEulerAngles.y < 180 && playerModel.transform.localEulerAngles.y > 90) {
			direction = 3;
			Debug.Log ("direction3");
		}
		if (playerModel.transform.localEulerAngles.y < 270 && playerModel.transform.localEulerAngles.y > 180) {
			direction = 2;
			Debug.Log ("direction2");
		}
        
        if (direction == 0)
        {
            for (int i = 0; i < sprites.transform.childCount; i++)
            {
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 1);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                {
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 2);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                }
            }
            for (int i = 0; i < NCSprites.transform.childCount; i++)
            {
                if (NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.name != "Null")
                {
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 1);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                    if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                    {
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 2);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                    }
                }
            }
        }

        if (direction == 1)
        {
            for (int i = 0; i < sprites.transform.childCount; i++)
            {
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 3);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                {
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 4);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                }
            }
            for (int i = 0; i < NCSprites.transform.childCount; i++)
            {
                if (NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.name != "Null")
                {
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 3);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                    if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                    {
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 4);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                    }
                }
            }
        }

        if (direction == 2)
        {
            for (int i = 0; i < sprites.transform.childCount; i++)
            {
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 5);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                {
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 6);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                }
            }
            for (int i = 0; i < NCSprites.transform.childCount; i++)
            {
                if (NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.name != "Null")
                {
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 5);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                    if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                    {
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 6);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                    }
                }
            }
        }

        if (direction == 3)
        {
            for (int i = 0; i < sprites.transform.childCount; i++)
            {
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 7);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                {
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 8);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                    sprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                }
            }
            for (int i = 0; i < NCSprites.transform.childCount; i++)
            {
                if (NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.name != "Null")
                {
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 7);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 2);
                    NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 30);
                    if (transform.position.x != pastPosition.x || transform.position.z != pastPosition.z)
                    {
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Animation", 8);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_Frames", 4);
                        NCSprites.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("_FrameRate", 60);
                    }
                }
            }
        }

        pastPosition = transform.position;
	}
}
