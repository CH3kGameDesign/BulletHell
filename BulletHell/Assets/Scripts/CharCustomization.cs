using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharCustomization : MonoBehaviour {

	public GameObject CharacterSprites;
    public GameObject MainMenuManager;
    public GameObject UnityMaterialHolder;

	private List<Material> Hats = new List<Material>();
    private List<Material> Faces = new List<Material>();
    private List<Material> Shirts = new List<Material>();
    private List<Material> Pants = new List<Material>();

    private List<Material> NCHats = new List<Material>();
    private List<Material> NCFaces = new List<Material>();
    private List<Material> NCShirts = new List<Material>();
    private List<Material> NCPants = new List<Material>();

    public List<Slider> Sliders0 = new List<Slider>();
    public List<Slider> Sliders1 = new List<Slider>();
    public List<Slider> Sliders2 = new List<Slider>();
    public List<Slider> Sliders3 = new List<Slider>();
    public List<Slider> Sliders4 = new List<Slider>();

    public List<int> Selections = new List<int> ();
    public List<Text> SelectionNo = new List<Text> ();

    MeshRenderer[] mRenderers;
    MeshRenderer[] mNCRenderers;

    // Use this for initialization
    void Start () {
        SaveLoad.Load();

        Hats = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().Hats;
        Faces = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().Faces;
        Shirts = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().Shirts;
        Pants = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().Pants;

        NCHats = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().NCHats;
        NCFaces = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().NCFaces;
        NCShirts = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().NCShirts;
        NCPants = UnityMaterialHolder.GetComponent<UnityMaterialHolder>().NCPants;

        mRenderers = CharacterSprites.transform.GetChild(0).GetComponentsInChildren<MeshRenderer>();
        mNCRenderers = CharacterSprites.transform.GetChild(1).GetComponentsInChildren<MeshRenderer>();
        if (PlayerMaterialHolder.featureSlider0.Count < 1)
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerMaterialHolder.featureSlider0.Add(0);
                PlayerMaterialHolder.featureSlider1.Add(0);
                PlayerMaterialHolder.featureSlider2.Add(0);
                PlayerMaterialHolder.featureSlider3.Add(0);
                PlayerMaterialHolder.featureSlider4.Add(0);
            }
            PlayerMaterialHolder.featureSelection = Selections;
            
            Color BodyColour = mRenderers[0].material.GetColor("_ColorOverlay");
            Color PantsColour = mRenderers[1].material.GetColor("_ColorOverlay");
            Color ShirtColour = mRenderers[2].material.GetColor("_ColorOverlay");
            Color FaceColour = mRenderers[3].material.GetColor("_ColorOverlay");
            Color HatColour = mRenderers[4].material.GetColor("_ColorOverlay");

            float H, S, V;

            Color.RGBToHSV(BodyColour, out H, out S, out V);
            PlayerMaterialHolder.featureSlider0[0] = H;
            PlayerMaterialHolder.featureSlider0[1] = S;
            PlayerMaterialHolder.featureSlider0[2] = V;


            Color.RGBToHSV(PantsColour, out H, out S, out V);
            PlayerMaterialHolder.featureSlider1[0] = H;
            PlayerMaterialHolder.featureSlider1[1] = S;
            PlayerMaterialHolder.featureSlider1[2] = V;

            Color.RGBToHSV(ShirtColour, out H, out S, out V);
            PlayerMaterialHolder.featureSlider2[0] = H;
            PlayerMaterialHolder.featureSlider2[1] = S;
            PlayerMaterialHolder.featureSlider2[2] = V;

            Color.RGBToHSV(FaceColour, out H, out S, out V);
            PlayerMaterialHolder.featureSlider3[0] = H;
            PlayerMaterialHolder.featureSlider3[1] = S;
            PlayerMaterialHolder.featureSlider3[2] = V;

            Color.RGBToHSV(HatColour, out H, out S, out V);
            PlayerMaterialHolder.featureSlider4[0] = H;
            PlayerMaterialHolder.featureSlider4[1] = S;
            PlayerMaterialHolder.featureSlider4[2] = V;
        }

        for (int i = 0; i < 3; i++)
        {
            Sliders0[i].value = PlayerMaterialHolder.featureSlider0[i];
            Sliders1[i].value = PlayerMaterialHolder.featureSlider1[i];
            Sliders2[i].value = PlayerMaterialHolder.featureSlider2[i];
            Sliders3[i].value = PlayerMaterialHolder.featureSlider3[i];
            Sliders4[i].value = PlayerMaterialHolder.featureSlider4[i];
        }

        Selections = PlayerMaterialHolder.featureSelection;
        UpdateFeatures();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMaterialHolder.featureSlider0.Count < 1)
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerMaterialHolder.featureSlider0.Add(0);
                PlayerMaterialHolder.featureSlider1.Add(0);
                PlayerMaterialHolder.featureSlider2.Add(0);
                PlayerMaterialHolder.featureSlider3.Add(0);
                PlayerMaterialHolder.featureSlider4.Add(0);
            }
            PlayerMaterialHolder.featureSelection = Selections;
        }

    }

	public void ChangeSelectionUp (int feature)
	{
		Selections [feature] += 1;

		if (Selections [0] >= Hats.Count)
			Selections [0] = 0;
		if (Selections [0] < 0)
			Selections [0] = Hats.Count -1;

		if (Selections [1] >= Faces.Count)
			Selections [1] = 0;
		if (Selections [1] < 0)
			Selections [1] = Faces.Count -1;

		if (Selections [2] >= Shirts.Count)
			Selections [2] = 0;
		if (Selections [2] < 0)
			Selections [2] = Shirts.Count -1;

		if (Selections [3] >= Pants.Count)
			Selections [3] = 0;
		if (Selections [3] < 0)
			Selections [3] = Pants.Count -1;

		UpdateFeatures ();
	}

	public void ChangeSelectionDown (int feature)
	{
		Selections [feature] -= 1;

		if (Selections [0] >= Hats.Count)
			Selections [0] = 0;
		if (Selections [0] < 0)
			Selections [0] = Hats.Count -1;

		if (Selections [1] >= Faces.Count)
			Selections [1] = 0;
		if (Selections [1] < 0)
			Selections [1] = Faces.Count -1;

		if (Selections [2] >= Shirts.Count)
			Selections [2] = 0;
		if (Selections [2] < 0)
			Selections [2] = Shirts.Count -1;

		if (Selections [3] >= Pants.Count)
			Selections [3] = 0;
		if (Selections [3] < 0)
			Selections [3] = Pants.Count -1;

		UpdateFeatures ();
	}

	public void UpdateFeatures ()
	{
        SelectionNo[0].text = (Selections[0] + 1).ToString();
        SelectionNo[1].text = (Selections[1] + 1).ToString();
        SelectionNo[2].text = (Selections[2] + 1).ToString();
        SelectionNo[3].text = (Selections[3] + 1).ToString();

        mRenderers [1].material = Pants [Selections[3]];
		mRenderers [2].material = Shirts [Selections[2]];
		mRenderers [3].material = Faces [Selections[1]];
		mRenderers [4].material = Hats [Selections[0]];

        mNCRenderers[1].material = NCPants[Selections[3]];
        mNCRenderers[2].material = NCShirts[Selections[2]];
        mNCRenderers[3].material = NCFaces[Selections[1]];
        mNCRenderers[4].material = NCHats[Selections[0]];

        mRenderers[0].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders0[0].value, Sliders0[1].value, Sliders0[2].value));
        mRenderers[1].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders1[0].value, Sliders1[1].value, Sliders1[2].value));
        mRenderers[2].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders2[0].value, Sliders2[1].value, Sliders2[2].value));
        mRenderers[3].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders3[0].value, Sliders3[1].value, Sliders3[2].value));
        mRenderers[4].material.SetColor("_ColorOverlay", Color.HSVToRGB(Sliders4[0].value, Sliders4[1].value, Sliders4[2].value));
    }

    public void UpdateFeatureValues()
    {
        PlayerMaterialHolder.featureSelection = Selections;
        
        for (int i = 0; i < 3; i++)
        {
            PlayerMaterialHolder.featureSlider0[i] = Sliders0[i].value;
            PlayerMaterialHolder.featureSlider1[i] = Sliders1[i].value;
            PlayerMaterialHolder.featureSlider2[i] = Sliders2[i].value;
            PlayerMaterialHolder.featureSlider3[i] = Sliders3[i].value;
            PlayerMaterialHolder.featureSlider4[i] = Sliders4[i].value;
        }
        SaveLoad.Save();
        //MainMenuManager.GetComponent<MainMenuManager>().ChangeMenu(0);
        SceneManager.LoadScene(1);
    }

    public void CancelFeatureValues ()
    {
        Selections = PlayerMaterialHolder.featureSelection;
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(Selections[i] + " == " + PlayerMaterialHolder.featureSelection[i]);
        }
        
        for (int i = 0; i < 3; i++)
        {
            Sliders0[i].value = PlayerMaterialHolder.featureSlider0[i];
            Sliders1[i].value = PlayerMaterialHolder.featureSlider1[i];
            Sliders2[i].value = PlayerMaterialHolder.featureSlider2[i];
            Sliders3[i].value = PlayerMaterialHolder.featureSlider3[i];
            Sliders4[i].value = PlayerMaterialHolder.featureSlider4[i];
        }
        UpdateFeatures();
        MainMenuManager.GetComponent<MainMenuManager>().ChangeMenu(0);
    }



    public void RandomizeFeatures ()
    {
        Selections[0] = Random.Range(0, Hats.Count);
        Selections[1] = Random.Range(0, Faces.Count);
        Selections[2] = Random.Range(0, Shirts.Count);
        Selections[3] = Random.Range(0, Pants.Count);

        for (int i = 0; i < 3; i++)
        {
            float random0 = Random.Range(0f, 1f);
            Sliders0[i].value = random0;

            float random1 = Random.Range(0f, 1f);
            Sliders1[i].value = random1;

            float random2 = Random.Range(0f, 1f);
            Sliders2[i].value = random2;

            float random3 = Random.Range(0f, 1f);
            Sliders3[i].value = random3;

            float random4 = Random.Range(0f, 1f);
            Sliders4[i].value = random4;
        }

        UpdateFeatures();
    }
}
