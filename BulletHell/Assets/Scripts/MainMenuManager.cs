using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class MainMenuManager : MonoBehaviour {

	public GameObject emptySlot;

	public Texture2D cursor;

	// Use this for initialization
	void Start () {
		Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);
        Debug.Log(AssetDatabase.GetAssetPath(emptySlotobj));
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            SaveLoad.Load();
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));
            }
        }
		Cursor.SetCursor (cursor, new Vector2 (7, 2), CursorMode.ForceSoftware);
		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame ()
    {
        SaveLoad.Save();
        SceneManager.LoadScene(1);
    }

	public void ResetProgress ()
	{
		SaveLoad.ResetProgress ();
		Object emptySlotobj = PrefabUtility.GetPrefabParent (emptySlot);
		Inventory.inventoryList = new List<string>();
		for (int i = 0; i < 12; i++)
		{
			Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlotobj));
		}
	}

    public void QuitGame ()
    {
        Application.Quit();
    }
}
