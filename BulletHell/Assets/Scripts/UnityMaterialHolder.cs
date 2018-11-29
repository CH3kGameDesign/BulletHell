using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMaterialHolder : MonoBehaviour {

    public List<Material> Hats = new List<Material>();
    public List<Material> Faces = new List<Material>();
    public List<Material> Shirts = new List<Material>();
    public List<Material> Pants = new List<Material>();

    public List<Material> NCHats = new List<Material>();
    public List<Material> NCFaces = new List<Material>();
    public List<Material> NCShirts = new List<Material>();
    public List<Material> NCPants = new List<Material>();

    public Material Null;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < NCHats.Count; i++)
        {
            if (NCHats[i] == null)
                NCHats[i] = Null;
        }
        for (int i = 0; i < NCFaces.Count; i++)
        {
            if (NCFaces[i] == null)
                NCFaces[i] = Null;
        }
        for (int i = 0; i < NCShirts.Count; i++)
        {
            if (NCShirts[i] == null)
                NCShirts[i] = Null;
        }
        for (int i = 0; i < NCPants.Count; i++)
        {
            if (NCPants[i] == null)
                NCPants[i] = Null;
        }
        PlayerMaterialHolder.Hats = Hats;
        PlayerMaterialHolder.Faces = Faces;
        PlayerMaterialHolder.Shirts = Shirts;
        PlayerMaterialHolder.Pants = Pants;

        PlayerMaterialHolder.NCHats = NCHats;
        PlayerMaterialHolder.NCFaces = NCFaces;
        PlayerMaterialHolder.NCShirts = NCShirts;
        PlayerMaterialHolder.NCPants = NCPants;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
