using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
//using UnityEditor;																		*

public class MainMenuManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject charMenu;
    public GameObject sprites;

    public GameObject emptySlot;
    
	public Texture2D cursor;

	// Use this for initialization
	void Start () {
		//Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);					*
        //Debug.Log(AssetDatabase.GetAssetPath(emptySlotobj));								*
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            SaveLoad.Load();
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

        if (File.Exists(Application.persistentDataPath + "/permancyx.dat"))
        {
            SaveLoad.LoadPermancy();
        }

        Cursor.SetCursor (cursor, new Vector2 (7, 2), CursorMode.ForceSoftware);
		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void StartGame ()
    {
        SaveLoad.Save();
        SceneManager.LoadScene(1);
    }

	public void ResetProgress ()
	{
		SaveLoad.ResetProgress ();
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
            charMenu.SetActive(false);
            sprites.SetActive(false);
        }
        if (selection == 1)
        {
            mainMenu.SetActive(false);
            charMenu.SetActive(true);
            sprites.SetActive(true);
        }
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
