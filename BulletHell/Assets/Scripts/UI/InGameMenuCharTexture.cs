using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuCharTexture : MonoBehaviour {

	private List<Material> Hats = new List<Material>();
	private List<Material> Faces = new List<Material>();
	private List<Material> Shirts = new List<Material>();
	private List<Material> Pants = new List<Material>();

	private List<Material> NCHats = new List<Material>();
	private List<Material> NCFaces = new List<Material>();
	private List<Material> NCShirts = new List<Material>();
	private List<Material> NCPants = new List<Material>();

	private List<float> Sliders0 = new List<float>();
	private List<float> Sliders1 = new List<float>();
	private List<float> Sliders2 = new List<float>();
	private List<float> Sliders3 = new List<float>();
	private List<float> Sliders4 = new List<float>();

	private List<int> Selections = new List<int> ();

	MeshRenderer[] mRenderers;
	MeshRenderer[] mNCRenderers;

	// Use this for initialization
	void Start () {
		Hats = PlayerMaterialHolder.Hats;
		Faces = PlayerMaterialHolder.Faces;
		Shirts = PlayerMaterialHolder.Shirts;
		Pants = PlayerMaterialHolder.Pants;

		NCHats = PlayerMaterialHolder.NCHats;
		NCFaces = PlayerMaterialHolder.NCFaces;
		NCShirts = PlayerMaterialHolder.NCShirts;
		NCPants = PlayerMaterialHolder.NCPants;

		mRenderers = transform.GetChild(0).GetChild(0).GetComponentsInChildren<MeshRenderer>();
		mNCRenderers = transform.GetChild(0).GetChild(1).GetComponentsInChildren<MeshRenderer>();


		this.name = Inventory.saveFile.ToString();
		
		UpdateTextures ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateTextures ()
	{
		Sliders0 = PlayerMaterialHolder.featureSlider0;
		Sliders1 = PlayerMaterialHolder.featureSlider1;
		Sliders2 = PlayerMaterialHolder.featureSlider2;
		Sliders3 = PlayerMaterialHolder.featureSlider3;
		Sliders4 = PlayerMaterialHolder.featureSlider4;

		Selections = PlayerMaterialHolder.featureSelection;

		mRenderers [1].material = Pants [Selections[3]];
		mRenderers [2].material = Shirts [Selections[2]];
		mRenderers [3].material = Faces [Selections[1]];
		mRenderers [4].material = Hats [Selections[0]];

		mNCRenderers[1].material = NCPants[Selections[3]];
		mNCRenderers[2].material = NCShirts[Selections[2]];
		mNCRenderers[3].material = NCFaces[Selections[1]];
		mNCRenderers[4].material = NCHats[Selections[0]];

		Debug.Log (Sliders0 [0] + "Colour");

		mRenderers[0].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders0[0], Sliders0[1], Sliders0[2]));
		mRenderers[1].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders1[0], Sliders1[1], Sliders1[2]));
		mRenderers[2].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders2[0], Sliders2[1], Sliders2[2]));
		mRenderers[3].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders3[0], Sliders3[1], Sliders3[2]));
		mRenderers[4].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders4[0], Sliders4[1], Sliders4[2]));
	}
}
