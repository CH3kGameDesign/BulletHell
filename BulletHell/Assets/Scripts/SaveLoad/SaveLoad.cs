using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    /*
        WHAT SCRIPT DOES:
        -   Saves Progress
        -   Loads Progress
        -   Resets Progress
    */

    //SAVE
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Inventory.gd");
		bf.Serialize(file, Inventory.inventoryList);
        Debug.Log("Saved To " + Application.persistentDataPath + "/Inventory.gd");
        file.Close();
    }
    //LOAD
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Inventory.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Inventory.gd", FileMode.Open);
			Inventory.inventoryList = (List<int>)bf.Deserialize(file);
            file.Close();
        }

    }
    //RESET PROGRESS
    public static void ResetProgress()
    {
        //if (File.Exists(Application.persistentDataPath + "/levelComplete.gd"))
        //{
            File.Delete(Application.persistentDataPath + "/Inventory.gd");
        //}

    }
}
