using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCustomization : MonoBehaviour {

	public GameObject CharacterSprites;

	public List<Material> Hats = new List<Material>();
	public List<Material> Faces = new List<Material>();
	public List<Material> Shirts = new List<Material>();
	public List<Material> Pants = new List<Material>();

	public List<int> Selections = new List<int> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeSelectionUp (int feature)
	{
		Selections [feature] += 1;

		if (Selections [0] > Hats.Count)
			Selections [0] = 0;
		if (Selections [0] < 0)
			Selections [0] = Hats.Count;

		if (Selections [1] > Faces.Count)
			Selections [1] = 0;
		if (Selections [1] < 0)
			Selections [1] = Faces.Count;

		if (Selections [2] > Shirts.Count)
			Selections [2] = 0;
		if (Selections [2] < 0)
			Selections [2] = Shirts.Count;

		if (Selections [3] > Pants.Count)
			Selections [3] = 0;
		if (Selections [3] < 0)
			Selections [3] = Pants.Count;

		UpdateFeatures ();
	}

	public void ChangeSelectionDown (int feature)
	{
		Selections [feature] -= 1;

		if (Selections [0] > Hats.Count)
			Selections [0] = 0;
		if (Selections [0] < 0)
			Selections [0] = Hats.Count;

		if (Selections [1] > Faces.Count)
			Selections [1] = 0;
		if (Selections [1] < 0)
			Selections [1] = Faces.Count;

		if (Selections [2] > Shirts.Count)
			Selections [2] = 0;
		if (Selections [2] < 0)
			Selections [2] = Shirts.Count;

		if (Selections [3] > Pants.Count)
			Selections [3] = 0;
		if (Selections [3] < 0)
			Selections [3] = Pants.Count;

		UpdateFeatures ();
	}

	public void UpdateFeatures ()
	{
		MeshRenderer[] mRenderers = CharacterSprites.GetComponentsInChildren<MeshRenderer>();
		mRenderers [1].material = Pants [Selections [3]];
		mRenderers [2].material = Shirts [Selections [2]];
		mRenderers [3].material = Faces [Selections [1]];
		mRenderers [4].material = Hats [Selections [0]];
	}
}
