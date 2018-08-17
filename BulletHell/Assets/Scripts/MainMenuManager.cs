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
        Debug.Log(AssetDatabase.GetAssetPath(emptySlot));
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            SaveLoad.Load();
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                Inventory.inventoryList.Add(AssetDatabase.GetAssetPath(emptySlot));
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

    public void QuitGame ()
    {
        Application.Quit();
    }
}
