using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {

	public int direction = 0;

	private GameObject playerModel;
	private GameObject sprites;
    private GameObject NCSprites;

    private Vector3 pastPosition = Vector3.zero;

    MeshRenderer[] mRenderers;
    MeshRenderer[] mNCRenderers;

    // Use this for initialization
    void Start()
    {
        playerModel = transform.GetChild(0).gameObject;
        sprites = transform.GetChild(1).gameObject;
        NCSprites = transform.GetChild(2).gameObject;
        pastPosition = transform.position;

        mRenderers = sprites.GetComponentsInChildren<MeshRenderer>();
        mNCRenderers = NCSprites.GetComponentsInChildren<MeshRenderer>();

        mRenderers[4].material = PlayerMaterialHolder.Hats[PlayerMaterialHolder.featureSelection[0]];
        mRenderers[3].material = PlayerMaterialHolder.Faces[PlayerMaterialHolder.featureSelection[1]];
        mRenderers[2].material = PlayerMaterialHolder.Shirts[PlayerMaterialHolder.featureSelection[2]];
        mRenderers[1].material = PlayerMaterialHolder.Pants[PlayerMaterialHolder.featureSelection[3]];

        mNCRenderers[4].material = PlayerMaterialHolder.NCHats[PlayerMaterialHolder.featureSelection[0]];
        mNCRenderers[3].material = PlayerMaterialHolder.NCFaces[PlayerMaterialHolder.featureSelection[1]];
        mNCRenderers[2].material = PlayerMaterialHolder.NCShirts[PlayerMaterialHolder.featureSelection[2]];
        mNCRenderers[1].material = PlayerMaterialHolder.NCPants[PlayerMaterialHolder.featureSelection[3]];


        //Debug.Log("0: " + PlayerMaterialHolder.featureSlider0[0] + " " + "1: " + PlayerMaterialHolder.featureSlider0[1] + " " + "2: " + PlayerMaterialHolder.featureSlider0[2]);

        UpdateColour();

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

    public void RollColour()
    {
        mRenderers[0].material.SetColor("_ColorOverlay", Color.red);
        mRenderers[1].material.SetColor("_ColorOverlay", Color.red);
        mRenderers[2].material.SetColor("_ColorOverlay", Color.red);
        mRenderers[3].material.SetColor("_ColorOverlay", Color.red);
        mRenderers[4].material.SetColor("_ColorOverlay", Color.red);
    }

    public void UpdateColour ()
    {
        mRenderers[0].material.SetColor("_ColorOverlay", Color.HSVToRGB(PlayerMaterialHolder.featureSlider0[0], PlayerMaterialHolder.featureSlider0[1], PlayerMaterialHolder.featureSlider0[2]));
        mRenderers[1].material.SetColor("_ColorOverlay", Color.HSVToRGB(PlayerMaterialHolder.featureSlider1[0], PlayerMaterialHolder.featureSlider1[1], PlayerMaterialHolder.featureSlider1[2]));
        mRenderers[2].material.SetColor("_ColorOverlay", Color.HSVToRGB(PlayerMaterialHolder.featureSlider2[0], PlayerMaterialHolder.featureSlider2[1], PlayerMaterialHolder.featureSlider2[2]));
        mRenderers[3].material.SetColor("_ColorOverlay", Color.HSVToRGB(PlayerMaterialHolder.featureSlider3[0], PlayerMaterialHolder.featureSlider3[1], PlayerMaterialHolder.featureSlider3[2]));
        mRenderers[4].material.SetColor("_ColorOverlay", Color.HSVToRGB(PlayerMaterialHolder.featureSlider4[0], PlayerMaterialHolder.featureSlider4[1], PlayerMaterialHolder.featureSlider4[2]));
    }
}
