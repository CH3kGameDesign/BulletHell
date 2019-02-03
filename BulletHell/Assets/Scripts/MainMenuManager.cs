using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
//using UnityEditor;																		*

public class MainMenuManager : MonoBehaviour {

    public GameObject mainMenu;
	public GameObject saveSelect;
    public GameObject charMenu;
    public GameObject sprites;

    public GameObject emptySlot;

	public GameObject charPicture;

	public GameObject saveSlot;
	public GameObject emptySaveSlot;
	public GameObject deleteSaveSlot;
    
	public Texture2D cursor;

	public List<string> saveFiles = new List<string>();

	// Use this for initialization
	void Start () {
		//Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);					*
        //Debug.Log(AssetDatabase.GetAssetPath(emptySlotobj));								*

		/*																					//
        if (File.Exists(Application.persistentDataPath + "/SaveData/inventory.dat"))
        {
			SaveLoad.Load(Inventory.saveFile);
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                //Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));	*
				Inventory.inventoryList.Add("empty");										//
            }
            for (int i = 0; i < 12; i++)
            {
                //Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));	*
                Inventory.inventoryListAmount.Add(0);										//
            }
        }

		if (File.Exists(Application.persistentDataPath + "/SaveData/permancyx.dat"))
        {
			SaveLoad.LoadPermancy(Inventory.saveFile);
        }

		*/																					//

        Cursor.SetCursor (cursor, new Vector2 (7, 2), CursorMode.ForceSoftware);
		Cursor.lockState = CursorLockMode.Confined;
		//SaveLoad.Save(Inventory.saveFile);												//

		saveFiles = SaveLoad.GetSaveNumbers();
		Debug.Log ("SaveFiles = " + saveFiles.Count);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

		if (Input.GetKey(KeyCode.Space))
		{
			
		}
    }

	public void StartGamePrep (int saveFile)
    {
		Inventory.saveFile = saveFile;

		if (File.Exists(Application.persistentDataPath + "/SaveData/" + Inventory.saveFile + "/inventory.dat"))
		{
			SaveLoad.Load(Inventory.saveFile);

			if (!File.Exists (Application.persistentDataPath + "/SaveData/" + Inventory.saveFile + "/gunInventory.dat")) {
				Inventory.gunList.Add("empty");
				Inventory.gunList.Add("empty");	
				Inventory.gunList.Add("empty");
				Inventory.gunList.Add("empty");
				Inventory.gunList.Add("0");
				Inventory.gunList.Add("0");
				Inventory.gunList.Add("0");
				Inventory.gunList.Add("empty");
			}
		}
		else
		{
			for (int i = 0; i < 12; i++)
			{
				//Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));	*
				Inventory.inventoryList.Add("empty");										//
			}
			for (int i = 0; i < 12; i++)
			{
				//Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));	*
				Inventory.inventoryListAmount.Add(0);										//
			}

			Inventory.gunList.Add("empty");
			Inventory.gunList.Add("empty");	
			Inventory.gunList.Add("empty");
			Inventory.gunList.Add("empty");
			Inventory.gunList.Add("0");
			Inventory.gunList.Add("0");
			Inventory.gunList.Add("0");
			Inventory.gunList.Add("empty");
		}

		if (File.Exists(Application.persistentDataPath + "/SaveData/" + Inventory.saveFile + "/permancyx.dat"))
		{
			SaveLoad.LoadPermancy(Inventory.saveFile);
		}

		SaveLoad.Save(Inventory.saveFile);
    }

	public void StartGame ()
	{
		SceneManager.LoadScene(1);
	}

	public void ResetProgress ()
	{
		SaveLoad.ResetProgress (Inventory.saveFile);
		//Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);					*
		Inventory.inventoryList = new List<string>();
		for (int i = 0; i < 12; i++)
		{
			//Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));		*
			Inventory.inventoryList.Add("empty");											//
		}

        Inventory.inventoryListAmount = new List<int>();
        for (int i = 0; i < 12; i++)
        {
            Inventory.inventoryListAmount.Add(0);                                           
        }
    }

    public void ChangeMenu (int selection)
    {
        if (selection == 0)
        {
            mainMenu.SetActive(true);
			saveSelect.SetActive (false);
            charMenu.SetActive(false);
            sprites.SetActive(false);
        }
		if (selection == 1)
		{
			mainMenu.SetActive(true);
			saveSelect.SetActive (true);
			charMenu.SetActive(false);
			sprites.SetActive(false);
			SaveSelectStartUp ();
		}
        if (selection == 2)
        {
			if (saveFiles.Count > 0)
				Inventory.saveFile = int.Parse (saveFiles [saveFiles.Count - 1]) + 1;
			else
				Inventory.saveFile = 0;
			StartGamePrep (Inventory.saveFile);
            mainMenu.SetActive(false);
			saveSelect.SetActive (false);
            charMenu.SetActive(true);
            sprites.SetActive(true);
        }
    }

	public void SaveSelectStartUp ()
	{
		saveFiles = SaveLoad.GetSaveNumbers();
		if (GameObject.Find ("Save Select").transform.childCount != 0) {
			for (int i = 0; i < GameObject.Find ("Save Select").transform.childCount; i++) {
				GameObject.Destroy (GameObject.Find ("Save Select").transform.GetChild (i).gameObject);
			}
			for (int i = 0; i < GameObject.Find("CharPictureHolder").transform.childCount; i++) {
				GameObject.Destroy (GameObject.Find("CharPictureHolder").transform.GetChild(i).gameObject);
			}
		}
		for (int i = 0; i < saveFiles.Count; i++) {
			SaveLoad.Load (i);
			GameObject CP = Instantiate (charPicture, GameObject.Find ("CharPictureHolder").transform);
			CP.name = saveFiles [i];
			CP.transform.localPosition = new Vector3 ((100 * i) + 100, 0, 0);
			GameObject SF = Instantiate (saveSlot, GameObject.Find("Save Select").transform);
			SF.name = saveFiles[i];
			SF.transform.localPosition = new Vector3 (180 * i, 0, 0);
			SF.GetComponent<Button> ().onClick.AddListener (delegate {
				StartGamePrep (int.Parse(SF.name));
				StartGame ();
			});
			//SF.GetComponentInChildren<Text> ().text = "Save File " + (i + 1);
			SF.GetComponentInChildren<Text> ().text = Inventory.name;

			CP.GetComponent<Camera>().targetTexture = new RenderTexture(1080,1080,16, RenderTextureFormat.ARGB32);
			SF.GetComponentInChildren<RawImage> ().texture = CP.GetComponent<Camera> ().targetTexture;

			GameObject SFdelete = Instantiate (deleteSaveSlot, GameObject.Find ("Save Select").transform);
			SFdelete.name = saveFiles [i];
			SFdelete.transform.localPosition = new Vector3 (180 * i + 69, 145, 0);
			SFdelete.GetComponent<Button> ().onClick.AddListener (delegate {DeleteSave(SFdelete.name);});
		}
		GameObject SFempty = Instantiate (emptySaveSlot, GameObject.Find("Save Select").transform);
		SFempty.transform.localPosition = new Vector3 (180 * saveFiles.Count, 0, 0);
		SFempty.GetComponent<Button> ().onClick.AddListener (delegate {ChangeMenu (2);});
	}

	public void DeleteSave (string saveFile)
	{
		int saveFileNo = int.Parse (saveFile);
		SaveLoad.ResetProgress (saveFileNo);
		SaveSelectStartUp ();
	}

    public void QuitGame ()
    {
        Application.Quit();
    }
}
