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
        /*
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Inventory.gd");
		bf.Serialize(file, Inventory.inventoryList);
        Debug.Log("Saved To " + Application.persistentDataPath + "/Inventory.gd");
        file.Close();
        */
        FileStream fs = new FileStream(Application.persistentDataPath + "/inventory.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, Inventory.inventoryList);
        fs.Close();
    }
    //LOAD
    public static void Load()
    {
        /*
        if (File.Exists(Application.persistentDataPath + "/Inventory.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Inventory.gd", FileMode.Open);
			Inventory.inventoryList = (List<GameObject>)bf.Deserialize(file);
            file.Close();
        }
        */
        Debug.Log(Application.persistentDataPath);
        using (Stream stream = File.Open(Application.persistentDataPath + "/inventory.dat", FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            Inventory.inventoryList = (List<string>)bformatter.Deserialize(stream);
        }

    }
    //RESET PROGRESS
    public static void ResetProgress()
    {
        if (File.Exists(Application.persistentDataPath + "/inventory.dat"))
        {
            File.Delete(Application.persistentDataPath + "/inventory.dat");
        }

    }
}
